using UnityEngine;
using QuasoStudio.Interfaces;
using UnityEngine.AI;
using QuasoStudio.Services;
using System.Collections.Generic;

namespace QuasoStudio.AI
{
    public class AI_State_TheChaser_Wander : AI_BaseState, IUpdateServices, IIsPlayerIsInSight
    {
        private Transform transform;
        private const int MAXATTEMPTS = 20;
        private NavMeshAgent navMeshAgent;
        private float radius;
        private float dotThreshold = .5f;
        private Vector3 lastPosition = new Vector3();
        private float minDistance;
        private AI_Sensor AI_Sensor;
        private AI_StateMachine_TheChaser StateMachine;
        public AI_State_TheChaser_Wander(Transform transform, NavMeshAgent navMeshAgent,
        float radius, float minDistance, AI_Sensor AiSensor, AI_StateMachine_TheChaser StateMachine)
        {
            this.StateMachine = StateMachine;
            AI_Sensor = AiSensor;
            this.transform = transform;
            this.navMeshAgent = navMeshAgent;
            this.radius = radius;
            this.minDistance = minDistance;
            lastPosition = transform.position; // Last position initialize at the actual position
        }

        public override void Enter()
        {
            GameServices.Instance.UpdateService.RegisterUpdateObserver(this);
            FindNewDestination(); // Trouve une destination immédiatement
        }

        public override void Exit()
        {
            GameServices.Instance.UpdateService.UnregisterUpdateObserver(this);
        }

        public void OnUpdate()
        {
            IsPlayerIsInSight(AI_Sensor.Objects, StateMachine, StateTheChaser.ChasePlayer);
            // Vérifie si l'IA a atteint sa destination
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    // L'IA a atteint sa destination, cherche une nouvelle position
                    lastPosition = transform.position; // Met à jour la dernière position
                    FindNewDestination();

                }
            }
        }


        private Vector3 GetRandomPoint(float radius)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += transform.position;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
                return hit.position;

            return Vector3.zero;
        }

        private void FindNewDestination()
        {
            Vector3 randomPoint = GetRandomPoint(radius);
            int attempts = 0;

            do
            {
                randomPoint = GetRandomPoint(radius);
                attempts++;
            }
            while (attempts < MAXATTEMPTS && !IsPointValid(randomPoint));

            if (attempts < MAXATTEMPTS)
            {
                navMeshAgent.SetDestination(randomPoint);
            }
        }

        private bool IsPointValid(Vector3 newPoint)
        {
            if (newPoint == Vector3.zero) return false;

            // Vérifie la distance minimale
            float distance = Vector3.Distance(transform.position, newPoint);
            if (distance < minDistance)
                return false;

            // Calcul de la direction
            Vector3 lastDirection = (lastPosition - transform.position).normalized;
            Vector3 newDirection = (newPoint - transform.position).normalized;

            // Produit scalaire pour vérifier l'angle
            float dot = Vector3.Dot(lastDirection, newDirection);

            return dot < dotThreshold;
        }

        public void IsPlayerIsInSight(List<GameObject> ListAiSensor, AI_StateMachine_TheChaser StateMachine, StateTheChaser NewState)
        {
            if (ListAiSensor.Count != 0)
            {
                StateMachine.ChangeState(NewState);
            }
        }
    }

}
