using System;
using UnityEngine;
namespace AngryCook
{
	public class Weapon
	{
		public static Weapon[] Initialise() {
			return new Weapon[]{
				new Weapon("Ham", 0, 320),
				new Weapon("Sausage", 0, 200),
				new Weapon("Coke", 0, 200),
				new Weapon("Pizza", 0, 400)
			};
		}

		public string name { get; set; }
		public int ammo { get; set; }
		public float bulletSpeed { get; set; }
		public float damage { set; get; }

		public Weapon (String name, int initialAmmo, float bulletSpeed)
		{
			this.name = name;
			this.ammo = initialAmmo;
			this.bulletSpeed = bulletSpeed;
			this.damage = damage;
		}

		public void addAmmo(int amount)
		{
			ammo += amount;
			Mathf.Clamp (amount, 0, 1000);
		}

		public bool takeAmmo()
		{
			if (ammo > 0) {
				ammo--;			
				return true;
			} 
			return false;
		}

		public override String ToString() {
			return name + " " + ammo;
		}
	 	
	}
}

