using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartInit : MonoBehaviour
{
    protected virtual void Start()
    {
        GameManager.Instance.onGameStart += () => { if (GameManager.Instance.attachedParts.Contains(gameObject)) { this.enabled = true; Debug.Log("능력 활성화"); } }; // 게임 시작 시 활성화
        this.enabled = false; // 초기에는 비활성화
    }
}
