using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    System.Random rand = new System.Random();

    int minZ = 5;
    int maxZ = 10;
    int minX = 5;
    int maxX = 10;

    public GameObject player;
    public GameObject enemy;

    ArrayList enemies = new ArrayList();
    int numberOfEnemies = 0;
    int maxAmountOfEnemies = 20;
    Animator anim;

    ArrayList spawnPoints = new ArrayList() { };

	// Use this for initialization
	void Start ()
    {
//        player = GameObject.FindGameObjectWithTag("Player");
        numberOfEnemies = rand.Next(10, 20);
        for (int i = 2; i < numberOfEnemies+2; i++)
            Spawn(i);
    }

    void Spawn(int i) {
        if (enemies.Count >= maxAmountOfEnemies)
            return;
        var enemy = Instantiate(this.enemy);
        
        enemy.transform.position = new Vector3(
            player.transform.position.x + rand.Next(minX, maxX) * Mathf.Cos(i), 
            player.transform.position.y, player.transform.position.z + rand.Next(minX, maxX) * Mathf.Sin(i));
    }


	// Update is called once per frame
	void Update () {
	    
	}
}
