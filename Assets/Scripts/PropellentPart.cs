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

    void Start()
    {
        GameManager.Instance.onGameStart += () => { keyCode = GetComponent<PartDataManager>().keyCode; Debug.Log("Key Mapped: " + keyCode + " to " + name); };
        GameManager.Instance.onGameStart += SettingPropellent;
    }
    

 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCode))
        {
            parentRb = GetComponentInParent<Rigidbody>();
            Debug.Log("plz");
            // 자식의 로컬 방향을 월드 방향으로 변환
            Vector3 worldThrustDir = transform.TransformDirection(localThrustDir);
            parentRb.AddForceAtPosition(worldThrustDir * thrustPower, transform.position);
            PlayerManager.Instance.FuelUpdate(useFuel);
        }

    }

    void SettingPropellent()
    {
        parentRb = GetComponentInParent<Rigidbody>();
        Debug.Log(parentRb);
        localThrustDir = new Vector3(0, 90, 0);//transform.rotation.eulerAngles.z == 0 ? 90 : transform.rotation.eulerAngles.z, 0);
    }

 
}
