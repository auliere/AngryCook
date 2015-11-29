using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnScript : MonoBehaviour {
    System.Random rand = new System.Random();
    public int numberOfEnemies
    {
        get
        {
            return enemies.Count;
        }
    }

    public GameObject player;
    public GameObject enemy;

    ArrayList enemies = new ArrayList();
    public int maxAmountOfEnemies;
    Animator anim;

    public List<GameObject> spawnPoints = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn").ToList();
        for (int i = 0; i < spawnPoints.Count / 2; i++)
            Spawn(i + 1);
		Debug.Log (numberOfEnemies);
        RefreshEnemiesLeft();
    }

    void Spawn(int index) { 
        if (enemies.Count >= maxAmountOfEnemies)
            return;

        var enemy = Instantiate(this.enemy);
        var controller = enemy.GetComponent<EnemyActionScript>();
        
        controller.start = GameObject.Find("SpawnPoint_" + index + "_start");
        enemy.transform.position = controller.start.transform.position;
        controller.destination = GameObject.Find("SpawnPoint_" + index + "_end");

        enemies.Add (enemy);
    }

    public void DeleteEnemy(GameObject enemy)
    {
        int index = enemies.IndexOf(enemy);
        if (index > -1)
            enemies.RemoveAt(index);
        RefreshEnemiesLeft();
	}

    private void RefreshEnemiesLeft()
    {
        player.GetComponent<PlayerController>().setEnemiesLeft(numberOfEnemies);
    }
}
