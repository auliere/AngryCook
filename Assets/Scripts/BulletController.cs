using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float lifetime;
	public float damage;

	void Awake(){
		Destroy (gameObject, lifetime);
	}

	void Update(){
		float deltaRotate = 45 * Time.deltaTime;
		transform.Rotate (Vector3.one * deltaRotate * 2);
	}

	void OnTriggerEnter(Collider other) {
		if(!other.gameObject.CompareTag("Player"))
			Destroy(gameObject);
	}

}
