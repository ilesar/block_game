using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AnimatorHandler : MonoBehaviour
    {
        private Animator animator;

        private int blend;

        public bool canRotate;
        public bool canMove;

        public void Initialize()
        {
            animator = GetComponent<Animator>();
            blend = Animator.StringToHash("Blend");
            canRotate = true;
            canMove = true;
        }

        public void UpdateAnimatorValue(Vector2 movementVector)
        {
            animator.SetFloat(
                blend,
                movementVector.magnitude,
                0.1f,
                Time.deltaTime
            );
        }
        public void Roll()
        {
            animator.CrossFade("Rolling", 0.2f);
        }

        public void Punch()
        {
            animator.CrossFade("Punching", 0.0f);
        }

        public void EnableRotation()
        {
            canRotate = true;
        }

        public void DisableRotation()
        {
            canRotate = false;
        }

        public void EnableMovement()
        {
            canMove = true;
        }

        public void DisableMovement()
        {
            canMove = false;
        }
    }
}