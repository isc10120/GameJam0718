using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public float xMargin = 1f; //오차 허용범위

    public GameObject obstaclePrefab;
    public float power=2f;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            Spawn();
        }

        transform.position = new Vector3(0, PlayerManager.Instance.player.transform.position.y + 20f, 0);
    }

    public void Spawn()
    {
        if (true)//PlayerManager.Instance.player.transform.position.y < transform.position.y)
        {
            GameObject obj = Instantiate(obstaclePrefab, GetTopScreenRandomPosition(), Quaternion.identity);

            Vector3 direction = (PlayerManager.Instance.player.transform.position - transform.position).normalized;

            // 회전 설정
            obj.transform.rotation = Quaternion.LookRotation(direction);

            // Rigidbody가 붙어 있어야 함
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * power;
            }
        }
    }

    Vector3 GetTopScreenRandomPosition()
    {
        // Z 고정된 상태에서 화면 좌우 계산
        Vector3 screenTopLeft = new Vector3(0, Screen.height, 0);
        Vector3 screenTopRight = new Vector3(Screen.width, Screen.height, 0);

        Vector3 worldLeft = mainCamera.ScreenToWorldPoint(screenTopLeft);
        Vector3 worldRight = mainCamera.ScreenToWorldPoint(screenTopRight);

        float randomX = Random.Range(worldLeft.x - xMargin, worldRight.x + xMargin);
        
    

        return new Vector3(randomX, transform.position.y, 0);
    }
}
