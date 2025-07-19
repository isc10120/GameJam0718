using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPropellentPart : MonoBehaviour
{
    Rigidbody parentRb;      // 부모 Rigidbody
    public Vector3 localThrustDir;  // 로컬 기준 추진 방향
    public float thrustPower = 10f;
    public float useFuel = 1f;
    private KeyCode keyCode;

    void Start()
    {
        GameManager.Instance.onGameStart += () => { keyCode = GetComponent<PartDataManager>().keyCode; Debug.Log("Key Mapped: " + keyCode + " to " + name); };
        parentRb = GetComponentInParent<Rigidbody>();
        Debug.Log(parentRb);
        localThrustDir = new Vector3(0, transform.rotation.eulerAngles.z == 0 ? 90 : transform.rotation.eulerAngles.z, 0);
    }

    public float autoTime = 3f;
    
    private void OnEnable()
    {
        StartCoroutine(AutoPropellent());
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
