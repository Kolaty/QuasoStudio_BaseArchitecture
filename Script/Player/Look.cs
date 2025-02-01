using Cinemachine;
using UnityEngine;

// Basic class juste for enable one script
// perhaps for later it will be better 

namespace QuasoStudio.Player
{
    public class Look
    {
        private CinemachineInputProvider inputProvider;
        private bool IsLookInputEnable = false;


        public Look(CinemachineInputProvider script)
        {
            inputProvider = script;
            IsLookInputEnable = true;
        }

        public void ActivateLookInput()
        {
            if (IsLookInputEnable)
            {
                Debug.LogError("Look input allready enable");
                return;
            }
            inputProvider.enabled = true;
            IsLookInputEnable = true;
        }

        public void DeactivateLookInput()
        {
            if (!IsLookInputEnable)
            {
                Debug.LogError("Look input allready disable");
                return;
            }
            inputProvider.enabled = false;
            IsLookInputEnable = false;
        }
    }
}
