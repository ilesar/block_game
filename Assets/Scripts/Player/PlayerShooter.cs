using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        public GameObject bulletPrefab;
        private AudioSource _audioSource;
        private InputAction _fireAction;
        private Transform _localTransform;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _fireAction = _playerInput.actions["Fire"];

            _fireAction.started += ctx => Shoot();
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }


        private void Update()
        {
            _localTransform = transform;
        }

        private void Shoot()
        {
            if (!bulletPrefab || !_localTransform) return;
            _audioSource.PlayOneShot(_audioSource.clip);
            Instantiate(bulletPrefab, _localTransform.position + transform.forward * 3f, _localTransform.rotation);
        }
    }
}