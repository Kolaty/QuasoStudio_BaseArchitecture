using System.Collections.Generic;
using UnityEngine.AI;

namespace R_D_2.Script.AI
{
    public class AI_StateMachine_TheChaser
    {
        private AI_TheChaser theChaser;
        private AI_BaseState currentState;
        private Dictionary<StateTheChaser, AI_BaseState> allPossibleState = new Dictionary<StateTheChaser, AI_BaseState>();

        public AI_StateMachine_TheChaser(AI_TheChaser TheChaser)
        {
            theChaser = TheChaser;
            InitializeDictionnary();
        }

        public void InitializeDictionnary()
        {
            var tempoNavMeshAgent = theChaser.gameObject.GetComponent<NavMeshAgent>();
            var tempoAISensor = theChaser.gameObject.GetComponent<AI_Sensor>();

            allPossibleState.Add(StateTheChaser.Wander, new AI_State_TheChaser_Wander(theChaser.transform,
                tempoNavMeshAgent, 25f, 10f, tempoAISensor, this));
            allPossibleState.Add(StateTheChaser.ChasePlayer, new AI_State_TheChaser_ChasePlayer(tempoNavMeshAgent, tempoAISensor, this));
        }

        public void ChangeState(StateTheChaser NewState)
        {
            if (currentState != null)
                currentState.Exit();
            currentState = allPossibleState[NewState]; // No check niark niark niark
            currentState.Enter();
        }

        public void DestroyStateMachine()
        {
            currentState.Exit();
        }
    }

}
