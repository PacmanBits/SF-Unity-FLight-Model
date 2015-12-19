using UnityEngine;
using System.Collections;

public class ShipCrash : ShipComponent {
	public float damageFactor = 1.0f;
	
	void OnCollisionEnter(Collision collision) {

		//Debug.Log (collision.impulse.magnitude);
		/*
		Ray aveNorm = averageNormal (collision.contacts);
		Debug.DrawRay (aveNorm.origin, aveNorm.direction, Color.green, 1f);

		float angle = Vector3.Angle (transform.forward, aveNorm.direction);

		Debug.Log (angle);

		Rigidbody otherRB = collision.rigidbody;
		*/

		float damage = collision.impulse.magnitude * damageFactor;

		ship.health.damage (damage);

		/*
		ContactPoint point = collision.contacts [0];

		Debug.DrawRay (point.point, point.normal * 10, Color.white, 1);
		ship.rb.AddForce (point.normal * 100);
		//transform.forward = point.normal;
		GetComponent<Shake> ().shake ();
		*/
	}

	private Ray averageNormal(ContactPoint[] contacts) {
		Vector3 averageNormal = Vector3.zero;
		Vector3 averagePoint  = Vector2.zero;

		foreach (var contact in contacts) {
			averageNormal += contact.normal ;
			averagePoint  += contact.point  ;
		}

		return new Ray(averagePoint / contacts.Length, averageNormal / contacts.Length);
	}
}
