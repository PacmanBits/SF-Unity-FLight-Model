using UnityEngine;
using System.Collections;

public abstract class ShipControl : ShipComponent {
	public struct Vector3Bool {
		public bool x;
		public bool y;
		public bool z;

		public Vector3Bool(bool _x, bool _y, bool _z) {
			x = _x;
			y = _y;
			z = _z;
		}
	}

	public Vector3Bool lockedAxis = new Vector3Bool(false, false, false);
	
	protected virtual void LateUpdate() {
		lockAxis (lockedAxis);
	}

	// TODO: should be in a utility class
	protected void lockAxis(Vector3Bool axis) {

		ship.rb.MoveRotation(Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0));
	}

	// TODO: should be in a utility class
	protected Vector2 clampVector(Vector2 vec, float min, float max) {
		return new Vector2 (Mathf.Clamp (vec.x, min, max), Mathf.Clamp (vec.y, min, max));
	}
}
