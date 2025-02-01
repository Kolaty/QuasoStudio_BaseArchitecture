using UnityEngine;
using QuasoStudio.Interfaces;
using QuasoStudio.Input;

namespace QuasoStudio.Player
{
    public class Movement : IFixedUpdateServices
    {
        private readonly CharacterController characterController;
        private readonly InputReader playerInput;
        private readonly Transform playerTransform;
        private readonly Transform cameraTransform;
        public float MoveSpeed { get; set; }
        private Vector2 MovementInput = new Vector2();

        public Movement(CharacterController characterController,
            InputReader playerInput, Transform playerTransform, float moveSpeed)
        {
            this.characterController = characterController;
            this.playerInput = playerInput;
            this.playerTransform = playerTransform;
            this.cameraTransform = Camera.main.transform;
            this.MoveSpeed = moveSpeed;
        }
        
        private void Move()
        {
            Vector3 move = playerTransform.right * MovementInput.x +
                           playerTransform.forward * MovementInput.y;
            move = cameraTransform.forward * move.z + cameraTransform.right * MovementInput.x;
            move.y = 0f;
            characterController.Move(move * MoveSpeed * Time.deltaTime);
        }
        
        private void SetMovementInput(Vector2 movementInput)
        {
            this.MovementInput = movementInput;
        }

        public void OnFixedUpdate()
        {
            Move();
        }

        public void OnEnable()
        {
            playerInput.MoveEvent += SetMovementInput;
        }

        public void OnDisable()
        {
            playerInput.MoveEvent -= SetMovementInput;
        }
    }
}

