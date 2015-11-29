using UnityEngine;
using UnityEngine.UI;
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
    public float maxHealth;

	//Stats screens
	public Text healthText;
	public Text weaponMonitorText;
	public Text experienceText;
	public Text messageText;
	public Text enemyLeftText;

	private Rigidbody rb;
	private float health;
	private int experience;
	private string message;
	private int enemyLeft;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		InitializeWeapons ();
		health = maxHealth;
		showMessage ("");
	}
	
	void Update()
	{		
		if (Input.GetKeyUp (KeyCode.RightControl))
			FireCurrentWeapon ();
		if (Input.GetKeyUp (KeyCode.Tab))
			NextWeapon ();
		UpdateUI();
	}

	void UpdateUI()
	{
		healthText.text = "HP: " + Mathf.RoundToInt (health) + " / " + Mathf.RoundToInt (maxHealth);
		weaponMonitorText.text = "Food: " + weapons [currentWeapon].name + "\n" + "Count: " + weapons [currentWeapon].ammo;
		experienceText.text = "XP: " + experience;
		messageText.text = message;
		enemyLeftText.text = "Enemies left: " + enemyLeft;
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

	public void increaseExperience(int amount)
	{
		experience += amount;
	}

	public void showMessage(string message)
	{
		this.message = message;
	}

	public void setEnemiesLeft(int number) {
		this.enemyLeft = number;
	}

    void OnCollisionStay(Collision hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Enemy":
                var enemy = hit.collider.GetComponent<EnemyActionScript>();
                if (enemy.stanned)
                    return;

                health -= enemy.damage * Time.deltaTime;
                Debug.Log("Taking damage, health left: " + health);
                if (health <= 0)
                {
                    Time.timeScale = 0;
                    Debug.Log("Game Over, you are dead");
                    showMessage("Game Over, they ate you!");
                    //Destroy(gameObject);
                }
                break;
        }
    }

}
