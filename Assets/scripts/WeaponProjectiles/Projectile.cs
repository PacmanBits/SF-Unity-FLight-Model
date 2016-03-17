using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public GameObject shotBy {
		get;
		protected set;
	}

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

	void OnCollisionEnter(Collision collision) {
		hitSomething(collision);
	}

	    ////////////////////////
	   ////                ////
	  ////    Methods     ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public static Projectile create(Object basic, Vector3 position, Quaternion rotation, Vector3 initialV = default(Vector3), GameObject shotBy = null) {
		GameObject shot = Instantiate(basic, position, rotation) as GameObject;
		Projectile shotComp = shot.GetComponent<Projectile>();
		Rigidbody rb = shot.GetComponent<Rigidbody>();

		if(rb != null && initialV != default(Vector3))
			rb.velocity = initialV;

		if(shotComp != null)
			shotComp.shotBy = shotBy;

		return shotComp;
	}

	  ////////////////////////
	 //  protected         //
	////////////////////////

	protected virtual bool canHitShooter() {
		return true;
	}

	protected virtual void hitSomething(Collision collision) {
	}

	  ////////////////////////
	 //  private           //
	////////////////////////

}
