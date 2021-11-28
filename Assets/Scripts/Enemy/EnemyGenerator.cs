using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyGenerator : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public float period = 5.0f;

        private void Start()
        {
            // InvokeRepeating(nameof(CreateEnemy), 3.0f, period);
        }

        private void CreateEnemy()
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-20f, 20f), 1f, Random.Range(-20f, 20f)), transform.rotation);
        }
    }
    
}
