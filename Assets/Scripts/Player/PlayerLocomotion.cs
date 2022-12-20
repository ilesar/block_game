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

        private bool isSprinting;

        private void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            animatorHandler = GetComponent<AnimatorHandler>();

            animatorHandler.Initialize();
            inputHandler.getFireAction().started += ctx => HandlePunch();
            inputHandler.getRollAction().started += ctx => HandleRoll();
            inputHandler.getSprintAction().started += ctx => HandleSprint();
            inputHandler.getSprintAction().canceled += ctx => HandleSprintStop();
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
            animatorHandler.UpdateAnimatorValue(input, isSprinting);

            if (animatorHandler.isRolling == true) {
                controller.Move(localTransform.forward * speed * Time.deltaTime);
            }

            if (animatorHandler.canMove == false)
            {
                return;
            }

            if (input.magnitude < 0.1f)
                return;

            Vector3 directionOfMovement = new Vector3(input.x, 0f, input.y).normalized; ;
            float magnitude = input.magnitude;

            if (isSprinting) {
                magnitude *= 1.3f;
            }

            if (directionOfMovement.magnitude >= 0.1f)
            {
                controller.Move(
                    directionOfMovement.normalized * magnitude * speed * Time.deltaTime
                );
            }
        }

        private void HandlePlayerRotation(Vector2 input)
        {
            if (animatorHandler.canRotate == false)
            {
                return;
            }

            if (input.magnitude < 0.1f)
            {
                return;
            }

            float magnitude = 3f;

            if (isSprinting) {
                magnitude *= 1.3f;
            }

            Debug.DrawLine(
                localPosition,
                transform.position + transform.forward * input.magnitude * magnitude,
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

        private void HandlePunch()
        {
            animatorHandler.DisableRotation();
            animatorHandler.DisableMovement();
            animatorHandler.Punch();
        }

        private void HandleRoll()
        {
            animatorHandler.DisableRotation();
            animatorHandler.DisableMovement();
            animatorHandler.Roll();
        }

        private void HandleSprint()
        {
            Vector2 movementVector = inputHandler.getMovementVector();

            if (movementVector.magnitude < 0.9f)
            {
                return;
            }

            isSprinting = true;
        }

        private void HandleSprintStop()
        {
            isSprinting = false;
        }
    }
}
