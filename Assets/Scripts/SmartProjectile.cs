using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class SmartProjectile : MonoBehaviour
    {
        private Transform m_Target;

        private void Update()
        {
            if (m_Target != null)
            {
                Vector2 newSmartPos = m_Target.position - transform.position;

                transform.up += new Vector3(newSmartPos.x, newSmartPos.y, 0);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_Target == null)
            m_Target = collision.transform;
        }
    }
}