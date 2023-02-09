using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ExplosionDestroyCircuit : MonoBehaviour
    {
        public static string IgnoreTag = "WorldBoundary";

        [SerializeReference] private float m_DamageConstant;

        [SerializeField] private float m_Radius;

        [SerializeField] private float m_LifeTime;

        private void Start()
        {
            Destroy(gameObject, m_LifeTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == IgnoreTag)
                return;

            var destructable = collision.transform.root.GetComponent<Destructible>();

            if (destructable != null)
            {
                destructable.ApplyDamage((int)m_DamageConstant);
            }
        }

#if UNITY_EDITOR
        private static Color GizmoColor = new Color(219, 30, 32, 0.3f);

        private void OnDrawGizmosSelected()
        {
            Handles.color = GizmoColor;
            Handles.DrawSolidDisc(transform.position, transform.forward, m_Radius);
        }
        private void OnValidate()
        {
            GetComponent<CircleCollider2D>().radius = m_Radius;
        }
#endif
    }
}
