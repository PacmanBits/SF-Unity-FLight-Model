using UnityEngine;
using System.Collections;

public class LargeShip : ExMonoBehavior {

	public static class Input {
		public static float horizontalAxis() {
			if (UnityEngine.Input.GetKey (KeyCode.A))
				return -1;

			if (UnityEngine.Input.GetKey (KeyCode.D))
				return 1;

			return 0;
		}

		public static float verticalAxis() {
			if (UnityEngine.Input.GetKey (KeyCode.S))
				return -1;

			if (UnityEngine.Input.GetKey (KeyCode.W))
				return 1;

			return 0;
		}
	}

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public float            mass = 1000;

	public Rigidbody        rb      { get; private set; }
	public ShipHealth       health  { get; private set; }

	public LargeShipPilot   pilot   { get; private set; }
	public LargeShipControl control { get; private set; }
	public LargeShipEngine  engine  { get; private set; }
	public LargeShipCamera  cam     { get; private set; }
	public LargeShipCrash   crash   { get; private set; }

	public bool             ready   { get; private set; }

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

	protected virtual void Awake () {
		rb      = checkForComponent<Rigidbody>(true)  ;
		health  = checkForComponent<ShipHealth>(true) ;
		
		pilot   = checkForComponent<LargeShipPilot>(true)  ;
		control = checkForComponent<LargeShipControl>()    ;
		engine  = checkForComponent<LargeShipEngine>()     ;
		cam     = checkForComponent<LargeShipCamera>()     ;
		crash   = checkForComponent<LargeShipCrash>(true)  ;

		rb.mass = mass;
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		ready   = true ;
	}
	
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

	  ////////////////////////
	 //  private           //
	////////////////////////
}
