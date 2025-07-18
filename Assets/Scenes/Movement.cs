using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigid;
    public float power;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigid.AddForce(Vector3.up * power);

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(h, 0f, 0f).normalized * speed;
        rigid.MovePosition(rigid.position + move * Time.fixedDeltaTime);
    }


}
