using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDataManager : MonoBehaviour
{
    public int weight;  // 부품의 무게
    public int durability;  // 부품의 내구도
    [HideInInspector] public KeyCode keyCode; // 키 코드

    void Start()
    {
        GameManager.Instance.onGameReady += getKeyCode;
    }

    void getKeyCode()
    {
        keyCode = transform.Find("Canvas/IdleKey").GetComponent<IdleKey>().GetMappedKeyCode(); // 키 코드 설정
    }
}
