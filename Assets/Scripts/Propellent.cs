using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Propellent : MonoBehaviour
{

    protected Rigidbody parentRb;      // 부모 Rigidbody
    public Vector3 localThrustDir;  // 로컬 기준 추진 방향
    public float thrustPower = 10f;
    public float useFuel = 1f;

     protected virtual void Start()
    {
        
        parentRb = GetComponentInParent<Rigidbody>();
        Debug.Log(parentRb);
        localThrustDir = new Vector3(0, transform.rotation.eulerAngles.z == 0 ? 90 : transform.rotation.eulerAngles.z, 0);
    }

}
