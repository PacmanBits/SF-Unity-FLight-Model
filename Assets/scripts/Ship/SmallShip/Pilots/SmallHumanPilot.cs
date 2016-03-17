using UnityEngine;
using System.Collections;

public class SmallHumanPilot : SmallShipPilot {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public GameObject primary;
	public Transform primaryMount;

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

	void Update() {
		Debug.DrawLine(primaryMount.position, primaryMount.position + Vector3.up);
		Debug.DrawLine(primaryMount.position, primaryMount.position + Vector3.forward);
		Debug.DrawLine(primaryMount.position, primaryMount.position + Vector3.right);

		if(SmallShip.Input.primaryFire.down())
			Projectile.create(primary, primaryMount.position, primaryMount.rotation, ship.rb.velocity.y * Vector3.up, gameObject);
	}
	
	    ////////////////////////
	   ////                ////
	  ////    Methods     ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////
	
	public override float getThrottleModifier() {
		if (SmallShip.Input.speedUp.down ())
			return 2;
		else if (SmallShip.Input.slowDown.down ())
			return 0.5f;
		else
			return 1;
	}
	
	public override Vector2 getHeading() {
		return new Vector2(
			SmallShip.Input.horizontalAxis(),
			SmallShip.Input.verticalAxis()
		);
	}

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////
}
