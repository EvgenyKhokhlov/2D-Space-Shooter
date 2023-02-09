using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private GameObject text;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            text.SetActive(true);
        }
    }
  
}
