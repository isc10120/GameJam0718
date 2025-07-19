using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 2f;        // 초당 이동 속도
    public float moveDuration = 3f;     // 총 이동 시간 (초)

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
            // X축으로 이동
            transform.position += (spriteRenderer.flipX? Vector3.right : Vector3.left) * moveSpeed * Time.deltaTime;

            // 시간 누적
            elapsedTime += Time.deltaTime;

            // 일정 시간 지나면 멈춤
            if (elapsedTime >= moveDuration)
            {
                isMoving = false;
            }
        }
    }

}
