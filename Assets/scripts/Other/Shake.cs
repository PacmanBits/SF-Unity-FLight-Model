using UnityEngine;
using System.Collections;


public class Shake : MonoBehaviour {
	private struct TransformState {
		public Vector3    position ;
		public Quaternion rotation ;

		public TransformState(Vector3 pos, Quaternion rot) {
			position = pos;
			rotation = rot;
		}

		public TransformState(Transform tran) {
			position = tran.position;
			rotation = tran.rotation;
		}
	}

	public Transform shaker;

	private float          elapsedTime ;
	private float          targetTime  ;
	private TransformState startState  ;

	private bool           shaking = false;

	// Use this for initialization
	void Start () {
		if (shaker == null)
			shaker = transform;
	}

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if (targetTime <= elapsedTime) {
			disable ();
		}


	}

	public void shake(float duration = 0.5f) {
	}

	private void saveTransformState() {
		if (startState == null)
			Debug.LogWarning ("A transform state was already saved and not reverted to.  Overwriting.");

		startState = getTransformState ();
	}

	private void revertTransformState() {
		if (!shaking) {
			setTransformState (startState);
			startState = null;
		}
	}

	private TransformState getTransformState() {
		return new TransformState (transform);
	}

	private void setTransformState(TransformState state) {
		transform.position = state.position;
		transform.rotation = state.rotation;
	}

	private void startShaking() {
		targetTime  = duration ;
		elapsedTime = 0        ;
		shaking     = true     ;
		
		enable ();
	}

	private void stopShaking() {
		shaking = false;

		disable ();
	}

	private void disable() {
		enabled = false;
	}

	private void enable() {
		enabled = true;
	}
}
