using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace R_D_2.Script.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
    public class InputReader : ScriptableObject
    {
        [SerializeField, Tooltip("Put InputActionMap_Player here")] private InputActionAsset asset;
        
        public UnityAction<Vector2> LookEvent;
        public UnityAction<Vector2> MoveEvent;
        
        public UnityAction InteractEvent;
        public UnityAction RunEvent;
        public UnityAction ToggleFlashlightEvent;
        public UnityAction AcceptEvent;
        public UnityAction PauseEvent;
        
        private InputAction interactAction;
        private InputAction runAction;
        private InputAction toggleFlashlightAction;
        private InputAction lookAction;
        private InputAction moveAction;
        private InputAction acceptAction;
        private InputAction pauseAction;

        private void OnEnable()
        {
            interactAction = asset.FindAction("Interact");
            runAction = asset.FindAction("Run");
            toggleFlashlightAction = asset.FindAction("Flashlight");
            lookAction = asset.FindAction("Look");
            moveAction = asset.FindAction("Movement");
            acceptAction = asset.FindAction("Accept");
            pauseAction = asset.FindAction("Pause");
            
            interactAction.started += OnInteract;
            interactAction.performed += OnInteract;
            interactAction.canceled += OnInteract;
            
            runAction.started += OnRun;
            runAction.performed += OnRun;
            runAction.canceled += OnRun;
            
            toggleFlashlightAction.started += OnToggleFlashlight;
            toggleFlashlightAction.performed += OnToggleFlashlight;
            toggleFlashlightAction.canceled += OnToggleFlashlight;

            lookAction.started += OnLookAction;
            lookAction.performed += OnLookAction;
            lookAction.canceled += OnLookAction;
            
            moveAction.started += OnMoveAction;
            moveAction.performed += OnMoveAction;
            moveAction.canceled += OnMoveAction;

            acceptAction.started += OnAcceptAction;
            acceptAction.performed += OnAcceptAction;
            acceptAction.canceled += OnAcceptAction;
            
            pauseAction.started += OnPauseAction;
            pauseAction.performed += OnPauseAction;
            pauseAction.canceled += OnPauseAction;

            interactAction.Enable();
            runAction.Enable();
            toggleFlashlightAction.Enable();
            lookAction.Enable();
            moveAction.Enable();
            acceptAction.Enable();
            pauseAction.Enable();
        }

        private void OnDisable()
        {
            interactAction.started -= OnInteract;
            interactAction.performed -= OnInteract;
            interactAction.canceled -= OnInteract;
            
            runAction.started -= OnRun;
            runAction.performed -= OnRun;
            runAction.canceled -= OnRun;
            
            toggleFlashlightAction.started -= OnToggleFlashlight;
            toggleFlashlightAction.performed -= OnToggleFlashlight;
            toggleFlashlightAction.canceled -= OnToggleFlashlight;

            lookAction.started -= OnLookAction;
            lookAction.performed -= OnLookAction;
            lookAction.canceled -= OnLookAction;
            
            moveAction.started -= OnMoveAction;
            moveAction.performed -= OnMoveAction;
            moveAction.canceled -= OnMoveAction;
            
            acceptAction.started -= OnAcceptAction;
            acceptAction.performed -= OnAcceptAction;
            acceptAction.canceled -= OnAcceptAction;
            
            pauseAction.started -= OnPauseAction;
            pauseAction.performed -= OnPauseAction;
            pauseAction.canceled -= OnPauseAction;
            
            interactAction.Disable();
            runAction.Disable();
            toggleFlashlightAction.Disable();
            lookAction.Disable();
            moveAction.Disable();
            acceptAction.Disable();
            pauseAction.Disable();
        }
        
        private void OnInteract(InputAction.CallbackContext context)
        {
            if(InteractEvent != null && context.started)
                InteractEvent.Invoke();
        }

        private void OnRun(InputAction.CallbackContext context)
        {
            if(RunEvent != null && context.started)
                RunEvent.Invoke();
        }

        private void OnToggleFlashlight(InputAction.CallbackContext context)
        {
            if(ToggleFlashlightEvent != null && context.started)
                ToggleFlashlightEvent.Invoke();
        }

        private void OnLookAction(InputAction.CallbackContext context)
        {
            LookEvent?.Invoke(context.ReadValue<Vector2>());
        }
        
        private void OnMoveAction(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnAcceptAction(InputAction.CallbackContext context)
        {
            if(AcceptEvent != null && context.started)
                AcceptEvent.Invoke();
        }

        private void OnPauseAction(InputAction.CallbackContext context)
        {
            if(PauseEvent != null && context.started)
                PauseEvent.Invoke();
        }
    }
}

