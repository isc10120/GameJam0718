using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public Action onGameStart;  // 게임 시작 (로켓 발사 시작) 시 호출
    public GameObject rocket;
    public HashSet<GameObject> rocketParts {get; private set;} = new HashSet<GameObject>(); //수집된 파츠
    public HashSet<GameObject> attachedParts {get; private set;} = new HashSet<GameObject>(); //로켓에 부착된 파츠

    void Start()
    {
        
    }

    public void AttachRocketPart(GameObject part)
    {
        attachedParts.Add(part);
        rocketParts.Remove(part);
        part.transform.SetParent(rocket.transform); // 로켓의 자식으로 설정
        part.GetComponent<Rigidbody>().isKinematic = true; // 로켓에 부착된 파츠는 물리엔진 영향을 받지 않음
        part.tag = "Rocket";
    }

    public void DettachRocketPart(GameObject part)
    {
        attachedParts.Remove(part);
        rocketParts.Add(part);
        part.transform.SetParent(null); // 로켓의 자식에서 제거
        part.GetComponent<Rigidbody>().isKinematic = false; // 물리엔진 영향 받음
        part.tag = "Untagged"; // 태그 초기화
    }

    /// <summary>
    /// 게임 시작 (로켓 발사 시작)
    /// </summary>
    public void StartGame()
    {
        onGameStart?.Invoke();
        Debug.Log("Game Started");
    }
}
