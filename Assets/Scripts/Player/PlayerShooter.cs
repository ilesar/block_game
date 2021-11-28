using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        public GameObject bulletPrefab;
        private InputAction _fireAction;

        private Transform _localTransform;

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _fireAction = _playerInput.actions["Fire"];

            _fireAction.started += ctx => Shoot();
        }


        private void Update()
        {
            _localTransform = transform;
        }

        private void Shoot()
        {
            if (!bulletPrefab || !_localTransform) return;

            Instantiate(bulletPrefab, _localTransform.position + transform.forward * 3f, _localTransform.rotation);
        }
    }
}