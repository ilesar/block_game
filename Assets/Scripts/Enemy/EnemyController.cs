using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public void TakeDamage()
        {
            Destroy(gameObject);
        }
    }
    
}
