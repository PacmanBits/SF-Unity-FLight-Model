using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public Rigidbody   rb               { get; private set; }
	public ShipControl control          { get; private set; }
	public ShipEngine  engine           { get; private set; }
	public ShipPilot   pilot            { get; private set; }
	public ShipCamera  cameraController { get; private set; }



	void Awake () {
		rb               = gameObject.GetComponent<Rigidbody>   ();
		pilot            = gameObject.GetComponent<ShipPilot>   ();
		engine           = gameObject.GetComponent<ShipEngine>  ();
		control          = gameObject.GetComponent<ShipControl> ();
		cameraController = gameObject.GetComponent<ShipCamera>  ();
		
		if (rb == null) {
			Debug.LogWarning("No Rigidbody component found on ship, creating one.");
			rb = gameObject.AddComponent<Rigidbody>();
		}
		
		if (pilot == null) {
			Debug.LogWarning("No pilot component found on ship, creating dumb pilot.");
			pilot = gameObject.AddComponent<ShipPilot>();
		}
		
		if (engine == null)
			Debug.LogWarning ("No engine found on ship.");
		
		if (control == null)
			Debug.LogWarning ("No control found on ship.");
		
		if (cameraController == null)
			Debug.LogWarning ("No camera controller found on ship.");

	}
}
