using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public float xMargin = 1f; //���� ������

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

            // ȸ�� ����
            obj.transform.rotation = Quaternion.LookRotation(direction);

            // Rigidbody�� �پ� �־�� ��
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * power;
            }
        }
    }

    Vector3 GetTopScreenRandomPosition()
    {
        // Z ������ ���¿��� ȭ�� �¿� ���
        Vector3 screenTopLeft = new Vector3(0, Screen.height, 0);
        Vector3 screenTopRight = new Vector3(Screen.width, Screen.height, 0);

        Vector3 worldLeft = mainCamera.ScreenToWorldPoint(screenTopLeft);
        Vector3 worldRight = mainCamera.ScreenToWorldPoint(screenTopRight);

        float randomX = Random.Range(worldLeft.x - xMargin, worldRight.x + xMargin);
        
    

        return new Vector3(randomX, transform.position.y, 0);
    }
}
