using UnityEngine;
using System.Collections;

public class EnemyActionScript : MonoBehaviour {
    public float hungerLevel;
    public float hungerDelta2;
    public float damage;
    public float speed;
    public float range;
    public float AttackSpeed;
    public int experience;
    public bool stanned = false;
    public float stanStart;
    public float stanDuration;
        //public int 

	public int experience;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (!stanned)
            stanStart = Time.time;
        else
        {
            if (Time.time - stanDuration >= stanDuration)
                stanned = false;
            return;
        }

        float deltaX = player.transform.position.x - gameObject.transform.position.x;
        float deltaY = player.transform.position.y - gameObject.transform.position.y;
        float deltaz = player.transform.position.z - gameObject.transform.position.z;

        if (deltaX * deltaX + deltaY * deltaY + deltaz * deltaz <= range)
        {
            Move();
        }
    }

    void Move ()
    {
        //Debug.Log("Moving");
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, AttackSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider) {
        //Debug.Log(collider.gameObject.tag);
        switch (collider.gameObject.tag)
          {
            case "Bullet":
                float damage = collider.gameObject.GetComponent<BulletController>().damage;
                hungerLevel -= damage;
				
				if (hungerLevel <= 0)
                {
				player.GetComponent<PlayerController>().increaseExperience(experience);
                    SpawnScript spawner  = FindObjectOfType<SpawnScript>();
                    spawner.DeleteEnemy(gameObject);
                    Destroy(gameObject);
                }
                stanned = true;
                break;
         }
    }
 }
