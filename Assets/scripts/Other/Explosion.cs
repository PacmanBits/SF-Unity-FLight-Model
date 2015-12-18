using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	ParticleSystem part;

	// Use this for initialization
	void Start () {
		part = GetComponent<ParticleSystem> ();

		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (part.IsAlive (true))
			Destroy (gameObject);
	}

	public void Explode() {
		if (!enabled) {
			enabled = true;
			part.Play();
		}
	}
}
