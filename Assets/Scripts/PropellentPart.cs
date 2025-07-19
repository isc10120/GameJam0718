using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellentPart : Propellent
{
    private KeyCode keyCode;

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        keyCode = GetComponent<PartDataManager>().keyCode;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCode))
        {
            // 자식의 로컬 방향을 월드 방향으로 변환
            Vector3 worldThrustDir = transform.TransformDirection(localThrustDir);
            Debug.Log(parentRb);
            parentRb.AddForceAtPosition(worldThrustDir * thrustPower, transform.position);
            PlayerManager.Instance.FuelUpdate(useFuel);
        }

    }
}
