using UnityEngine;
using AngryCook;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public GameObject[] weaponTypes;
	//weapon 0 = ham
	//weapon 1 = sausage
	//weapon 2 = Coke
	//weapon 3 = pizza

	private Weapon[] weapons;
	private int currentWeapon;
  public float health;

	private Rigidbody rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		InitializeWeapons ();
	}
	
	void Update()
	{		
		if (Input.GetKeyUp (KeyCode.RightControl))
			FireCurrentWeapon ();
		if (Input.GetKeyUp (KeyCode.Tab))
			NextWeapon ();

	}

	void FireCurrentWeapon()
	{
		Weapon currWeap = weapons [currentWeapon];
		if (currWeap.takeAmmo ()) {
			Vector3 pos = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z + 0.4f);
			GameObject clone = (GameObject) Instantiate (weaponTypes [currentWeapon], pos, transform.rotation);
			Rigidbody clonerb = clone.GetComponent<Rigidbody> ();
			clonerb.AddForce (transform.forward * currWeap.bulletSpeed);
		}
	}

	void NextWeapon()
	{
		if (currentWeapon < weapons.Length - 1) {
			currentWeapon += 1;
		} else 
			currentWeapon = 0;
		Debug.Log (weapons[currentWeapon].ToString());
	}

	public void InitializeWeapons() {
		weapons = Weapon.Initialise ();
		foreach (Weapon a in weapons) 
			a.addAmmo (20);
	}

	public void addWeaponAmmo(Weapon[] weapons) {
		for (int i = 0; i < this.weapons.Length; i++) {
			this.weapons[i].addAmmo(weapons[i].ammo);
		}
	}

}
