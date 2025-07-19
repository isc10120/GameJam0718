using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public Action onGameReady;  // 게임 시작 전 호출 (데이터 설정 등)
    public Action onGameStart;  // 게임 시작 (로켓 발사 시작) 시 호출
    public GameObject rocket;
    public HashSet<GameObject> rocketParts = new HashSet<GameObject>(); //수집된 파츠
    public HashSet<GameObject> attachedParts = new HashSet<GameObject>(); //로켓에 부착된 파츠

    void Start()
    {
        
    }

    /// <summary>
    /// 게임 시작 (로켓 발사 시작)
    /// </summary>
    public void StartGame()
    {
        onGameReady?.Invoke();
        onGameStart?.Invoke();
        Debug.Log("Game Started");
    }
}
