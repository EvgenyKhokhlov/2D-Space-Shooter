using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionTime : MonoBehaviour, ILevelCondition
    {
        private float timeLimit;

        private bool m_Reached;

        private void Start()
        {
            timeLimit = LevelController.Instance.LimitTime;
        }

        bool ILevelCondition.IsComleted
        {           
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    if (LevelController.Instance.LevelTime > timeLimit)
                    {
                        m_Reached = true;
                    }
                }
                return m_Reached;
            }
        }
    }
}
