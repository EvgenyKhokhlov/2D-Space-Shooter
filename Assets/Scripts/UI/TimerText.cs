using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        private void Update()
        {
            if (LevelController.Instance.LimitTime >= 0)
            {
                float minutes = Mathf.FloorToInt(LevelController.Instance.LimitTime / 60);
                float seconds = Mathf.FloorToInt(LevelController.Instance.LimitTime % 60 + 0.9f);
                timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            }

        }
    }
}