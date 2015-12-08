using UnityEngine;
using System.Collections;

public class ShipComponent : MonoBehaviour {
	protected Ship ship;

	protected virtual void Start () {
		ship = gameObject.GetComponent<Ship> ();
		
		if (ship == null) {
			Debug.LogWarning("No Ship component found on ship, creating one.");
			ship = gameObject.AddComponent<Ship>();
		}
	}
}
