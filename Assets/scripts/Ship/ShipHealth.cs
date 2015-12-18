using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {

	public float health { get; private set; }
	public float maxHealth { get; private set; }
	public float healthFrac {
		get {
			return health / maxHealth;
		};
	}

	public float damage(float amount) {
		return heal (-1 * amount);
	}

	public float heal(float amount) {
		health += amount;
		return health;
	}
}
