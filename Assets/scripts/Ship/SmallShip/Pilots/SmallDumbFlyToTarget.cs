using UnityEngine;
using System.Collections;

public class SmallDumbFlyToTarget : SmallShipPilot {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public Transform target;

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
		return 1;
	}
	
	public override Vector2 getHeading() {
//		Vector3 flatFwd = Vector3.ProjectOnPlane(transform.forward, Vector3.up);//
//		Vector3 flatDir = Vector3.ProjectOnPlane(target.position - transform.position, Vector3.up);
		Vector3 flatFwd = transform.forward;
		Vector3 flatDir = target.position - transform.position;
		flatFwd.y = 0;
		flatDir.y = 0;

		Debug.DrawRay (transform.position, flatFwd, Color.magenta);
		Debug.DrawRay (transform.position, flatDir, Color.cyan);

		float flatAng = Quaternion.FromToRotation (flatFwd, flatDir).eulerAngles.y;

		if (flatAng > 180)
			flatAng -= 360;

		//Debug.Log (Mathf.Sign (hDot - 2));
		return new Vector3(
			Mathf.Sqrt(Mathf.Abs(flatAng) / 180) * Mathf.Sign(flatAng),
//			Mathf.Pow(flatAng / 180, 2) * Mathf.Sign(flatAng),
//			flatAng / 180,
			target.position.y - transform.position.y
		);
	}

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////
}
