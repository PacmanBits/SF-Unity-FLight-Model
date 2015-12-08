using UnityEngine;
using System.Collections;

public class ShipControl : ShipComponent {

	public float maxRoll = 20;
	public readonly float MIN_HEADING = -1;
	public readonly float MAX_HEADING = 1;
	
	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 heading = clampVector(ship.pilot.getHeading (), MIN_HEADING, MAX_HEADING);
		ship.rb.angularVelocity = new Vector3(0, heading.x, heading.y);
		ship.rollObj.rotation = Quaternion.AngleAxis(-1 * heading.x * maxRoll, transform.forward);
	}

	private Vector2 clampVector(Vector2 vec, float min, float max) {
		return new Vector2 (Mathf.Clamp (vec.x, min, max), Mathf.Clamp (vec.y, min, max));
	}
}
