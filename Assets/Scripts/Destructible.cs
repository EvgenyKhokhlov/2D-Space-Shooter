 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Destroible object on scene. Has hitpoints
    /// </summary>
    public class Destructible : Entity
    {
        #region Properties
        /// <summary>
        /// Ignored damage object
        /// </summary>
        [SerializeField] private bool m_Indestructible;
        public bool IsIndestructible => m_Indestructible;

        /// <summary>
        /// Start hitpoint amount
        /// </summary>
        [SerializeField] private int m_Hitpoints;
        public int Hitpoints => m_Hitpoints;

        /// <summary>
        /// Current hitpoint amount
        /// </summary>
        private int m_CurrentHitPoints;
        public int CurrentHitPoints => m_CurrentHitPoints;

        #endregion

        #region Unity Events

        protected virtual void Start()
        {
            m_CurrentHitPoints = m_Hitpoints;
        }
        #endregion

        #region Public API

        /// <summary>
        /// Damage to the ibject applying
        /// </summary>
        /// <param name="damage">Damage amount to the object</param>
        public void ApplyDamage(int damage)
        {
            if (m_Indestructible) return;

            m_CurrentHitPoints -= damage;

            if (m_CurrentHitPoints <= 0)
                OnDead();
        }
        #endregion
        /// <summary>
        /// Redefined of oject destoying event when hiypoint equil zero
        /// </summary>
        protected virtual void OnDead()
        {
            Destroy(gameObject);
            m_EventOnDeath?.Invoke();
        }

        private static HashSet<Destructible> m_AllDestructible;

        public static IReadOnlyCollection<Destructible> AllDestructible => m_AllDestructible;

        protected virtual void OnEnable()
        {
            if (m_AllDestructible == null)
                m_AllDestructible = new HashSet<Destructible>();

            m_AllDestructible.Add(this);
        }

        protected virtual void OnDestroy()
        {
            m_AllDestructible.Remove(this);
        }

        [SerializeField] private UnityEvent m_EventOnDeath;
        public UnityEvent EventOnDeath => m_EventOnDeath;

        public const int TeamIdNeutral = 0;

        [SerializeField] private int m_TeamId;
        public int TeamId => m_TeamId;

        public void ImmortalityActivate()
        {
            m_Indestructible = true;
        }

        public void ImmortalityDisactivate()
        {
            m_Indestructible = false;
        }

        #region Score

        [SerializeField] private int m_ScoreValue;
        public int ScoreValue => m_ScoreValue;


        #endregion
    }

}
