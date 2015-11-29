using UnityEngine;
using System.Collections;

public class CollectibleSpawnScript : MonoBehaviour {

    private int maxCollectibles;

    public GameObject collectible;
    
	// Use this for initialization
	void Start () {
        ArrayList floor = new ArrayList(GameObject.FindGameObjectsWithTag("Floor"));
        maxCollectibles = Random.Range(1,  floor.Count);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().setCollectiblesMax(maxCollectibles);

        for (int i = 0; i < maxCollectibles; i++)
        {
            int rnd = Random.Range(1, floor.Count);
            Vector3 coords = (floor[rnd] as GameObject).transform.position;
            floor.RemoveAt(rnd);
            coords.y += 1;

            GameObject obj = GameObject.Instantiate(collectible);
            obj.transform.position = coords;
        }
	}
	
}
