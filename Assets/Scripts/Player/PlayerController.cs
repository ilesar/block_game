using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController controller;
        public Transform cam;

        public float speed = 6f;

        public float turnSmoothTime = 0.1f;
        public float turnSmoothVelocity;
        private Vector3 _localPosition;

        private Transform _localTransform;
        private InputAction _lookAroundAction;
        private InputAction _moveAction;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _moveAction = _playerInput.actions["Move"];
            _lookAroundAction = _playerInput.actions["LookAround"];

            _moveAction.started += ctx => EnableMovementShield(_moveAction.ReadValue<Vector2>());
            _moveAction.performed += ctx => DisableMovementShield(_moveAction.ReadValue<Vector2>());
        }

        private void Update()
        {
            _localTransform = transform;
            _localPosition = _localTransform.position;

            Vector2 moveValue = _moveAction.ReadValue<Vector2>();
            Vector2 lookAroundValue = _lookAroundAction.ReadValue<Vector2>();

            MovePlayer(moveValue);
            RotatePlayer(lookAroundValue);
        }

        private void DisableMovementShield(Vector2 input)
        {
            if (input.magnitude < 0.1f) return;
            Debug.Log("DISABLE");
        }

        private void EnableMovementShield(Vector2 input)
        {
            // if (input.magnitude < 0.1f) return;
            Debug.Log("ENABLED");
        }


        private void RotatePlayer(Vector2 input)
        {
            if (!Camera.main) throw new Exception("Camera missing");

            if (input.magnitude < 0.1f) return;

            Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(input.x, 1f, input.y) * 20f, Color.gray);

            float targetAngleForRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            float smoothTargetAngleForRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleForRotation,
                ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothTargetAngleForRotation, 0f);
        }

        private void MovePlayer(Vector2 input)
        {
            if (input.magnitude < 0.1f) return;

            Vector3 directionOfMovement = new Vector3(input.x, 0f, input.y).normalized;

            if (directionOfMovement.magnitude >= 0.1f)
                controller.Move(directionOfMovement.normalized * speed * Time.deltaTime);
        }
    }
}