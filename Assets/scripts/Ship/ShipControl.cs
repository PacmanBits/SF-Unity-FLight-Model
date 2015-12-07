using UnityEngine;
using System.Collections;

public class ShipControl : ShipComponent {


	
	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 heading = ship.pilot.getHeading ();
		ship.rb.angularVelocity = new Vector3(0, heading.x, heading.y);
	}
}
