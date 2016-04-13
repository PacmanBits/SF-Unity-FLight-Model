using UnityEngine;
using System.Collections;

public class SmallShipCamera : SmallShipComponent {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public Transform cameraTarget;
	public Vector2 lookAhead = new Vector2(1, 1);

	public float verticalCameraDrift = 2;

	public float positionDamping = 0.5f;
	public float rotationalDamping = 1;

	public Camera cam { get; protected set; }

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////
	
	private Color healthFGColor = new Color(1,    0, 0) ;
	private Color healthBGColor = new Color(0.5f, 0, 0) ;
	private float barLength     = 200                   ;
	private float barHeight     = 10                    ;

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////
	
	protected void Start () {
		if (cameraTarget == null)
			throw new MissingReferenceException ("No Camera Target specified");
		
		cam = Camera.main;

		// Interpolation is too expensive to put on every ship and, really, not necessary.  Smooth camera, however depends on it
		if(ship.ready)
			ship.rb.interpolation = UnityEngine.RigidbodyInterpolation.Interpolate;
		else
			Debug.LogWarning("Tried to change rigidbody interpolation but ship was not ready");
	}
	
	protected virtual void LateUpdate () {
		updateCameraPosition ();
		updateCameraRotation ();
	}
	
	private void OnGUI() {
		DrawQuad (new Rect (10, 10, barLength, barHeight), healthBGColor);
		DrawQuad (new Rect (10, 10, barLength * ship.health.healthFrac, barHeight), healthFGColor);
	}
	
	    ////////////////////////
	   ////                ////
	  ////    Methods     ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	  ////////////////////////
	 //  protected         //
	////////////////////////
	
	protected virtual void updateCameraPosition() {
		float verticalDrift = -gameManager.heightFraction(transform.position.y) * verticalCameraDrift;

		// Simple follow
		cam.transform.position = cameraTarget.position + Vector3.up * verticalDrift;

		// Lag follow
		//Vector3 target = cameraTarget.position + verticalDrift * Vector3.up;
		//Vector3 current = cam.transform.position;
		//Vector3 adjusted = Vector3.Lerp(current, target, Time.deltaTime / positionDamping);

		//cam.transform.position = adjusted;
	
	}
	
	protected virtual void updateCameraRotation() {
		float hrFrac = transformControlFractions(ship.control.getHorizontalFraction());
		float vrFrac = transformControlFractions(ship.control.getVerticalFraction());

		/*
		Quaternion target = cameraTarget.rotation * Quaternion.AngleAxis(lookAhead.x * hrFrac, Vector3.up);
		Quaternion current = cam.transform.rotation;
		Quaternion adjusted = Quaternion.Lerp(current, target, Time.deltaTime / rotationalDamping);

		Debug.Log(adjusted.eulerAngles - current.eulerAngles);

		cam.transform.rotation = adjusted;
		*/

		// Camera rotate
		cam.transform.forward = cameraTarget.forward;

		// Rotational lag
		cam.transform.RotateAround(transform.position, Vector3.up, -hrFrac * lookAhead.x);
		
		// Look ahead
		cam.transform.Rotate (hrFrac * lookAhead.x * transform.up - vrFrac * lookAhead.y * transform.right);
	}

	  ////////////////////////
	 //  private           //
	////////////////////////

	private float transformControlFractions(float frac) {
//		if(frac > 0.5)
//			return -Mathf.Cos(Mathf.PI * (2 * frac + 1)) + 1;
//		else if(frac < -0.5)
//			return Mathf.Cos(Mathf.PI * (2 * frac + 1)) - 1;
		if(frac < -0.25 || frac > 0.25)
			return Mathf.SmoothStep(0f, 1.0f, Mathf.Abs(frac) - 0.25f) * Mathf.Sign(frac);

		return 0;
	}
	
	private void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
