using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRelease : MonoBehaviour
{
    void Start(){
        enabled = false;
    }
    void Update()
    {
        if (Input.anyKeyDown) // 스페이스바를 눌렀을 때
        {
            Debug.Log("로켓 발사!");
            GameManager.Instance.rocket.GetComponent<Rigidbody>().isKinematic = false; // 로켓 물리엔진 활성화
            enabled = false; // 로켓 발사 후 스크립트 비활성화
        }
    }
}
