﻿using UnityEngine;
using System.Collections;

public class SmallShipControl : SmallShipComponent {
	public struct LockedAxis {
		public bool x;
		public bool y;
		public bool z;
		
		public LockedAxis(bool _x, bool _y, bool _z) {
			x = _x;
			y = _y;
			z = _z;
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
	
	public          LockedAxis lockedAxis             = new LockedAxis(false, false, false);
	
	// TODO: smooth turning should maybe be its own controller
	public          float      maxRoll                = 20 ;
	public          float      maxPitch               = 10 ;
	public          float      horizontalAcceleration = 3  ;
	public          float      verticalAcceleration   = 4  ;
	public          float      maxHorizontalVelocity  = 50 ;
	public          float      maxVerticalVelocity    = 20 ;
	public readonly float      MIN_HEADING            = -1 ;
	public readonly float      MAX_HEADING            = 1  ;
	
	public          Transform  rollObj;
	
	public          float      horizontalVelocity { get; private set; }
	public          float      verticalVelocity   { get; private set; }

	  ////////////////////////
	 //  protected         //
	////////////////////////
	
	protected SmallShip smallShip {
		get {
			return ship as SmallShip;
		}
	}

	  ////////////////////////
	 //  private           //
	////////////////////////

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////
	
	protected void Start () {
		horizontalVelocity = 0;
		verticalVelocity = 0;
		
		if (rollObj == null)
			throw new MissingReferenceException ("Ship requires that a valid roll object is specified,");
		
		if (!rollObj.IsChildOf (transform))
			Debug.LogWarning ("Roll object was specified, but was not a child of ship.");
	}
	
	private void Update () {
		Vector2 targetHeading = clampVector(ship.pilot.getHeading (), MIN_HEADING, MAX_HEADING);
		
		updateHorizontalAngularVelocity (targetHeading.x);
		updateVerticalVelocity (targetHeading.y);
		
		float vertVelFrac = getVerticalFraction ();
		float horzVelFrac = getHorizontalFraction ();
		
		Debug.DrawRay ( transform.position, 5 * transform.right * horzVelFrac, Color.red   );
		Debug.DrawRay ( transform.position, 5 * transform.up * vertVelFrac,    Color.green );
		
		rollObj.localRotation = Quaternion.Euler (-1 * vertVelFrac * maxPitch, 0, -1 * horzVelFrac * maxRoll);
		ship.rb.angularVelocity = horizontalVelocity * Time.deltaTime * Vector3.up;

		ship.rb.MovePosition(gameManager.clampPositionToField(transform.position + new Vector3(0, verticalVelocity * Time.deltaTime, 0)));
	}
	
	private void LateUpdate() {
		lockAxis (lockedAxis);
	}
	
	    ////////////////////////
	   ////                ////
	  ////    Methods     ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////
	
	public float getHorizontalFraction() {
		if(maxHorizontalVelocity == 0)
			return 0;
		
		return horizontalVelocity / maxHorizontalVelocity;
	}
	
	public float getVerticalFraction() {
		if(maxVerticalVelocity == 0)
			return 0;
		
		return verticalVelocity / maxVerticalVelocity;
	}

	  ////////////////////////
	 //  protected         //
	////////////////////////
	
	// TODO: should be in a utility class
	protected void lockAxis(LockedAxis axis) {
		ship.rb.MoveRotation(Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0));
	}
	
	// TODO: should be in a utility class
	protected Vector2 clampVector(Vector2 vec, float min, float max) {
		return new Vector2 (Mathf.Clamp (vec.x, min, max), Mathf.Clamp (vec.y, min, max));
	}

	  ////////////////////////
	 //  private           //
	////////////////////////
	
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
