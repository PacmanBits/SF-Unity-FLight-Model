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

	private bool           stateSaved = false;

	// Use this for initialization
	void Start () {
		if (shaker == null)
			shaker = transform;
	}

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if (targetTime <= elapsedTime) {
			stopShaking ();
		}


	}

	public void shake(float duration = 0.5f) {
		startShaking (duration);
	}

	private void saveTransformState() {
		if (stateSaved)
			Debug.LogWarning ("A transform state was already saved and not reverted to.  Overwriting.");

		stateSaved = true;
		startState = getTransformState ();
	}

	private void restoreTransformState() {
		if (stateSaved) {
			setTransformState (startState);
			stateSaved = false;
		}
	}

	private TransformState getTransformState() {
		return new TransformState (transform);
	}

	private void setTransformState(TransformState state) {
		transform.position = state.position;
		transform.rotation = state.rotation;
	}

	private void startShaking(float duration) {
		targetTime  = duration ;
		elapsedTime = 0        ;
		
		enable ();
	}

	private void stopShaking() {
		restoreTransformState ();
		disable ();
	}

	private void disable() {
		enabled = false;
	}

	private void enable() {
		enabled = true;
	}
}
