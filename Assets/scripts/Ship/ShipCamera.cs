using UnityEngine;
using System.Collections;

public class ShipCamera : ShipComponent {
	public Transform cameraTarget;
	public Vector2 lookAhead = new Vector2(1, 1);

	private Camera cam;

	private Color healthFGColor = new Color(1,    0, 0) ;
	private Color healthBGColor = new Color(0.5f, 0, 0) ;
	private float barLength     = 200                   ;
	private float barHeight     = 10                    ;

	protected override void Start () {
		base.Start ();

		if (cameraTarget == null)
			throw new MissingReferenceException ("No Camera Target specified");

		cam = Camera.main;
	}


	void Update () {
		// Camera rotate
		cam.transform.forward = cameraTarget.forward;

		// Simple follow
		cam.transform.position = cameraTarget.position;

		// Lag follow
		/*
		Vector3 pDiff = cameraTarget.position - cam.transform.position;

		if (pDiff.magnitude > 1)
			pDiff.Normalize ();

		cam.transform.position += pDiff / 2f;
		*/

		// Look ahead
		cam.transform.Rotate (ship.control.getHorizontalFraction() * lookAhead.x * transform.up + ship.control.getVerticalFraction() * lookAhead.y * transform.right);
	}
	
	void OnGUI() {
		DrawQuad (new Rect (10, 10, barLength, barHeight), healthBGColor);
		DrawQuad (new Rect (10, 10, barLength * ship.health.healthFrac, barHeight), healthFGColor);
	}
	
	private void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
