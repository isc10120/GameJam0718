using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Propellent : PartInit
{

    protected Rigidbody parentRb;      // �θ� Rigidbody
    public Vector3 localThrustDir;  // ���� ���� ���� ����
    public float thrustPower = 10f;
    public float useFuel = 1f;

     protected virtual void Start()
    {
        base.Start();
        Debug.Log("hi");
        parentRb = GetComponentInParent<Rigidbody>();
        localThrustDir = new Vector3(0, transform.rotation.eulerAngles.z == 0 ? 90 : transform.rotation.eulerAngles.z, 0);
    }

}
