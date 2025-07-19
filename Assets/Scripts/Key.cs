using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Key : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public KeyCode keyCode;  // 키 코드
    public Transform KeyboardTransform; // 키보드의 Transform

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        KeyboardTransform = transform.parent; // 키보드의 Transform을 가져옴
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 키 오브젝트를 키보드의 자식으로 설정
        gameObject.transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false; // 드래그 중일 땐 레이캐스트 막지 않음
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        
        if (!eventData.pointerEnter || !eventData.pointerEnter.GetComponent<IdleKey>() || eventData.pointerEnter.GetComponent<IdleKey>().isKeyMapped())
        {
            // 드래그 종료 시 키 오브젝트를 원래 위치로 되돌리기
            gameObject.transform.SetParent(KeyboardTransform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)KeyboardTransform);
        }
    }

}
