using UnityEngine;
using System.Collections;

public class SmallBasicLaser : MonoBehaviour {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public float maxLife = 10;
	public float speed = 1;
	public float damage = 10;

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

	void Update() {
		alive += Time.deltaTime;

		if (alive > maxLife) {
			die();
			return;
		}
		
		transform.position += speed * transform.forward;
	}

	void OnTriggerEnter(Collider other) {
		die(true);

		ShipHealth otherHealth = other.GetComponent<ShipHealth> ();

		if(otherHealth != null)
			otherHealth.damage(damage);
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

	  ////////////////////////
	 //  private           //
	////////////////////////

	private void die(bool explode = false) {
		Destroy(gameObject);
	}
}
