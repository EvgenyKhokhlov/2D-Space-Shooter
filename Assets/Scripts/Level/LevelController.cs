using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public interface ILevelCondition
    {
        bool IsComleted { get; }
    }

    public class LevelController : SingletonBase<LevelController>
    {
        [SerializeField] private int m_ReferenceTime;
        public int ReferenceTime=> m_ReferenceTime;

        [SerializeField] private float m_LimitTime;
        public float LimitTime=> m_LimitTime;

        [SerializeField] private UnityEvent m_EventLevelCompleted;

        private ILevelCondition[] m_Conditions;

        private bool m_IsLevelCompleted;

        private float m_LevelTime;
        public float LevelTime => m_LevelTime;

        private void Start()
        {
            m_Conditions = GetComponentsInChildren<ILevelCondition>();
        }

        private void Update()
        {
            if (!m_IsLevelCompleted)
            {
                m_LevelTime += Time.deltaTime;

                m_LimitTime -= Time.deltaTime;

                CheckLevelCondition();
            }
        }

        private void CheckLevelCondition()
        {
            if (m_Conditions == null || m_Conditions.Length == 0)
                return;

            int numCompeted = 0;

            foreach (var v in m_Conditions)
            {
                if (v.IsComleted)
                    numCompeted++;
            }

            if (numCompeted == m_Conditions.Length)
            {
                m_IsLevelCompleted = true;
                m_EventLevelCompleted?.Invoke();

                LevelSequenceController.Instance?.FinishCurrentLevel(true);
            }

            if (m_LimitTime <= 0)
            {
                m_IsLevelCompleted = true;
                m_EventLevelCompleted?.Invoke();

                LevelSequenceController.Instance?.FinishCurrentLevel(false);
            }
        }

    }
}
