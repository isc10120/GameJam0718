using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPower : MonoBehaviour
{
    public float duration = 2f;
    public float addFuel = 1f;
    IEnumerator GetSolarPower()
    {
        yield return new WaitForSeconds(duration);
        PlayerManager.Instance.FuelUpdate(-addFuel);
    }
}
