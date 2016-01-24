using UnityEngine;
using System.Collections;

public class SmallShip : ExMonoBehavior {

	public static class Input {

		public static bool primaryFire() {
			return UnityEngine.Input.GetKey (KeyCode.Space);
		}
		
		public static bool secondaryFire() {
			return UnityEngine.Input.GetKey (KeyCode.LeftCommand);
		}

		public static bool speedUp() {
			return UnityEngine.Input.GetKey (KeyCode.LeftShift);
		}

		public static bool slowDown() {
			return UnityEngine.Input.GetKey (KeyCode.LeftControl);
		}

		public static float horizontalAxis() {
			if (UnityEngine.Input.GetKey (KeyCode.A))
				return -1;

			if (UnityEngine.Input.GetKey (KeyCode.D))
				return 1;
			
			return 0;
		}
		
		public static float verticalAxis() {
			if (UnityEngine.Input.GetKey (KeyCode.W))
				return -1;
			
			if (UnityEngine.Input.GetKey (KeyCode.S))
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

	public Rigidbody   rb      { get; private set; }
	public ShipHealth  health  { get; private set; }

	public SmallShipPilot   pilot   { get; private set; }
	public SmallShipControl control { get; private set; }
	public SmallShipEngine  engine  { get; private set; }
	public SmallShipCamera  cam     { get; private set; }

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
		
		pilot   = checkForComponent<SmallShipPilot>(true)  ;
		control = checkForComponent<SmallShipControl>()    ;
		engine  = checkForComponent<SmallShipEngine>()     ;
		cam     = checkForComponent<SmallShipCamera>()     ;
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
