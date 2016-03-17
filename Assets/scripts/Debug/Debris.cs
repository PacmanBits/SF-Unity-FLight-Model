using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour
{
	public float field_density    = 0.25f ;
	public float fld_size         = 50f   ;
	public float fld_safe_zone    = 10f   ;
	public float min_size         = 1f    ;
	public float max_size         = 10f   ;
	public float percent_physical = 100f  ;
	public int   max_debris       = 100   ;

	public float maxInitialV      = 2     ;
	public float maxInitialT      = 1     ;

	public bool  give_rigid_body  = true  ;
	public float debris_density   = 0.2f  ;

	public Transform debris_prefab = null;

	void Start ()
	{
		if (fld_safe_zone >= fld_size)
			throw new UnityException ("Min radius must be less than max radius");

		if (debris_prefab == null)
			throw new MissingComponentException ("Must set a debris prefab");
		
		float fldArea = fieldVolume ();
		float areaTaken = 0f;

		int d;
		for (d = 0; d < max_debris && areaTaken / fldArea < field_density; d++)
		{
			float debArea = makeDebris();

			areaTaken += debArea;
		}

		if (d >= max_debris)
			Debug.LogWarning ("Hit maximum debris before reaching target density (target density " + field_density + ", final density " + (areaTaken / fldArea) + ")");
		else
			Debug.Log ("Finished populating debris field with final density " + (areaTaken / fldArea));
		//float field_area = 
	}

	private float makeDebris()
	{
		float scale = randomSize ();

		Transform deb = Instantiate (debris_prefab);
		deb.localScale = new Vector3(scale, scale, scale);
		deb.position = randomPointInField ();
		deb.rotation = randomRotation ();
		deb.parent = this.transform;
		float volume = sphereVolume (scale);

		if (give_rigid_body) {
			Rigidbody rb = deb.gameObject.AddComponent<Rigidbody> ();
			rb.mass = debris_density * volume;
			rb.useGravity = false;
			rb.drag = 0;

			rb.angularVelocity = maxInitialT * Random.rotation.eulerAngles / 360;
			rb.velocity = Random.onUnitSphere * Random.Range (0, maxInitialV);
		}

		return volume;
	}

	private Vector3 randomPointInField()
	{
		int rand = Random.Range (0, 3);
		
		switch (rand)
		{
			case 0:
				return new Vector3 ( randomPointOnSide (), randomDepth (),       randomPointOnSide () );
			case 1:
				return new Vector3 ( randomPointOnSide (), randomPointOnSide (), randomDepth ()       );
			default:
				return new Vector3 ( randomDepth (),       randomPointOnSide (), randomPointOnSide () );
		}
	}

	private Quaternion randomRotation()
	{
		return Random.rotation;
	}

	private float randomPointOnSide()
	{
		return Random.Range (fld_size / -2, fld_size / 2);
	}

	private float randomDepth()
	{
		return randomSign() * Random.Range (fld_safe_zone / 2, fld_size / 2);
	}

	private float randomSize()
	{
		return Random.Range (min_size, max_size);
	}

	private float randomSign()
	{
		return (Random.Range (0, 2) == 1 ? -1 : 1);
	}

	private float debrisvolume (float scale)
	{
		return sphereVolume (scale);
	}

	private float fieldVolume()
	{
		return cubeVolume (fld_size) - cubeVolume (fld_safe_zone);
	}

	private float cubeVolume(float side)
	{
		return Mathf.Pow (side, 3);
	}

	private float sphereVolume(float radius)
	{
		return (4 / 3) * Mathf.PI * Mathf.Pow (radius, 3);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(transform.position, new Vector3(fld_size, fld_size, fld_size));
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, new Vector3(fld_safe_zone, fld_safe_zone, fld_safe_zone));
	}
}
