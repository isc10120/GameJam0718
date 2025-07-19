using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellentPart : MonoBehaviour
{
    Rigidbody parentRb;      // �θ� Rigidbody
    public Vector3 localThrustDir;  // ���� ���� ���� ����
    public float thrustPower = 10f;

    void Start()
    {
        parentRb = GetComponentInParent<Rigidbody>();
        localThrustDir = new Vector3(0, transform.rotation.eulerAngles.z == 0 ? 90 : transform.rotation.eulerAngles.z, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            // �ڽ��� ���� ������ ���� �������� ��ȯ
            Vector3 worldThrustDir = transform.TransformDirection(localThrustDir);
            parentRb.AddForceAtPosition(worldThrustDir * thrustPower, transform.position);
        }

    }
}
