using UnityEngine;
using System.Collections;

public class SmallBasicLaser : Projectile {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public float maxLife = 10f;
	public float speed = 1f;
	public float damage = 10f;
	public GameObject explosion;

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////

	private float alive = 0;

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////


	void Start() {
		GetComponent<Rigidbody>().velocity = speed * transform.forward;
	}


	void Update() {
		alive += Time.deltaTime;

		if (alive > maxLife) {
			die();
			return;
		}
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

	protected override void hitSomething(Collision collision) {
		die(true, Quaternion.LookRotation(averageNormal(collision.contacts).direction));

		ShipHealth otherHealth = collision.collider.GetComponentInParent<ShipHealth> ();

		if(otherHealth != null)
			otherHealth.damage(damage);
	}

	// TODO: UTILITY.  FUNCTION...
	protected Ray averageNormal(ContactPoint[] contacts) {
		Vector3 averageNormal = Vector3.zero;
		Vector3 averagePoint  = Vector2.zero;

		foreach (var contact in contacts) {
			averageNormal += contact.normal ;
			averagePoint  += contact.point  ;
		}

		return new Ray(averagePoint / contacts.Length, averageNormal / contacts.Length);
	}

	  ////////////////////////
	 //  private           //
	////////////////////////

	private void die(bool explode = false, Quaternion explosionAngle = default(Quaternion)) {
		if(explosionAngle == default(Quaternion))
			explosionAngle = Quaternion.identity;
		
		if(explode)
			Instantiate (explosion, transform.position, explosionAngle);
		
		Destroy(gameObject);
	}
}
