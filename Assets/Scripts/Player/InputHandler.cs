using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerInput playerInput;

        private InputAction lookAroundAction;
        private InputAction moveAction;
        private InputAction rollAction;
        private InputAction fireAction;
        private InputAction sprintAction;

        // Start is called before the first frame update
        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            moveAction = playerInput.actions["Move"];
            lookAroundAction = playerInput.actions["LookAround"];
            rollAction = playerInput.actions["Roll"];
            fireAction = playerInput.actions["Fire"];
            sprintAction = playerInput.actions["Sprint"];
        }

        public Vector2 getMovementVector()
        {
            return moveAction.ReadValue<Vector2>();
        }

        public Vector2 getLookAroundVector()
        {
            return lookAroundAction.ReadValue<Vector2>();
        }

        public InputAction getRollAction()
        {
            return rollAction;
        }

        public InputAction getFireAction()
        {
            return fireAction;
        }

        public InputAction getSprintAction()
        {
            return sprintAction;
        }
    }
}