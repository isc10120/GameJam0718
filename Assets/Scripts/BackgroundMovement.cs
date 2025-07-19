using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 2f;        // �ʴ� �̵� �ӵ�
    public float moveDuration = 3f;     // �� �̵� �ð� (��)

    private float elapsedTime = 0f;
    private bool isMoving = true;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isMoving)
        {
            // X������ �̵�
            transform.position += (spriteRenderer.flipX? Vector3.right : Vector3.left) * moveSpeed * Time.deltaTime;

            // �ð� ����
            elapsedTime += Time.deltaTime;

            // ���� �ð� ������ ����
            if (elapsedTime >= moveDuration)
            {
                isMoving = false;
            }
        }
    }

}
