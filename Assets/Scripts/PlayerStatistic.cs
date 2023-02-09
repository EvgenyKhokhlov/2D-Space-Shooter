using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PlayerStatistic : MonoBehaviour
    {
        public int numKills;
        public int scores;
        public int time;

        public void Reset()
        {
            numKills = 0;
            scores = 0;
            time = 0;
        }
    }
}
