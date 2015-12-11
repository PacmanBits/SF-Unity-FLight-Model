using UnityEngine;
using System.Collections;

public class ShipCamera : ShipComponent {
	public Transform cameraTarget;
	public Vector2 lookAhead = new Vector2(1, 1);

	private Camera cam;
	private Rigidbody camRB;

	protected override void Start () {
		base.Start ();

		if (cameraTarget == null)
			throw new MissingReferenceException ("No Camera Target specified");

		cam = Camera.main;
	}


	void Update () {
		cam.transform.forward = cameraTarget.forward;

		cam.transform.position = cameraTarget.position;

		cam.transform.Rotate (ship.control.getHorizontalFraction() * lookAhead.x * transform.up + ship.control.getVerticalFraction() * lookAhead.y * transform.right);
	}
}
