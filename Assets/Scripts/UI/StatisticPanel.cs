using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class StatisticPanel : MonoBehaviour
    {
        [SerializeField] private Text m_TotalScoresText;
        [SerializeField] private Text m_AlienShipKillsText;
        [SerializeField] private Text m_NumberOfDeathsText;

        private void Start()
        {
            gameObject.SetActive(false);
        }
        public void RefreshTextStatistic()
        {
            m_TotalScoresText.text = "Total scores: " + TotalStatistic.Instance.TotalScore.ToString();
            m_AlienShipKillsText.text = "Alien ship kills: " + TotalStatistic.Instance.AlienShipKills.ToString();
            m_NumberOfDeathsText.text = "Number of deaths: " + TotalStatistic.Instance.NumberOfDeaths.ToString();
        }
    }
}
