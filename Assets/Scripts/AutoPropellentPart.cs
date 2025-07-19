using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPropellentPart : MonoBehaviour
{
    public float autoTime = 3f;
    void Start()
    {
        
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

        }
    }
}
