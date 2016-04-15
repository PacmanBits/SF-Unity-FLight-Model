using UnityEngine;
using System.Collections;

public class McBotter : MonoBehaviour
{
	public float fld_size         = 50f   ;
	public float fld_safe_zone    = 10f   ;

	public int   McCount          = 5     ;

	public Transform McPrefab = null;

	void Start ()
	{
		if (fld_safe_zone >= fld_size)
			throw new UnityException ("Min radius must be less than max radius");

		if (McPrefab == null)
			throw new MissingComponentException ("Must set a McSheen prefab");

		Transform target = GameObject.Find("El Poshivo").transform;

		for (int m = 0; m < McCount; m++)
		{
			GameObject mc = Instantiate(McPrefab).gameObject;
			mc.transform.position = randomPointInField();

			SmallAvoidFlyToTarget script = mc.GetComponent<SmallAvoidFlyToTarget>();

			if(script != null)
				script.target = target;
			else
				Debug.LogWarning("Could not find SmallAvoidFlyToTarget");
		}
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

	private float randomSign()
	{
		return (Random.Range (0, 2) == 1 ? -1 : 1);
	}
}
