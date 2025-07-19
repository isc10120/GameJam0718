using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public Action onGameReady;  // 게임 시작 전 호출 (데이터 설정 등)
    public Action onGameStart;  // 게임 시작 (로켓 발사 시작) 시 호출
    public Action onGameEnd;    // 게임 종료 시 호출
    public Action onGameReset;  // 게임 리셋 시 호출
    public GameObject rocket;  // 로켓 오브젝트!!
    public HashSet<GameObject> rocketParts = new HashSet<GameObject>(); //수집된 파츠
    public HashSet<GameObject> attachedParts = new HashSet<GameObject>(); //로켓에 부착된 파츠

    [SerializeField] GameObject startButton;
    [SerializeField] GameObject resetButton;
    [SerializeField] GameObject endPanel; // 게임 종료 UI 패널

    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(StartGame);
        resetButton.GetComponent<Button>().onClick.AddListener(ResetGame);
    }

    /// <summary>
    /// 게임 시작 (로켓 발사 시작)
    /// </summary>
    public void StartGame()  // 게임 시작 누를 시 호출
    {
        onGameReady?.Invoke();
        onGameStart?.Invoke();
        foreach (var part in rocketParts)
        {
            part.SetActive(false); // 파츠 비활성화
        }
        startButton.SetActive(false); // 시작 버튼 비활성화
        rocket.GetComponent<Rigidbody>().isKinematic = false; // 로켓 키네마틱 해제 (기본 활성화)
        Debug.Log("Game Started");
    }

    public void EndGame()  // 땅에 닿을 시 호출
    {
        onGameEnd?.Invoke();
        foreach (var part in attachedParts)
        {
            part.GetComponent<DragObject>().DettachRocketPart(); // 로켓에서 분리
        }

        // TODO: UI 띄우기
        endPanel.SetActive(true); // 게임 종료 UI 패널 활성화
        resetButton.SetActive(true); // 리셋 버튼 활성화
        Debug.Log("Game Ended");
    }

    public void ResetGame()  // 게임 리셋 버튼 누를 시 호출
    {
        onGameReset?.Invoke();
        foreach (var part in attachedParts)
        {
            Destroy(part); // 로켓에서 분리된 파츠 제거
        }
        rocket.transform.position = new Vector3(0f, -3f, 0f); // 로켓 위치 초기화
        rocket.GetComponent<Rigidbody>().isKinematic = true; // 로켓 키네마틱
        foreach (var part in rocketParts)
        {
            part.SetActive(true); // 파츠 활성화
            part.GetComponent<DragObject>().enabled = true; // 드래그 가능하도록 설정, 처음엔 disable
            part.transform.position = new Vector3(UnityEngine.Random.Range(5f, 5f), UnityEngine.Random.Range(0f, -3f), 0f); // 파츠 위치 초기화
        }
        endPanel.SetActive(false); // 게임 종료 UI 패널 비활성화
        resetButton.SetActive(false); // 리셋 버튼 비활성화
        startButton.SetActive(true); // 시작 버튼 활성화
        Debug.Log("Game Reset");
    }
}
