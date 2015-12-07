using UnityEngine;
using System.Collections;

public class ShipCamera : ShipComponent {
	// TODO: throw this out and start from scratch

	private Camera cam;
	private Rigidbody camRB;
	// Use this for initialization
	void Start () {
		base.Start ();

		cam = Camera.main;

		camRB = cam.GetComponent<Rigidbody> ();

		if (camRB == null)
			camRB = cam.gameObject.AddComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		cam.transform.forward = transform.forward;

		cam.transform.position = transform.position - transform.forward * 10;
	}
}
