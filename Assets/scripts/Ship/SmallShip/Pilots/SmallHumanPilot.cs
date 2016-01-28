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
		if(SmallShip.Input.primaryFire.stay())
			GameObject.Instantiate(primary, ship.control.rollObj.transform.position, ship.control.rollObj.transform.rotation);
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
