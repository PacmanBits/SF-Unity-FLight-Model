using UnityEngine;
using System.Collections;

public class LargeShipCamera : LargeShipComponent {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public Transform cameraTarget;

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
	}

	protected virtual void LateUpdate () {
		updateCameraPosition ();
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

	protected virtual void updateCameraPosition() {
		cam.transform.position = cameraTarget.position;
		cam.transform.rotation = cameraTarget.rotation;
	}

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////

	private void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
