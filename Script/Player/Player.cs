using Cinemachine;
using QuasoStudio.Input;
using QuasoStudio.Interfaces;
using QuasoStudio.Services;
using UnityEngine;

namespace QuasoStudio.Player
{
    public class Player : MonoBehaviour, IFixedUpdateServices
    {
        [SerializeField, Tooltip("Put InputActionMap_Player here")] public InputReader InputPlayer;
        [SerializeField, Tooltip("Base movespeed for the player")] public float MovementSpeed;
        public Look Look { get; private set; } 
        private Movement movement;

        private void Awake()
        {
            movement = new Movement(GetComponent<CharacterController>(), InputPlayer, transform,
                MovementSpeed);
                Look = new Look(GameObject.Find("Camera/Virtual Camera").GetComponent<CinemachineInputProvider>()); // MERF
        }

        private void Start()
        {
            movement.OnEnable();
            GameServices.Instance.UpdateService.RegisterFixedUpdateObserver(this);
        }

        public void OnFixedUpdate()
        {
            movement.OnFixedUpdate();
        }

        private void OnEnable()
        {
            // Little trick because gameservices isn't initialized, and if I want a player in the scene and not spawn it directly
            // I can with that
            if (GameServices.Instance == null || GameServices.Instance.GameServicesInitialized == false) return;
            movement.OnEnable();
            GameServices.Instance.UpdateService.RegisterFixedUpdateObserver(this);
        }

        private void OnDisable()
        {
            movement.OnDisable();
            GameServices.Instance.UpdateService.UnregisterFixedUpdateObserver(this);
        }

        public void UpdateLevelInformation()
        {
            movement.OnEnable();
            GameServices.Instance.UpdateService.RegisterFixedUpdateObserver(this);
        }
    }

}
