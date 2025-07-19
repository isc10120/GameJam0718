using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : SceneSingleton<PlayerManager>
{
    public GameObject player;

    public Image fuelFillImage;
    public float fuelFillSpeed = 0.5f;

    public Image distanceImage;
    public RectTransform indicator;
    public float startY = 0f;       // ���� ��ġ X
    public float endY = 100f;       // �� ��ġ X

    public float arrowMinY;    // ȭ��ǥ�� ������ UI Y ��ġ
    public float arrowMaxY = 330f;

    void Start()
    {
        arrowMinY = indicator.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if (fuelFillImage.fillAmount < 1f)
        //{
        //    fuelFillImage.fillAmount += fuelFillSpeed * Time.deltaTime;
        //}

        float currentY = player.transform.position.y;

        // 0 ~ 1 ������ ������ ���
        float progress = Mathf.InverseLerp(startY, endY, currentY);

        distanceImage.fillAmount = Mathf.Clamp01(progress); // ���� ������ ����

        float arrowY = Mathf.Lerp(arrowMinY, arrowMaxY, progress);
        Vector2 newPosition = indicator.anchoredPosition;
        newPosition.y = arrowY;
        indicator.anchoredPosition = newPosition;
    }
}
