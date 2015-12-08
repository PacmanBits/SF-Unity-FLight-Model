using UnityEngine;
using System.Collections;

public class LevelBox : MonoBehaviour {

	public float size = 100;
	public float wallThickness = 1f;

	void Start () {
		makeWall (Vector3.forward);
		makeWall (Vector3.back);
		makeWall (Vector3.left);
		makeWall (Vector3.right);
		makeWall (Vector3.up);
		makeWall (Vector3.down);

	}

	private void makeWall(Vector3 dir) {
		Transform wall = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
		wall.parent = transform;
		wall.position = dir * size / 2;

		Vector3 posDir = makePos (dir);

		Vector3 inv = new Vector3(1, 1, 1) - posDir;

		wall.localScale = inv * size + posDir * wallThickness;
	}

	private Vector3 makePos(Vector3 vec) {
		Vector3 ret = new Vector3 ();
		ret.x = Mathf.Abs (vec.x);
		ret.y = Mathf.Abs (vec.y);
		ret.z = Mathf.Abs (vec.z);

		return ret;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, new Vector3(size, size, size));
	}
}
