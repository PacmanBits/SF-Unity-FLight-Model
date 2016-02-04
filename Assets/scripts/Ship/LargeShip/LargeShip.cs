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

	public LargeShipPilot   pilot   { get; private set; }
	public LargeShipControl control { get; private set; }
	public LargeShipEngine  engine  { get; private set; }
	public LargeShipCamera  cam     { get; private set; }

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
