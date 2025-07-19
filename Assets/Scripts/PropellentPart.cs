using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellentPart : MonoBehaviour
{

    Rigidbody parentRb;      // 부모 Rigidbody
    public Vector3 localThrustDir;  // 로컬 기준 추진 방향
    public float thrustPower = 10f;
    public float useFuel = 1f;
    private KeyCode keyCode;

    public float mainThrust = 1f;       // 위로 가는 기본 추진력
    public float sideThrust = 0.1f;

    void Start()
    {
        GameManager.Instance.onGameStart += getKeyCode;
        GameManager.Instance.onGameStart += SettingPropellent;
    }
    

 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCode))
        {
            parentRb = GetComponentInParent<Rigidbody>();
            //Debug.Log("plz");
            // 자식의 로컬 방향을 월드 방향으로 변환

            //Vector3 worldThrustDir = transform.TransformDirection(localThrustDir);
            //parentRb.AddForceAtPosition(worldThrustDir * thrustPower, transform.position);
  

            Vector3 thrustPosition = transform.position;

            // 1. 항상 위로 가는 메인 추진력 (월드 좌표 기준)
            Vector3 upwardForce = Vector3.up * mainThrust;

            // 2. 추진체의 로컬 방향에 따른 보조 힘 (예: 앞이나 옆 방향 기준)
            Vector3 directionalForce = transform.up * sideThrust;

            // 최종 힘은 합성된 형태
            Vector3 finalForce = upwardForce + directionalForce;

            // 부모 Rigidbody에 위치 기반 힘 가하기
            parentRb.AddForceAtPosition(finalForce, thrustPosition, ForceMode.Force);
            PlayerManager.Instance.FuelUpdate(useFuel);
        }

    }

    void SettingPropellent()
    {
        parentRb = GetComponentInParent<Rigidbody>();
        Debug.Log(parentRb);
        localThrustDir = Vector3.up;//new Vector3(0, 90, 0);//transform.rotation.eulerAngles.z == 0 ? 90 : transform.rotation.eulerAngles.z, 0);
        GameManager.Instance.onGameStart -= SettingPropellent;
    }

    void getKeyCode()
    {
        keyCode = GetComponent<PartDataManager>().keyCode; Debug.Log("Key Mapped: " + keyCode + " to " + name);
        GameManager.Instance.onGameStart -= getKeyCode;
    }

 
}
