using UnityEngine;
using R_D_2.Script.Interfaces;
using R_D_2.Script.Services;
using UnityEngine.Events;

namespace R_D_2.Script.Tools
{
    public class TimerQuasoStudio : IUpdateServices
    {
        private float tempoTime;
        private float timerEnd;
        public UnityEvent TimerEndEvent;

        public TimerQuasoStudio(float TimerEnd)
        {
            timerEnd = TimerEnd;
            TimerEndEvent = new UnityEvent();
        }

        public void StartTimer()
        {
            GameServices.Instance.UpdateService.RegisterUpdateObserver(this);
        }

        public void DestroyTimer()
        {
            GameServices.Instance.UpdateService.UnregisterUpdateObserver(this);
        }

        public void OnUpdate()
        {
            tempoTime += Time.deltaTime;
            if(tempoTime > timerEnd)
            {
                TimerEndEvent?.Invoke();
                GameServices.Instance.UpdateService.UnregisterUpdateObserver(this);
                tempoTime = 0f;
            }
        }
    }

}
