using UnityEngine;
using System.Collections.Generic;
using QuasoStudio.AI;

namespace QuasoStudio.Interfaces
{
    public interface IIsPlayerIsInSight
    {
        public abstract void IsPlayerIsInSight(List<GameObject> ListAiSensor, AI_StateMachine_TheChaser StateMachine, StateTheChaser NewState);
    }
}
