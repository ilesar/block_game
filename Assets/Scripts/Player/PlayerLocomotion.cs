using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerLocomotion : MonoBehaviour
    {
        public CharacterController controller;

        public float speed = 5f;
        public float turnSmoothTime = 0.1f;
        public float turnSmoothVelocity;

        private Vector3 localPosition;
        private Transform localTransform;

        private InputHandler inputHandler;
        private AnimatorHandler animatorHandler;

        private void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            animatorHandler = GetComponent<AnimatorHandler>();

            animatorHandler.Initialize();
            inputHandler.getRollAction().started += ctx => animatorHandler.Roll();
        }

        private void Update()
        {
            localTransform = transform;
            localPosition = localTransform.position;

            Vector2 movementVector = inputHandler.getMovementVector();
            HandlePlayerMovement(movementVector);
            HandlePlayerRotation(movementVector);
        }


        private void HandlePlayerMovement(Vector2 input)
        {
            animatorHandler.updateAnimatorValue(input);

            if (input.magnitude < 0.1f)
                return;

            Vector3 directionOfMovement = new Vector3(input.x, 0f, input.y).normalized;

            if (directionOfMovement.magnitude >= 0.1f)
            {
                controller.Move(
                    directionOfMovement.normalized * input.magnitude * speed * Time.deltaTime
                );
            }
        }

        private void HandlePlayerRotation(Vector2 input)
        {
            if (input.magnitude < 0.1f)
            {
                return;
            }

            Debug.DrawLine(
                localPosition,
                transform.position + transform.forward * input.magnitude * 3f,
                Color.red,
                Time.deltaTime,
                false
            );

            float targetAngleForRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;

            float smoothTargetAngleForRotation = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                targetAngleForRotation,
                ref turnSmoothVelocity,
                turnSmoothTime
            );

            transform.rotation = Quaternion.Euler(0f, smoothTargetAngleForRotation, 0f);
        }

    }
}
