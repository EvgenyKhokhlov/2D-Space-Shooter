using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private float lifeTime;

        private float m_Time;

        private void Update()
        {
            m_Time += Time.deltaTime;

            if (m_Time >= lifeTime)
            {
                transform.root.GetComponent<Destructible>().ImmortalityDisactivate();

                Destroy(gameObject);
            }
        }
    }
}
