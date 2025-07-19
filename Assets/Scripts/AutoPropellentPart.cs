using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPropellentPart : Propellent
{
    public float autoTime = 3f;
    
    private void OnEnable()
    {
        StartCoroutine(AutoPropellent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AutoPropellent()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoTime);
            Vector3 worldThrustDir = transform.TransformDirection(localThrustDir);
            parentRb.AddForceAtPosition(worldThrustDir * thrustPower, transform.position);
            PlayerManager.Instance.FuelUpdate(useFuel);
        }
    }
}
