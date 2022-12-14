using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AnimatorHandler : MonoBehaviour
    {
        private Animator animator;

        private int blend;

        public void Initialize()
        {
            animator = GetComponent<Animator>();
            blend = Animator.StringToHash("Blend");
        }

        public void updateAnimatorValue(Vector2 movementVector)
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
            animator.CrossFade("Roll", 0.2f);
        }
    }
}