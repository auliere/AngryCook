using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float deltaRotate = 45 * Time.deltaTime;
        transform.Rotate(Vector3.one * deltaRotate);
	}
}
