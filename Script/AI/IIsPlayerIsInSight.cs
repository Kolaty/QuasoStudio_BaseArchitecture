using UnityEngine;
using System.Collections.Generic;
using R_D_2.Script.AI;

namespace R_D_2.Script.Interfaces
{
    public interface IIsPlayerIsInSight
    {
        public abstract void IsPlayerIsInSight(List<GameObject> ListAiSensor, AI_StateMachine_TheChaser StateMachine, StateTheChaser NewState);
    }
}