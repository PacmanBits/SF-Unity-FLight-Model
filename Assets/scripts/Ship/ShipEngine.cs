using UnityEngine;
using System.Collections;

public class ShipEngine : ShipComponent {

	public float velocity = 5f;
	public float minMultiplier = 0.5f;
	public float maxMultiplier = 2.0f;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		ship.rb.velocity = velocity * transform.forward * Mathf.Clamp(ship.pilot.getThrottleModifier (), minMultiplier, maxMultiplier);
	}
}
