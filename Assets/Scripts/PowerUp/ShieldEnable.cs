using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class ShieldEnable : PowerUp
    {
        [SerializeField] private GameObject ShieldPrefab;

        protected override void OnPickedUp(SpaceShip ship)
        {
            Instantiate(ShieldPrefab, ship.transform);

            ship.ImmortalityActivate();

        }
    }
}
