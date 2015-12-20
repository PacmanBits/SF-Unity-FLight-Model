using UnityEngine;
using System.Collections;

public class ShipCrash : ShipComponent {
	public float damageFactor = 1.0f;
	
	void OnCollisionEnter(Collision collision) {

		//Debug.Log (collision.impulse.magnitude);

		Ray aveNorm = averageNormal (collision.contacts);
		Vector3 reflect = Vector3.Reflect (transform.forward, aveNorm.direction);

		float damage = collision.impulse.magnitude * damageFactor;

		ship.health.damage (damage);

		//Debug.DrawRay (aveNorm.origin, collision.impulse * 10, Color.blue, 10);
		//Debug.DrawRay (aveNorm.origin, aveNorm.direction * 10, Color.green, 10);
		//ship.rb.AddForce (point.normal * 100);
		transform.forward = reflect;

		Debug.DrawRay (aveNorm.origin, aveNorm.direction, Color.white, 10);
		Debug.DrawRay (aveNorm.origin,transform.forward * -1, Color.green, 10);
		Debug.DrawRay (aveNorm.origin, reflect, Color.blue, 10);

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
