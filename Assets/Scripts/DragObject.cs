using UnityEngine;
using System.Collections.Generic;
using System;

public class DragObject : MonoBehaviour
{
    private Camera cam;
    private bool isDragging = false;
    private float distance;
    [SerializeField] private GameObject keyMappingUI;
    IdleKey idleKey;

    public Action dettachAction; // 로켓에서 분리 시 호출

    void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        idleKey = keyMappingUI.GetComponent<IdleKey>();
        GameManager.Instance.onGameStart += () => {enabled = false;};
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag=="Rocket" && isDragging)
        {
            isDragging = false; // 로켓에 부착되면 드래그 중지
            AttachRocketPart();  // 로켓에 부착
            DragObject parent = other.gameObject.GetComponent<DragObject>();
            if (parent != null)
            {
                parent.dettachAction += DettachRocketPart;
            }
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        distance = Vector3.Distance(transform.position, cam.transform.position);
        DettachRocketPart(); // 드래그 시작 시 로켓에서 분리
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.GetPoint(distance);
            transform.position = new Vector3(point.x, point.y, transform.position.z);
        }
    }

    public void AttachRocketPart()
    {
        Debug.Log("Attach Rocket Part: " + gameObject.name);
        GameManager.Instance.attachedParts.Add(gameObject);
        GameManager.Instance.rocketParts.Remove(gameObject);
        gameObject.transform.SetParent(GameManager.Instance.rocket.transform); // 로켓의 자식으로 설정
        gameObject.GetComponent<Rigidbody>().isKinematic = true; // 로켓에 부착된 파츠는 물리엔진 영향을 받지 않음
        gameObject.tag = "Rocket";
        keyMappingUI.SetActive(true);
        // TODO: 로켓정보 수정 PlayerManager
    }

    public void DettachRocketPart()
    {
        dettachAction?.Invoke(); // 로켓에서 분리 시 호출
        dettachAction = null; // 이벤트 초기화
        GameManager.Instance.attachedParts.Remove(gameObject);
        GameManager.Instance.rocketParts.Add(gameObject);
        gameObject.transform.SetParent(null); // 로켓의 자식에서 제거
        gameObject.GetComponent<Rigidbody>().isKinematic = false; // 물리엔진 영향 받음
        gameObject.tag = "Part"; // 태그 초기화
        keyMappingUI.SetActive(false);
        idleKey.ResetKey(); // IdleKey로 초기화
        // TODO: 로켓정보 수정 PlayerManager
    }
}
