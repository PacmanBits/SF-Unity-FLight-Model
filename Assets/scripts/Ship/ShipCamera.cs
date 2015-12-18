using UnityEngine;
using System.Collections;

public class ShipCamera : ShipComponent {
	public Transform cameraTarget;
	public Vector2 lookAhead = new Vector2(1, 1);

	//public float maxSpeed = 2f;
	public float speedFactor = 0.5f;
	//public float rotationalLag = 0.5f;

	private Camera cam;
	private Rigidbody camRB;

	//private Vector3 vel = Vector3.zero;
	//private Vector3 acc = Vector3.zero;

	protected override void Start () {
		base.Start ();

		if (cameraTarget == null)
			throw new MissingReferenceException ("No Camera Target specified");

		cam = Camera.main;
		camRB = cam.gameObject.GetComponent<Rigidbody> ();

		if (camRB == null)
			camRB = cam.gameObject.AddComponent<Rigidbody> ();

		camRB.useGravity = false;
	}


	void Update () {
		cam.transform.forward = cameraTarget.forward;

		Vector3 pDiff = cameraTarget.position - cam.transform.position;

		//acc = pDiff * speedFactor;

		//vel += acc;

		//if (vel.magnitude > maxSpeed)
		//	vel = vel.normalized * maxSpeed;

		//camRB.velocity = pDiff * speedFactor;
		//cam.transform.position = pDiff * speedFactor;
		cam.transform.position = cameraTarget.position;

		//Vector3 rDiff = cameraTarget.forward - cam.transform.forward;
		//Debug.Log (rDiff);
		//cam.transform.forward = rDiff * rotationalLag;

		cam.transform.Rotate (ship.control.getHorizontalFraction() * lookAhead.x * transform.up + ship.control.getVerticalFraction() * lookAhead.y * transform.right);
	}
}
