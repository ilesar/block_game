using System.Collections;
using Enemy;
using UnityEngine;

namespace Weapon
{
    public class BulletController : MonoBehaviour
    {
        private Transform _localTransform;

        private void Start()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 1500f);
            StartCoroutine(DestroyBullet());
        }

        private void Update()
        {
            _localTransform = transform;
            Debug.DrawRay(_localTransform.position, _localTransform.forward * 5f, Color.red);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Enemy(Clone)")
            {
                EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
                enemyController.TakeDamage();
            }

            Destroy(gameObject);
        }

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}