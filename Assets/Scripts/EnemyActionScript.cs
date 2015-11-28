using UnityEngine;
using System.Collections;

public class EnemyActionScript : MonoBehaviour {
    public float hungerLevel;
    public float hungerDelta2;
    public float demage;
    public float speed = 1;

    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        float deltaX = player.transform.position.x - gameObject.transform.position.x;
        float deltaY = player.transform.position.y - gameObject.transform.position.y;
        float deltaz = player.transform.position.z - gameObject.transform.position.z;

        if (deltaX * deltaX + deltaY * deltaY + deltaz * deltaz <= 1000)
        {
            Move();
            //Debug.Log("in range");
        }
        //else
           // Debug.Log("not in range");
    }

    void Move ()
    {
        //Debug.Log("Moving");
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider) {
          switch(collider.gameObject.tag)
          {
            case "Bullet":
                float damage = collider.gameObject.GetComponent<BulletController>().damage;
                Debug.Log("Decreasing hunger");
                hungerLevel -= damage;
				//Destroy(collider.gameObject);
				if (hungerLevel <= 0)
                {
                    Debug.Log("Enemy is dead");
                    Destroy(gameObject);
                }
                break;
            case "Player":
                var controller = collider.gameObject.GetComponentInChildren<PlayerController>();
                controller.health -= demage;
                if (controller.health <= 0)
                {
                    Destroy(player);
                    Debug.Log("Game Over, you are lost");
                }
                break;
         }
    }

 }
