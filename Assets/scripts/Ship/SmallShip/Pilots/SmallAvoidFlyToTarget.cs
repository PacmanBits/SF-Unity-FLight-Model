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
	public float fullTurnAtAngle = 10;

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////

	private Color healthFGColor = new Color(1,    0, 0) ;
	private Color healthBGColor = new Color(0.5f, 0, 0) ;
	private float barLength     = 100                   ;
	private float barHeight     = 10                    ;

	private Vector3 accumulatedDanger = Vector3.zero;
	private float dangerCount = 0;
	private BoxCollider avoidanceCollider;

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////
	 
	protected override void Start() {
		base.Start ();

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

	private void OnGUI() {
		Vector3 myLoc = Camera.main.WorldToScreenPoint(transform.position);
		if(myLoc.z < 0)
			return;

		float dist = (Camera.main.gameObject.transform.position - transform.position).magnitude;

		float scale = dist / 50;

		//DrawQuad(new Rect(myLoc.x - 5, Screen.height - (myLoc.y - 5), 10, 10), Color.green);
		DrawQuad (new Rect (myLoc.x - barLength / (scale * 2), (Screen.height - myLoc.y) - 50 / scale, barLength / scale,                          barHeight / scale), healthBGColor);
		DrawQuad (new Rect (myLoc.x - barLength / (scale * 2), (Screen.height - myLoc.y) - 50 / scale, barLength * ship.health.healthFrac / scale, barHeight / scale), healthFGColor);
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
				Mathf.Sqrt (Mathf.Abs (flatAng) / fullTurnAtAngle) * Mathf.Sign (flatAng),
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

	private void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}

