using UnityEngine;
using QuasoStudio.Interfaces;
using UnityEngine.AI;
using QuasoStudio.Services;
using System.Collections.Generic;


namespace QuasoStudio.AI
{
    public class AI_State_TheChaser_ChasePlayer : AI_BaseState, IUpdateServices, IIsPlayerIsInSight
    {
        private Transform player;
        private NavMeshAgent agent;
        private AI_Sensor AI_Sensor;
        private AI_StateMachine_TheChaser StateMachine;

        public AI_State_TheChaser_ChasePlayer(NavMeshAgent agent, AI_Sensor AiSensor, AI_StateMachine_TheChaser StateMachine)
        {
            AI_Sensor = AiSensor;
            this.StateMachine = StateMachine;
            this.agent = agent;
        }

        public override void Enter()
        {
            if (player == null)
            {
                GameObject go = GameObject.Find("Gameplay/Actors/Player");
                if (go == null) return;
                else player = go.transform;
            }
            GameServices.Instance.UpdateService.RegisterUpdateObserver(this);
        }

        public override void Exit()
        {
            GameServices.Instance.UpdateService.UnregisterUpdateObserver(this);
        }

        public void IsPlayerIsInSight(List<GameObject> ListAiSensor, AI_StateMachine_TheChaser StateMachine, StateTheChaser NewState)
        {
            if (ListAiSensor.Count != 0)
            {
                StateMachine.ChangeState(NewState);
            }
        }

        public void OnUpdate()
        {
            IsPlayerIsInSight(AI_Sensor.Objects, StateMachine, StateTheChaser.Wander);    
            agent.destination = player.position;
        }

        
    }
}
