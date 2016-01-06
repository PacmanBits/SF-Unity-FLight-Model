using UnityEngine;
using System.Collections;

public class ShipCrash : ShipComponent {
	public float damageFactor = 1.0f;
	
	protected virtual void OnCollisionEnter(Collision collision) {
		float damage = collision.impulse.magnitude * damageFactor;
		ship.health.damage (damage);

	}

	// TODO: utility function
	protected Ray averageNormal(ContactPoint[] contacts) {
		Vector3 averageNormal = Vector3.zero;
		Vector3 averagePoint  = Vector2.zero;

		foreach (var contact in contacts) {
			averageNormal += contact.normal ;
			averagePoint  += contact.point  ;
		}

		return new Ray(averagePoint / contacts.Length, averageNormal / contacts.Length);
	}
}
