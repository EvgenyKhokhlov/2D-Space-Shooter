using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceShooter
{
    public class LevelConditionReachPlace : MonoBehaviour, ILevelCondition
    {
        public bool m_Enter = false;

        private bool m_Reached;

        bool ILevelCondition.IsComleted
        {
            get
            {
                if (m_Enter)
                {
                    m_Reached = true;
                }
                return m_Reached;
            }
        }
    }
}
