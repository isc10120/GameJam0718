using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Cinemachine.DocumentationSortingAttribute;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public float force = 10f;
    public float rotationSpeed = 5f; // �������� �ӵ�

    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        moveDirection = Vector3.zero;

        bool isQ = Input.GetKey(KeyCode.Q);
        bool isE = Input.GetKey(KeyCode.E);

        if (isQ)
        {
            // ������ �� (���� ����ü �۵�)
            moveDirection += (transform.up + transform.right).normalized;
            //moveDirection += (Vector3.up + Vector3.right).normalized;
        }

        if (isE)
        {
            // ���� �� (������ ����ü �۵�)
            moveDirection += (transform.up - transform.right).normalized;
            //moveDirection += (Vector3.up + Vector3.left).normalized;
        }

        // �̵� �� ����
        if (moveDirection != Vector3.zero)
        {
            rb.AddForce(moveDirection * force);

            // ���� ����
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));


        }

        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
    

    //if (isQ || isE)
    //{
    //    rb.useGravity = false;
    //}
    //else
    //    rb.useGravity = true;
}

    public void AddForceRight()
    {
        rb.AddForce(transform.right);
    }

    public void AddForceLeft()
    {
        
    }
}


