using UnityEngine;
using System.Collections;

public class SmallAvoidFlyToTarget : SmallShipPilot {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public Transform target;
	public Bounds avoidanceArea = new Bounds(new Vector3 (0, 0, 5), new Vector3 (5, 5, 10));

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////

	private Vector3 accumulatedDanger = Vector3.zero;
	private float dangerCount = 0;
	private BoxCollider avoidanceCollider;

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////
	 
	void Start() {
		avoidanceCollider = gameObject.AddComponent<BoxCollider> ();
		avoidanceCollider.isTrigger = true;
		avoidanceCollider.center = avoidanceArea.center;
		avoidanceCollider.size = avoidanceArea.size;
	}

	void LateUpdate() {
		dangerCount = 0;
		accumulatedDanger = Vector3.zero;
	}

	void OnTriggerStay(Collider other) {
		Vector3 diff = other.transform.position - transform.position;
		accumulatedDanger += diff;
		dangerCount ++;
		Debug.DrawLine (transform.position, other.transform.position, Color.magenta);

	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.magenta;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireCube(avoidanceArea.center, avoidanceArea.size);
	}

	    ////////////////////////
	   ////                ////
	  ////    Methods     ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////
	
	public override float getThrottleModifier() {
		return 1;
	}
	
	public override Vector2 getHeading() {
		if (target == null)
			return Vector2.zero;
		
		if (dangerCount > 0) {
			Vector3 averageDanger = accumulatedDanger / dangerCount;
			float flatAng = getFlatAngleFromForward(averageDanger);
			
			return new Vector3 (
				-1 * Mathf.Sign (flatAng),
				-1 * Mathf.Sign (averageDanger.y)
			);
		} else {
			Vector3 targetDirection = target.position - transform.position;
			float flatAng = getFlatAngleFromForward(targetDirection);

			return new Vector3 (
				Mathf.Sqrt (Mathf.Abs (flatAng) / 90) * Mathf.Sign (flatAng),
				targetDirection.y
			);
		}
	}
	

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////
	
	private Vector3 getFlat(Vector3 vec) {
		return Vector3.ProjectOnPlane (vec, Vector3.up);
	}

	private float getFlatAngleFromForward(Vector3 vec) {
		return getFlatAngle(getFlat (transform.forward), getFlat (vec));
	}

	private float getFlatAngle(Vector3 baseVec, Vector3 otherVec) {
		float flatAng = Quaternion.FromToRotation (getFlat(baseVec), getFlat(otherVec)).eulerAngles.y;
		
		if (flatAng > 180)
			flatAng -= 360;

		return flatAng;
	}
}

