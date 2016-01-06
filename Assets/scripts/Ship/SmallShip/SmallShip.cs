using UnityEngine;
using System.Collections;

public class SmallShip : Ship {
	public SmallShipPilot   smallPilot   { get; private set; }
	public SmallShipControl smallControl { get; private set; }
	public SmallShipEngine  smallEngine  { get; private set; }
	public SmallShipCamera  smallCam     { get; private set; }

	// Use this for initialization
	protected override void Awake () {
		smallEngine  = checkForComponent<SmallShipEngine>  (true) ;
		smallControl = checkForComponent<SmallShipControl> (true) ;
		smallPilot   = checkForComponent<SmallShipPilot>   (true) ;
		smallCam     = checkForComponent<SmallShipCamera>  (true) ;

		base.Awake ();
	}
}
