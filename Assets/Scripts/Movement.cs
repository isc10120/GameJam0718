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

    public float maxUpwardSpeed = 10f;
    public FollowCam cam;

    bool startGame = false;
    public float gameTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.onGameReady += Timeset;
        GameManager.Instance.onGameReset += TimeReset;
    }

    public void Timeset()
    {
        startGame = true;
    }

    public void TimeReset()
    {
        startGame= false;
        gameTime = 0f;
    }

    void FixedUpdate()
    {
        if (PlayerManager.Instance.currentFuel <= 0)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        moveDirection = Vector3.zero;

        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Vector3 velocity = rb.velocity;

        // ���� Y�� ���� �ӵ��� ����
        if (velocity.y > maxUpwardSpeed)
        {
            velocity.y = maxUpwardSpeed;
            rb.velocity = velocity;
        }
    }

    private void Update()
    {
        rb.AddForce(Vector3.up * force);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        if(startGame)
        {
            gameTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            cam.isEnd = true;

        }
    }
}


