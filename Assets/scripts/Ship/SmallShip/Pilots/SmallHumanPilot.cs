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
	
	public override float getThrottleModifier() {
		if (SmallShip.Input.speedUp())
			return 2;
		else if (SmallShip.Input.slowDown())
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
