using UnityEngine;
using System.Collections;

public class LargeShip : ExMonoBehavior {

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
