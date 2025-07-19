using UnityEngine;

public class ObstacleSpawner : SceneSingleton<ObstacleSpawner>
{
    public GameObject[] obstaclePrefabs; // 레벨에 따른 장애물 프리팹들
    public float spawnInterval = 1f;
    public float spawnRangeX = 10f;

    public int level = 0; // 현재 레벨. 따로 조정

    private float timer;

    void Start()
    {
        GameManager.Instance.onGameEnd += () => {level=0; enabled=false;};
        GameManager.Instance.onGameStart += () => {enabled=true;};
        enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
            return;

        int index = Mathf.Clamp(level, 0, obstaclePrefabs.Length - 1);
        GameObject prefabToSpawn = obstaclePrefabs[index];

        Vector3 spawnPosition = transform.position;
        spawnPosition.x += Random.Range(-spawnRangeX, spawnRangeX);
        spawnPosition.z = 0f;

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
