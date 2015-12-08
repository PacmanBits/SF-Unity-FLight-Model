﻿using UnityEngine;
using System.Collections;

public class HumanPilot : ShipPilot {

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	public override float getThrottleModifier() {
		if (Input.GetKey (KeyCode.LeftShift))
			return 2;
		else if (Input.GetKey (KeyCode.LeftCommand))
			return 0.5f;
		else
			return 1;
	}
	
	public override Vector2 getHeading() {
		Vector2 heading = Vector2.zero;
		
		if (Input.GetKey (KeyCode.LeftArrow))
			heading.x = -1;
		else if (Input.GetKey (KeyCode.RightArrow))
			heading.x = 1;
		
		if (Input.GetKey (KeyCode.DownArrow))
			heading.y = -1;
		else if (Input.GetKey (KeyCode.UpArrow))
			heading.y = 1;

		return heading;
	}
}