using UnityEngine;
using System.Collections;

public class ShipCrash : ShipComponent {

	void OnCollisionEnter(Collision collision) {
		GetComponent<Shake> ().shake ();
	}
}
