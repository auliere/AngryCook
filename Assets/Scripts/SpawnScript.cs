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
        for (int i = 0; i < elements.Count; i++)
            Spawn(elements[i]);
        RefreshEnemiesLeft();
    }

    void Spawn(GameObject respawn) { 
        if (enemies.Count >= maxAmountOfEnemies)
            return;
        var enemy = Instantiate(this.enemy);
		enemies.Add (enemy);
        enemy.transform.position = respawn.transform.position;
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
