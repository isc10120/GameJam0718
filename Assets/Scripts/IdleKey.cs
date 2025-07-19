using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IdleKey : MonoBehaviour, IDropHandler
{
    Image image; // 이미지 컴포넌트
    Animator animator; // 애니메이터 컴포넌트
    Sprite defaultSprite; // 기본 스프라이트
    RuntimeAnimatorController idleAnimation; // 기본 애니메이션
    GameObject keyboard; // 키보드 오브젝트
    GameObject keyMapped = null;  // 매핑된 키 오브젝트

    void Start()
    {
        image = GetComponent<Image>();
        animator = GetComponent<Animator>();
        defaultSprite = image.sprite; // 기본 스프라이트 저장
        idleAnimation = animator.runtimeAnimatorController; // 기본 애니메이션 저장
        keyboard = GameObject.Find("KeyBoard"); // 키보드 오브젝트 찾기
        GameManager.Instance.onGameStart += () => { gameObject.SetActive(false); }; // 게임 시작 시 비활성화
        GameManager.Instance.onGameStart += () => { gameObject.SetActive(true); }; // 게임 시작 시 비활성화
        gameObject.SetActive(false); // IdleKey 오브젝트 비활성화
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (keyMapped != null) return; // 이미 매핑된 키가 있으면 무시
        keyMapped = eventData.pointerDrag; // 드래그된 키 오브젝트

        Debug.Log("Key Mapped: " + keyMapped.name);
        image.sprite = keyMapped.GetComponent<Image>().sprite; // 이미지 변경
        animator.runtimeAnimatorController = keyMapped.GetComponent<Animator>().runtimeAnimatorController;
        keyMapped.SetActive(false); // 드래그된 키 오브젝트 비활성화
        keyMapped.transform.SetParent(transform); // IdleKey의 자식으로 설정
    }

    public void ResetKey()
    {
        if (keyMapped == null) return;

        GetComponent<Image>().sprite = defaultSprite; // 기본 스프라이트로 초기화
        GetComponent<Animator>().runtimeAnimatorController = idleAnimation; // 기본 애니메이션으로 초기화
        keyMapped.SetActive(true); // 매핑된 키 오브젝트 활성화
        keyMapped.transform.SetParent(keyboard.transform); // 키보드의 자식으로 설정
        keyMapped.GetComponent<CanvasGroup>().blocksRaycasts = true; // 레이캐스트 허용
        keyMapped = null; // 매핑된 키 초기화
    }

    public bool isKeyMapped()
    {
        return (keyMapped != null); // 키가 매핑되었는지 여부
    }

    public KeyCode GetMappedKeyCode()
    {
        if (keyMapped != null)
        {
            return keyMapped.GetComponent<Key>().keyCode; // 매핑된 키의 KeyCode 반환
        }
        return KeyCode.None; // 매핑된 키가 없으면 None 반환
    }
}