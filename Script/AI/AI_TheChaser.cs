using QuasoStudio.Services;
using UnityEngine;
using UnityEngine.AI;

namespace QuasoStudio.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(AI_Sensor))]
    public class AI_TheChaser : MonoBehaviour
    {
        public AI_StateMachine_TheChaser AI_StateMachine_TheChaser {  get; private set; }
        public StateTheChaser BaseState;

        public void Awake()
        {
            AI_StateMachine_TheChaser = new AI_StateMachine_TheChaser(this);
        }

        public void Start()
        {
            AI_StateMachine_TheChaser.ChangeState(BaseState);
        }

        public void OnDestroy()
        {
            AI_StateMachine_TheChaser.DestroyStateMachine();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            AI_StateMachine_TheChaser.DestroyStateMachine();
            GameServices.Instance.UIService.DisplayGameOverBlock();
        }
    }
}
