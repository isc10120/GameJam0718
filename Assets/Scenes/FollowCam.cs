using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // ���� ���
    public Vector3 fixedPosition; // ������ X, Z ��ǥ

    void Start()
    {
        // XZ�� ���� ī�޶� ��ġ�� �������� ����
        fixedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        // Y�ุ Ÿ���� ����
        transform.position = new Vector3(fixedPosition.x, target.position.y, fixedPosition.z);
    }
}
