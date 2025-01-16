using UnityEngine;

namespace R_D_2.Script.Services
{
    public class TimeService
    {
        public bool IsTimePaused { get; set; }

        public TimeService() 
        { 

        }

        public void ChangeGameTime()
        {
            if (IsTimePaused)
                StopGameTime();
            else
                StartGameTime();
        }

        private void StopGameTime()
        {
            if (IsTimePaused)
            {
                Debug.LogError("Time allready stopped");
                return;
            }
            Time.timeScale = 0f;
        }

        private void StartGameTime()
        {
            if (IsTimePaused)
            {
                Debug.LogError("Time allready stopped");
                return;
            }
            Time.timeScale = 1f;
        }
    }
}