using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceShooter
{
    public class Player : SingletonBase<Player>
    {
        [SerializeField] private int m_NumLives;
        [SerializeField] private SpaceShip m_Ship;
        [SerializeField] private GameObject m_PlayerShipPrefab;

        public SpaceShip ActiveShip => m_Ship;

        [SerializeField] private CameraController m_CameraController;
        [SerializeField] private MovementController m_MovementController;

        [SerializeField] int respawnTime;
        private float timer;
        private bool timerIsActive = false;

        protected override void Awake()
        {
            base.Awake();

            if (m_Ship != null)
                Destroy(m_Ship.gameObject);
        }

        private void Start()
        {
            Respawn();
        }
        private void Update()
        {
            if (timerIsActive) timer += Time.deltaTime;

            if ((int)timer >= respawnTime)
            {
                Respawn();
                TotalStatistic.Instance.RefreshNumberOfDeaths();
                timerIsActive = false;
                timer = 0;
            }

        }
        private void OnShipDeath()
        {
            m_NumLives--;

            if (m_NumLives > 0)
            {
                timerIsActive = true;              
            }
            else
                LevelSequenceController.Instance.FinishCurrentLevel(false);

        }
        private void Respawn()
        {
            if (LevelSequenceController.PlayerShip != null)
            {
                var newPlayerShip = Instantiate(LevelSequenceController.PlayerShip);

                m_Ship = newPlayerShip.GetComponent<SpaceShip>();
                m_Ship.EventOnDeath.AddListener(OnShipDeath);

                m_CameraController.SetTarget(m_Ship.transform);
                m_MovementController.SetTargetShip(m_Ship);
            }

        }

        #region Score

        public int Score { get; private set; }
        public int NumKill{ get; private set; }

        public void AddKill()
        {
            NumKill++;
        }

        public void AddScore(int num)
        {
            Score += num;
        }

        #endregion

    }
}