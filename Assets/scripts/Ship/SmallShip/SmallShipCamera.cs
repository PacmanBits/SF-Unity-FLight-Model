using UnityEngine;
using System.Collections;

public class SmallShipCamera : ShipCamera {

	protected SmallShip smallShip {
		get {
			return ship as SmallShip;
		}
	}

	protected override void updateCameraPosition() {
		
		// Simple follow
		cam.transform.position = cameraTarget.position;
		
		// Lag follow
		/*
		Vector3 pDiff = cameraTarget.position - cam.transform.position;

		if (pDiff.magnitude > 1)
			pDiff.Normalize ();

		cam.transform.position += pDiff / 2f;
		*/
		
	}
	
	protected override void updateCameraRotation() {
		// Camera rotate
		cam.transform.forward = cameraTarget.forward;

		// Look ahead
		cam.transform.Rotate (smallShip.smallControl.getHorizontalFraction() * lookAhead.x * transform.up + smallShip.smallControl.getVerticalFraction() * lookAhead.y * transform.right);		
	}
}
