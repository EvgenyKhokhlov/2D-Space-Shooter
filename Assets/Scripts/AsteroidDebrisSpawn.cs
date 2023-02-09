using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class AsteroidDebrisSpawn : MonoBehaviour
    {
        [SerializeField] private Destructible m_DebrisPrefabs;

        [SerializeField] private int m_DebrisNumber;

        [SerializeField] private float m_DebrisSpeed;

        public void DebrisSpawn()
        {
            for (int i = 0; i < m_DebrisNumber; i++)
            {
                GameObject debris = Instantiate(m_DebrisPrefabs.gameObject, transform.position, Quaternion.identity);

                Rigidbody2D rb = debris.GetComponent<Rigidbody2D>();

                if (rb != null && m_DebrisSpeed > 0)
                {
                    rb.velocity = UnityEngine.Random.insideUnitCircle * m_DebrisSpeed;
                }

            }
        }

    }
}
