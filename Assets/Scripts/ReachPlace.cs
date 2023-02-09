using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Collider2D))]
    public class ReachPlace : MonoBehaviour
    {
        [SerializeField] private LevelConditionReachPlace m_LevelConditionReachPlace;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Player.Instance.ActiveShip != null)
            {
                if (collision == Player.Instance.ActiveShip.transform.GetComponentInChildren<Collider2D>())
                {
                    m_LevelConditionReachPlace.m_Enter = true;
                }
            }
        }
    }
}
