using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInGame : MonoBehaviour
{

    private void Start() {
        if(tag == "LevelUP"){
            GameManager.Instance.onGameStart += () => {gameObject.SetActive(true);};
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rocket" && tag == "Enemy")
        {
            Debug.Log("Collision with Rocket and Enemy: " + gameObject.name);
            PlayerManager.Instance.durability -= 1;
            Destroy(gameObject);
        }
        
        if (other.tag == "Rocket" && tag == "LevelUP")
        {
            Debug.Log("LevelUP: " + ++ObstacleSpawner.Instance.level);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Rocket" && tag == "Ground")
        {
            Debug.Log("Collision with Rocket and Ground");
            GameManager.Instance.EndGame(); // 게임 종료
        }
    }
}
