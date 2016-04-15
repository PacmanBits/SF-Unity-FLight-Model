using UnityEngine;
using System.Collections;

public class LargeShipCrash : LargeShipComponent {

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
	
	protected virtual void OnCollisionEnter(Collision collision) {
		float maxImpulse = Mathf.Clamp(collision.impulse.magnitude, 0, 100);
		float damage = collision.impulse.magnitude * damageFactor;

		try {
			ship.health.damage (damage);
		} catch(System.Exception e) {
			Debug.LogWarning("Tried to set health, but ship hasn't initialized, yet");
		}
		
		//GetComponent<Shake> ().shake ();
		
	}

	  ////////////////////////
	 //  private           //
	////////////////////////
}
