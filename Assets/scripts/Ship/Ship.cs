using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public Rigidbody   rb      { get; private set; }
	public ShipHealth  health  { get; private set; }
	public ShipPilot   pilot   { get; private set; }
	public ShipControl control { get; private set; }
	public ShipEngine  engine  { get; private set; }
	public ShipCamera  cam     { get; private set; }



	void Awake () {
		rb      = checkForComponent<Rigidbody>(true)  ;
		pilot   = checkForComponent<ShipPilot>(true)  ;
		health  = checkForComponent<ShipHealth>(true) ;
		engine  = checkForComponent<ShipEngine>()     ;
		control = checkForComponent<ShipControl>()    ;
		cam     = checkForComponent<ShipCamera>()     ;
	}

	private T checkForComponent<T>(bool addIfNotFound = false) where T: Component {
		T comp = gameObject.GetComponent<T> ();

		if (comp == null) {
			string name = "fakeType";

			if(addIfNotFound) {
				Debug.LogWarning("No " + name + " component found on ship, creating basic " + name + ".");
				comp = gameObject.AddComponent<T>();
			} else {
				Debug.LogWarning ("No " + name + " component found on ship.");
			}
		}

		return comp;
	}
}
