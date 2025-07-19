using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rocket" && gameObject.tag == "Enemy")
        {
            Debug.Log("Collision with Rocket and Enemy: " + gameObject.name);
            // TODO: PlayerManager.Instance 내구도 -1, 파괴연출?
            Destroy(gameObject);
        }
        if (other.tag == "Rocket" && gameObject.tag == "Part")
        {
            Debug.Log("Get Part: " + gameObject.name);
            GameManager.Instance.rocketParts.Add(gameObject);
            // 획득연출?
            this.enabled = false; // 더 이상 충돌 감지 안함
            gameObject.SetActive(false); // 파츠 획득 시 비활성화
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().isTrigger = false; // 물리엔진 활성화
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Rocket" && gameObject.tag == "Ground")
        {
            Debug.Log("Collision with Rocket and Ground");
            GameManager.Instance.EndGame(); // 게임 종료
        }
    }
}
