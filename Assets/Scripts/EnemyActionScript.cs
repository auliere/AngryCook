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
    public GameObject start;
    public GameObject destination;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        var navAgent = GetComponent<NavMeshAgent>();

        //navAgent.velocity. = speed;
        //destination = GetDestination();

        navAgent.SetDestination(destination.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        if (!stanned)
            stanStart = Time.time;
        else
        {
            if (Time.time - stanStart >= stanDuration)
                stanned = false;
            return;
        }

        float deltaX = player.transform.position.x - gameObject.transform.position.x;
        float deltaY = player.transform.position.y - gameObject.transform.position.y;
        float deltaz = player.transform.position.z - gameObject.transform.position.z;

        //if (deltaX * deltaX + deltaY * deltaY + deltaz * deltaz <= range)
        //{
        //   Move();
        //}
        //else
        //{
        //    var agent = gameObject.GetComponent<NavMeshAgent>();
        //    var controller = gameObject.GetComponent<EnemyActionScript>();
        //    float dist = agent.remainingDistance;
        //    if (agent.remainingDistance <= 1 )
        //    {
        //        //
        //        agent.SetDestination(controller.start.transform.position);
        //        var tmp = controller.start;
        //        controller.start = controller.destination;
        //        controller.destination = tmp;
        //    }
        //}
    }

    void LateUpdate() {
        float deltaX = player.transform.position.x - gameObject.transform.position.x;
        float deltaY = player.transform.position.y - gameObject.transform.position.y;
        float deltaz = player.transform.position.z - gameObject.transform.position.z;

        if (deltaX * deltaX + deltaY * deltaY + deltaz * deltaz <= range)
        {
            Move();
        }
        else
        {
            var agent = gameObject.GetComponent<NavMeshAgent>();
            var controller = gameObject.GetComponent<EnemyActionScript>();
            float dist = agent.remainingDistance;
            if (agent.remainingDistance <= 1)
            {
                //
                agent.SetDestination(controller.start.transform.position);
                var tmp = controller.start;
                controller.start = controller.destination;
                controller.destination = tmp;
            }
        }
    }

    void Move ()
    {
        //Debug.Log("Moving");
        Vector3 v = player.transform.position;
        v.y += 0.5f;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, v, AttackSpeed * Time.deltaTime);
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

    void OnCollide(Collider collide) {


    }
 }
