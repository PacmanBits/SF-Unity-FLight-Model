using UnityEngine;
using System.Collections;

public class ShipCamera : ShipComponent {
	public Transform cameraTarget;
	public Vector2 lookAhead = new Vector2(1, 1);

	protected Camera cam;

	private Color healthFGColor = new Color(1,    0, 0) ;
	private Color healthBGColor = new Color(0.5f, 0, 0) ;
	private float barLength     = 200                   ;
	private float barHeight     = 10                    ;

	protected override void Start () {
		if (cameraTarget == null)
			throw new MissingReferenceException ("No Camera Target specified");

		cam = Camera.main;

		base.Start ();
	}


	void Update () {
		updateCameraPosition ();
		updateCameraRotation ();
	}

	protected virtual void updateCameraPosition() {}

	protected virtual void updateCameraRotation() {}
	
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
