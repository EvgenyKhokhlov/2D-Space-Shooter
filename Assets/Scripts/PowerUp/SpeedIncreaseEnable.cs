using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class SpeedIncreaseEnable : PowerUp
    {
        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.transform.GetComponent<SpeedIncrease>().IncreaseSpeed();
        }
    }
}
