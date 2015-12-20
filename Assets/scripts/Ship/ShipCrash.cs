using UnityEngine;
using System.Collections;

public class ShipCrash : ShipComponent {
	public float damageFactor = 1.0f;
	
	void OnCollisionEnter(Collision collision) {

		//Debug.Log (collision.impulse.magnitude);

		Ray aveNorm = averageNormal (collision.contacts);

		float damage = collision.impulse.magnitude * damageFactor;

		ship.health.damage (damage);

		//Debug.DrawRay (aveNorm.origin, collision.impulse * 10, Color.blue, 10);
		//Debug.DrawRay (aveNorm.origin, aveNorm.direction * 10, Color.green, 10);
		//ship.rb.AddForce (point.normal * 100);
		//transform.forward = aveNorm.direction;
		GetComponent<Shake> ().shake ();

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
