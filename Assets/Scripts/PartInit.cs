using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartInit : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.onGameStart += () => {this.enabled = true; Debug.Log("Good");}; // 게임 시작 시 활성화
        this.enabled = false; // 초기에는 비활성화
    }
}
