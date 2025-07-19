using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellentPart : Propellent
{
    private KeyCode keyCode;

    protected override void Start()
    {
        base.Start();
        // keyCode = GetComponent<PartDataManager>().keyCode;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            // �ڽ��� ���� ������ ���� �������� ��ȯ
            Vector3 worldThrustDir = transform.TransformDirection(localThrustDir);
            parentRb.AddForceAtPosition(worldThrustDir * thrustPower, transform.position);
            PlayerManager.Instance.FuelUpdate(useFuel);
        }

    }
}
