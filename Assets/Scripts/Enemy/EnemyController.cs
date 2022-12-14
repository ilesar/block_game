using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private int health = 100;

        public void TakeDamage()
        {
            Debug.Log("damage");
            health -= 40;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
