using UnityEngine;
using System.Collections;

public class SmallShipCrash : SmallShipComponent {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////
	
	public float damageFactor = 1.0f;

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////
	
	    ////////////////////////
	   ////                ////
	  ////    Methods     ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	  ////////////////////////
	 //  protected         //
	////////////////////////
	
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
	
	protected virtual void OnCollisionEnter(Collision collision) {
		float damage = collision.impulse.magnitude * damageFactor;
		ship.health.damage (damage);
		
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

	  ////////////////////////
	 //  private           //
	////////////////////////
}
