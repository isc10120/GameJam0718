using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingUI : MonoBehaviour
{
    
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset;
    void Update()
    {
        Debug.Assert(target != null, $"{this.name}: Target이 설정되지 않았습니다!");

        Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.transform.position + offset);
        transform.position = targetPosition;
    }
}
