using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // 따라갈 대상
    float yPos;

    void Start()
    {
        // XZ는 현재 카메라 위치를 기준으로 고정
        //fixedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yPos = target.position.y - transform.position.y;
    }

    void LateUpdate()
    {
        // Y축만 타겟을 따라감
        transform.position = new Vector3(transform.position.x, target.position.y - yPos, transform.position.z);
    }
}
