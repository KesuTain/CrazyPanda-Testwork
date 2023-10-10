using System.Collections.Generic;
using UnityEngine;

public class ShootBtn : MonoBehaviour
{
    [SerializeField] private List<Cannon> cannons;

    public void ShootAllCannons()
    {
        foreach (Cannon cannon in cannons)
            cannon.Shoot();
    }
}
