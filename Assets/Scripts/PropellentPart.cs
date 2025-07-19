using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellentPart : MonoBehaviour
{

    Rigidbody parentRb;      // �θ� Rigidbody
    public Vector3 localThrustDir;  // ���� ���� ���� ����
    public float thrustPower = 10f;
    public float useFuel = 1f;
    private KeyCode keyCode;

    public float mainThrust = 1f;       // ���� ���� �⺻ ������
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
            // �ڽ��� ���� ������ ���� �������� ��ȯ

            //Vector3 worldThrustDir = transform.TransformDirection(localThrustDir);
            //parentRb.AddForceAtPosition(worldThrustDir * thrustPower, transform.position);
  

            Vector3 thrustPosition = transform.position;

            // 1. �׻� ���� ���� ���� ������ (���� ��ǥ ����)
            Vector3 upwardForce = Vector3.up * mainThrust;

            // 2. ����ü�� ���� ���⿡ ���� ���� �� (��: ���̳� �� ���� ����)
            Vector3 directionalForce = transform.up * sideThrust;

            // ���� ���� �ռ��� ����
            Vector3 finalForce = upwardForce + directionalForce;

            // �θ� Rigidbody�� ��ġ ��� �� ���ϱ�
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
