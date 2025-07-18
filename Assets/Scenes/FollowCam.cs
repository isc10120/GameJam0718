using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // 따라갈 대상
    public Vector3 fixedPosition; // 고정된 X, Z 좌표

    void Start()
    {
        // XZ는 현재 카메라 위치를 기준으로 고정
        fixedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        // Y축만 타겟을 따라감
        transform.position = new Vector3(fixedPosition.x, target.position.y, fixedPosition.z);
    }
}
