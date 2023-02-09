using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class SpeedIncrease : MonoBehaviour
    {
        private SpaceShip m_Ship;

        [SerializeField] private float SpeedIncreaseValue;

        [SerializeField] private float SpeedIncreaseTime;

        private float currentSpeed;

        private float timer;

        private bool timerActive;

        private void Start()
        {
            m_Ship = GetComponent<SpaceShip>();
        }

        private void Update()
        {
            if (timerActive)
                timer += Time.deltaTime;

            if (timer >= SpeedIncreaseTime)
            {
                m_Ship.SpeedChange(currentSpeed);

                timer = 0;

                timerActive = false;
            }
        }

        public void IncreaseSpeed()
        {
            timerActive = true;

            currentSpeed = m_Ship.MaxLinearVelocity;

            m_Ship.SpeedChange(SpeedIncreaseValue);
        }
    }
}
