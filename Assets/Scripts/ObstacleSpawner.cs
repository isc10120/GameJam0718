using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public float xMargin = 1f; //오차 허용범위

    public GameObject[] obstaclePrefab;
    public float power=2f;

    public float spawnTime = 3f;

    public float level_1, level_2, level_3;

    public GameObject obj1, obj2, obj3; // 생성할 오브젝트들
    public float height1 = 5f; // A
    public float height2 = 10f; // B

    private float spawnTimer = 0f;
    private float currentInterval = 3f;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            // Spawn();
        }
        float y = transform.position.y;

        // y값에 따라 간격과 오브젝트 결정
        GameObject toSpawn = obj1;

        if (y < height1)
        {
            currentInterval = 3f;
            toSpawn = obj1;
        }
        else if (y < height2)
        {
            currentInterval = 2f;
            toSpawn = obj2;
        }
        else
        {
            currentInterval = 1f;
            toSpawn = obj3;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentInterval)
        {
            GameObject obj = Instantiate(toSpawn, GetTopScreenRandomPosition(), Quaternion.identity);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.down * power;
            }
            spawnTimer = 0f;
        }


        transform.position = new Vector3(0, PlayerManager.Instance.player.transform.position.y + 20f, 0);

    }

    //private void Start()
    //{

    //}

    //IEnumerator SpawnObstacle()
    //{
    //    while(true)
    //    {
    //        if(transform.position.y > level_3)
    //        {
    //            GameObject obj = Instantiate(obstaclePrefab[2], GetTopScreenRandomPosition(), Quaternion.identity);

    //            Rigidbody rb = obj.GetComponent<Rigidbody>();
    //            if (rb != null)
    //            {
    //                rb.velocity = Vector3.down * power;
    //            }
    //        }
    //        else if(transform.position.y < level_3 && transform.position.y > level_2 )
    //        {
    //            GameObject obj = Instantiate(obstaclePrefab[1], GetTopScreenRandomPosition(), Quaternion.identity);

    //            Rigidbody rb = obj.GetComponent<Rigidbody>();
    //            if (rb != null)
    //            {
    //                rb.velocity = Vector3.down * power;
    //            }
    //        }
    //        else
    //        {
    //            GameObject obj = Instantiate(obstaclePrefab[0], GetTopScreenRandomPosition(), Quaternion.identity);

    //            Rigidbody rb = obj.GetComponent<Rigidbody>();
    //            if (rb != null)
    //            {
    //                rb.velocity = Vector3.down * power;
    //            }
    //        }
    //        yield return new WaitForSeconds(spawnTime);
    //    }
    //}



    //public void Spawn()
    //{
    //    if (true)//PlayerManager.Instance.player.transform.position.y < transform.position.y)
    //    {
    //        //GameObject obj = Instantiate(obstaclePrefab, GetTopScreenRandomPosition(), Quaternion.identity);

    //       // Vector3 direction = (PlayerManager.Instance.player.transform.position - transform.position).normalized;

    //        // 회전 설정
    //      //  obj.transform.rotation = Quaternion.LookRotation(direction);

    //        // Rigidbody가 붙어 있어야 함
    //        Rigidbody rb = obj.GetComponent<Rigidbody>();
    //        if (rb != null)
    //        {
    //            rb.velocity = Vector3.down * power;
    //        }
    //    }
    //}

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
