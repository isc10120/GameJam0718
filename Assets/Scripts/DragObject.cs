using UnityEngine;
using System.Collections.Generic;

public class DragObject : MonoBehaviour
{
    private Camera cam;
    private bool isDragging = false;
    private float distance;

    void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        GameManager.Instance.onGameStart += () => {enabled = false;};
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag=="Rocket" && isDragging)
        {
            isDragging = false; // 로켓에 부착되면 드래그 중지
            GameManager.Instance.AttachRocketPart(gameObject);
        }
    }

    // private void OnCollisionExit(Collision other) {
    //     if (other.gameObject.CompareTag("Rocket"))
    //     {
    //         GameManager.Instance.DettachRocketPart(gameObject);
    //     }
    // }

    void OnMouseDown()
    {
        isDragging = true;
        distance = Vector3.Distance(transform.position, cam.transform.position);
        GameManager.Instance.DettachRocketPart(gameObject); // 드래그 시작 시 로켓에서 분리
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
}
