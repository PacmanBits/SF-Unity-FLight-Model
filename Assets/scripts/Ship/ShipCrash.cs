using UnityEngine;
using System.Collections;

public class ShipCrash : ShipComponent {
	private int hits = 0;
	void OnCollisionEnter(Collision collision) {
		ContactPoint point = collision.contacts [0];

		Debug.DrawRay (point.point, point.normal * 10, Color.white, 1);
		ship.rb.AddForce (point.normal * 100);
		//transform.forward = point.normal;
		GetComponent<Shake> ().shake ();
	}
}
