using UnityEngine;
using System.Collections;
using System.Linq;

public class SpawnScript : MonoBehaviour {
    System.Random rand = new System.Random();
    public int numberOfEnemies { get
        {
            return enemies.Count;
        } }
    int minZ = 5;
    int maxZ = 10;
    int minX = 5;
    int maxX = 10;

    public GameObject player;
    public GameObject enemy;

    ArrayList enemies = new ArrayList();
    public int maxAmountOfEnemies;
    Animator anim;

    ArrayList spawnPoints = new ArrayList() { };

	// Use this for initialization
	void Start ()
    {
        var elements = GameObject.FindGameObjectsWithTag("Respawn").ToList();
        //        player = GameObject.FindGameObjectWithTag("Player");
        //int numberOfEnemies = rand.Next(10, 20);
        for (int i = 0; i < elements.Count; i++)
            Spawn(elements[i]);
    }

    void Spawn(GameObject respawn) { 
        if (enemies.Count >= maxAmountOfEnemies)
            return;
        var enemy = Instantiate(this.enemy);

        enemy.transform.position = respawn.transform.position;
    }

    public void DeleteEnemy(GameObject enemy)
    {
        int index = enemies.IndexOf(enemy);
        if (index > -1)
            enemies.RemoveAt(index);
    }
}
