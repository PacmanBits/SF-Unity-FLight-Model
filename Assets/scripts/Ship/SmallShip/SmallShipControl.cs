using UnityEngine;
using System.Collections;

public class SmallShipControl : ShipControl {
	// TODO: smooth turning should maybe be its own controller
	public float maxRoll = 20;
	public float maxPitch = 10;
	public float horizontalAcceleration = 3;
	public float verticalAcceleration = 4;
	public float maxHorizontalVelocity = 3;
	public float maxVerticalVelocity = 3;
	public readonly float MIN_HEADING = -1;
	public readonly float MAX_HEADING = 1;
	
	public Transform   rollObj;
	
	public float horizontalVelocity { get; private set; }
	public float verticalVelocity   { get; private set; }
	
	protected override void Start () {
		base.Start ();
		
		horizontalVelocity = 0;
		verticalVelocity = 0;
		
		if (rollObj == null)
			throw new MissingReferenceException ("Ship requires that a valid roll object is specified,");
		
		if (!rollObj.IsChildOf (transform))
			Debug.LogWarning ("Roll object was specified, but was not a child of ship.");
	}
	
	public float getHorizontalFraction() {
		return horizontalVelocity / maxHorizontalVelocity;
	}
	
	public float getVerticalFraction() {
		return verticalVelocity / maxVerticalVelocity;
	}
	
	void Update () {
		Vector2 targetHeading = clampVector(ship.pilot.getHeading (), MIN_HEADING, MAX_HEADING);
		
		updateHorizontalAngularVelocity (targetHeading.x);
		updateVerticalVelocity (targetHeading.y);
		
		float vertVelFrac = getVerticalFraction ();
		float horzVelFrac = getHorizontalFraction ();
		
		Debug.DrawRay (transform.position, 5 * transform.right * horzVelFrac, Color.red);
		Debug.DrawRay (transform.position, 5 * transform.up * vertVelFrac, Color.green);
		
		rollObj.localRotation = Quaternion.Euler (-1 * vertVelFrac * maxPitch, 0, -1 * horzVelFrac * maxRoll);
		ship.rb.angularVelocity = horizontalVelocity * Time.deltaTime * Vector3.up;
		ship.rb.MovePosition(transform.position + new Vector3(0, verticalVelocity * Time.deltaTime, 0));
	}
	
	private void updateHorizontalAngularVelocity(float horizontalHeading) {
		float targetAngV = horizontalHeading * maxHorizontalVelocity;
		
		float delta = targetAngV - horizontalVelocity;
		horizontalVelocity += delta * horizontalAcceleration * Time.deltaTime;
	}
	
	private void updateVerticalVelocity(float verticalHeading) {
		float targetV = verticalHeading * maxVerticalVelocity;
		
		float delta = targetV - verticalVelocity;
		verticalVelocity += delta * verticalAcceleration * Time.deltaTime;
	}
}
