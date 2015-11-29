using UnityEngine;
using System.Collections;
using AngryCook;

public class FridgeController : MonoBehaviour {
    static System.Random rand = new System.Random();
    public ArrayList content;
    public GameObject player;
    public PlayerController controller;
    public Weapon[] weapons = Weapon.Initialise();


	// Use this for initialization
	void Start () {
        int n = rand.Next(weapons.Length) + 1;
        for(int i = 0; i < n; i++)
            weapons[rand.Next(weapons.Length)].ammo = rand.Next(20);
	}
	
	// Update is called once per frame
	void Update () {
        if (controller != null && Input.GetKeyDown(KeyCode.F)) {
            controller.addWeaponAmmo(weapons);
			controller.showMessage("Food taken!");
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].ammo = 0;
            }
        }
	}

    void OnTriggerEnter(Collider collider) {
        
        if(collider.gameObject.CompareTag("Player")) {
            controller = collider.gameObject.GetComponentInChildren<PlayerController>();
			controller.showMessage("Press F to take some food");
        }
    }

	void OnTriggerExit(Collider collider) {
        if(collider.gameObject.CompareTag("Player")) {
            controller = collider.gameObject.GetComponentInChildren<PlayerController>();
			controller.showMessage("");
        }
    }
}
