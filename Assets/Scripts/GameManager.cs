using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : SceneSingleton<GameManager>
{
    public Action onGameReady;  // 게임 시작 전 호출 (데이터 설정 등)
    public Action onGameStart;  // 게임 시작 (로켓 발사 시작) 시 호출
    public Action onGameEnd;    // 게임 종료 시 호출
    public Action onGameReset;  // 게임 리셋 시 호출
    public RocketRelease rocketRelease;
    public GameObject rocket;  // 로켓 오브젝트!!
    public HashSet<GameObject> rocketParts = new HashSet<GameObject>(); //수집된 파츠
    public HashSet<GameObject> attachedParts = new HashSet<GameObject>(); //로켓에 부착된 파츠

    [SerializeField] GameObject startButton;
    [SerializeField] GameObject resetButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject KeyBoardUI; // 키보드 UI
    [SerializeField] GameObject endPanel; // 게임 종료 UI 패널

    public List<GameObject> givenParts;
    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(StartGame);
        resetButton.GetComponent<Button>().onClick.AddListener(ResetGame);
        restartButton.GetComponent<Button>().onClick.AddListener(EndGame);

        Init();
    }

    /// <summary>
    /// 게임 시작 (로켓 발사 시작)
    /// </summary>
    public void StartGame()  // 게임 시작 누를 시 호출
    {
        onGameReady?.Invoke();
        onGameStart?.Invoke();
        onGameReady = null;
        onGameStart = null;
        foreach (var part in rocketParts)
        {
            part.SetActive(false); // 파츠 비활성화
        }
        foreach (var part in attachedParts)
        {
            Destroy(part.GetComponent<Rigidbody>()); // 로켓에 부착된 파츠의 Rigidbody 제거
        }
        startButton.SetActive(false); // 시작 버튼 비활성화
        KeyBoardUI.SetActive(false); // 키보드 UI 비활성화
        restartButton.SetActive(true);
        rocketRelease.enabled = true;

        Debug.Log("Game Started");
    }

    public void EndGame()  // 땅에 닿을 시 호출
    {
        endPanel.SetActive(true); // 게임 종료 UI 패널 활성화
        resetButton.SetActive(true); // 리셋 버튼 활성화
        restartButton.SetActive(false);
        onGameEnd?.Invoke();
        onGameEnd = null;

        HashSet<GameObject> _attachedParts = new HashSet<GameObject>(attachedParts);
        foreach (var part in _attachedParts)
        {
            part.AddComponent<Rigidbody>(); // Rigidbody 추가
            part.GetComponent<DragObject>().DettachRocketPart(); // 로켓에서 분리
            attachedParts.Add(part);
            rocketParts.Remove(part);
        }
        _attachedParts.Clear();

        // TODO: UI 띄우기
        
        Debug.Log("Game Ended");
    }

    public void ResetGame()  // 게임 리셋 버튼 누를 시 호출
    {
        SceneManager.LoadScene("Eon");
        Init();
    }

    void Init()
    {
        foreach(GameObject part in givenParts){
            rocketParts.Add(Instantiate(part));
        }
        foreach (var part in rocketParts)
        {
            part.GetComponent<CollisionInGame>().enabled = false;
            part.GetComponent<Rigidbody>().isKinematic = false;
            part.GetComponent<Collider>().isTrigger = false; 
            part.transform.position = new Vector3(UnityEngine.Random.Range(-8f, 8f), 0, 0f); // 파츠 위치 초기화
        }
        
        onGameReset?.Invoke();
        onGameReset = null;
        
        rocket.GetComponent<Rigidbody>().isKinematic = true; // 로켓 키네마틱

        endPanel.SetActive(false); // 게임 종료 UI 패널 비활성화
        resetButton.SetActive(false); // 리셋 버튼 비활성화
        startButton.SetActive(true); // 시작 버튼 활성화
        KeyBoardUI.SetActive(true); // 키보드 UI 활성화
        Debug.Log("Game Reset");
    }
}
