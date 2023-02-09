using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : Entity
    {
        [SerializeField] private float m_Velocity;

        [SerializeField] private float m_LifeTime;

        [SerializeField] private int m_Damage;

        [SerializeField] private GameObject m_ImpactEffectPrefab;

        private bool m_IsPlayerProjectile = false;

        private void Update()
        {
            float stepLength = m_Velocity * Time.deltaTime; 
            Vector2 step = transform.up * stepLength;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLength);

            if (m_Parent == Player.Instance.ActiveShip)
            {
                m_IsPlayerProjectile = true;
            }

            if (m_Parent == null && m_IsPlayerProjectile)
            {
                m_Parent = Player.Instance.ActiveShip;
            }

            if (hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();

                if (dest != null && dest != m_Parent)
                {
                    dest.ApplyDamage(m_Damage);

                    if (m_Parent == Player.Instance.ActiveShip)
                    {
                        Player.Instance.AddScore(dest.ScoreValue);
                    }
                }

                OnProjectileLifeEnd(hit.collider, hit.point);
            }

            Destroy(gameObject, m_LifeTime);

            transform.position += new Vector3(step.x, step.y, 0);

        }

        private void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            Instantiate(m_ImpactEffectPrefab, transform.position, transform.rotation);

            Destroy(gameObject); 
        }

        private Destructible m_Parent;

        public void SetParentShooter(Destructible parent)
        {
            m_Parent = parent;
        }
    }
}