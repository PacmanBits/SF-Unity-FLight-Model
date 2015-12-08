using UnityEngine;
using System.Collections;

public class ShipControl : ShipComponent {

	public float maxRoll = 20;
	public readonly float MIN_HEADING = -1;
	public readonly float MAX_HEADING = 1;

	protected override void Start () {
		base.Start ();
	}

	void Update () {
		Vector2 heading = clampVector(ship.pilot.getHeading (), MIN_HEADING, MAX_HEADING);
		ship.rb.angularVelocity = new Vector3(0, heading.x, heading.y);

		ship.rollObj.localRotation = Quaternion.Euler (0, 0, -1 * heading.x * maxRoll);
		//ship.rollObj.localRotation = Quaternion.AngleAxis(-1 * heading.x * maxRoll, transform.forward);
	}

	private Vector2 clampVector(Vector2 vec, float min, float max) {
		return new Vector2 (Mathf.Clamp (vec.x, min, max), Mathf.Clamp (vec.y, min, max));
	}
}
