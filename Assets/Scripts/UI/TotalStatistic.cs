using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class TotalStatistic : SingletonBase<TotalStatistic>
    {
        private int m_TotalScore;
        public int TotalScore => m_TotalScore;
       
        private int m_AlienShipKills;
        public int AlienShipKills => m_AlienShipKills;

        private int m_NumberOfDeaths;
        public int NumberOfDeaths => m_NumberOfDeaths;

        public void RefreshStatistic(int kills, int scores)
        {
            m_TotalScore += scores;

            m_AlienShipKills += kills;                     
        }

        public void RefreshNumberOfDeaths()
        {
            ++m_NumberOfDeaths;
        }
    }
}
