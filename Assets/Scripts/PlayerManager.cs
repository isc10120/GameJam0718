using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : SceneSingleton<PlayerManager>
{
    public GameObject player;

    [Header("Info")]
    public float durability;
    public float weight;
    public float speed;

    public float maxFuel = 100f;
    public float currentFuel;
    public Image fuelFillImage;
    public float fuelFillSpeed = 0.5f;

    [Header("Distance")]
    public Image distanceImage;
    public RectTransform indicator;
    public float startY = 0f;       // 시작 위치 X
    public float endY = 100f;       // 끝 위치 X

    public float arrowMinY;    // 화살표가 시작할 UI Y 위치
    public float arrowMaxY = 330f;

    void Start()
    {
        arrowMinY = indicator.anchoredPosition.y;
        currentFuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceUpdate();
        //FuelUpdate();
    }

    public void SetInitialFeul(float addFeul)
    {
        maxFuel += addFeul;
        currentFuel = maxFuel;
    }

    public void FuelUpdate(float consume)
    {
        if (fuelFillImage.fillAmount <= 1f)
        {
            currentFuel -= consume;
            //currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);

            fuelFillImage.fillAmount = currentFuel / maxFuel;
        }
    }

    void DistanceUpdate()
    {
        float currentY = player.transform.position.y;

        // 0 ~ 1 사이의 비율로 계산
        float progress = Mathf.InverseLerp(startY, endY, currentY);

        distanceImage.fillAmount = Mathf.Clamp01(progress); // 비율 값으로 설정

        float arrowY = Mathf.Lerp(arrowMinY, arrowMaxY, progress);
        Vector2 newPosition = indicator.anchoredPosition;
        newPosition.y = arrowY;
        indicator.anchoredPosition = newPosition;
    }

    public void SetPlayerInfo()
    {

        foreach (GameObject parts in GameManager.Instance.attachedParts)
        {
            PartDataManager data = parts.GetComponent<PartDataManager>();
            this.durability += data.durability;
            this.weight += data.weight;
            this.maxFuel += data.fuel;
            this.speed += data.speed;
            
        }

    }
}
