using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class ResultPanelController : SingletonBase<ResultPanelController>
    {
        [SerializeField] private Text m_Kills;
        [SerializeField] private Text m_Scores;
        [SerializeField] private Text m_TotalScores;
        [SerializeField] private Text m_Time;

        [SerializeField] private Text m_Result;

        [SerializeField] private Text m_ButtonNextText;

        private bool m_Success;

        private int m_ScoreMultiple = 1;
        private float m_ReferTime;

        private void Start()
        {
            m_ReferTime = LevelController.Instance.LimitTime;
            gameObject.SetActive(false);
        }

        public void ShowResults(PlayerStatistic levelResults, bool success)
        {
            CalculateBonus();

            gameObject.SetActive(true);

            m_Success = success;

            m_Result.text = success ? "Win" : "Lose";
            m_ButtonNextText.text = success ? "Next" : "Restart";

            m_Kills.text = "Kills : " + levelResults.numKills.ToString();
            m_Scores.text = "Scores : " + levelResults.scores.ToString() + " x" + m_ScoreMultiple.ToString();
            m_TotalScores.text = "Total scores : " + (levelResults.scores * m_ScoreMultiple).ToString();
            m_Time.text = "Time : " + levelResults.time.ToString();

            if(m_Success)
                TotalStatistic.Instance.RefreshStatistic(levelResults.numKills, (levelResults.scores * m_ScoreMultiple));

            Time.timeScale = 0;
        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);

            Time.timeScale = 1;

            if (m_Success)
            {
                LevelSequenceController.Instance.AdvanceLevel();
            }
            else
            {
                LevelSequenceController.Instance.RestartLevel();
            }
        }

        private void CalculateBonus()
        {
            if (m_ReferTime / LevelController.Instance.LimitTime < m_ReferTime / 2)           
                m_ScoreMultiple = 2;
            if (m_ReferTime / LevelController.Instance.LimitTime < m_ReferTime / 3)
                m_ScoreMultiple = 3;
            if (m_ReferTime / LevelController.Instance.LimitTime < m_ReferTime / 4)
                m_ScoreMultiple = 4;

        }
    }
}
