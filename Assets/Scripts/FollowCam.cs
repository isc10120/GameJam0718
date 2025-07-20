using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public bool isEnd = false;
    public float smoothSpeed = 2f;
    public Transform target; // 따라갈 대상
    public float targetCameraY;
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
        if (isEnd)
        {
            float newY = Mathf.Lerp(transform.position.y, targetCameraY, Time.deltaTime * smoothSpeed);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // 목표 위치 거의 도달하면 부드러운 이동 멈춤
            if (Mathf.Abs(transform.position.y - targetCameraY) < 0.05f)
            {
                transform.position = new Vector3(transform.position.x, targetCameraY, transform.position.z);
                isEnd = false;
            }
        }
        else
            transform.position = new Vector3(transform.position.x, target.position.y - yPos, transform.position.z);

    }
}
