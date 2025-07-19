using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // ���� ���
    float yPos;

    void Start()
    {
        // XZ�� ���� ī�޶� ��ġ�� �������� ����
        //fixedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yPos = target.position.y - transform.position.y;
    }

    void LateUpdate()
    {
        // Y�ุ Ÿ���� ����
        transform.position = new Vector3(transform.position.x, target.position.y - yPos, transform.position.z);
    }
}
