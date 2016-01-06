using UnityEngine;
using System.Collections;

public class SmallShipCrash : ShipCrash {
	
	protected SmallShip smallShip {
		get {
			return ship as SmallShip;
		}
	}
	
	protected override void OnCollisionEnter(Collision collision) {
		base.OnCollisionEnter (collision);

		Ray aveNorm = averageNormal (collision.contacts);
		Vector3 reflect = Vector3.Reflect (transform.forward, aveNorm.direction);
		
		//Debug.DrawRay (aveNorm.origin, collision.impulse * 10, Color.blue, 10);
		//Debug.DrawRay (aveNorm.origin, aveNorm.direction * 10, Color.green, 10);
		//ship.rb.AddForce (point.normal * 100);
		transform.forward = reflect;
		
		Debug.DrawRay (aveNorm.origin, aveNorm.direction, Color.white, 10);
		Debug.DrawRay (aveNorm.origin,transform.forward * -1, Color.green, 10);
		Debug.DrawRay (aveNorm.origin, reflect, Color.blue, 10);
		
		//GetComponent<Shake> ().shake ();
		
	}
}
