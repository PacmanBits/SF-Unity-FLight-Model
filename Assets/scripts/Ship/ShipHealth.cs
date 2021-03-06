﻿using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////
	
	public float maxHealth = 100;
	
	public float health { get; private set; }
	public float healthFrac {
		get {
			return health / maxHealth;
		}
	}
	
	public GameObject explosion;

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////
	
	protected virtual void Start() {
		health = maxHealth;
	}

	    ////////////////////////
	   ////                ////
	  ////    Methods     ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////
	
	public float damage(float amount) {
		return setHealth (health - amount);
	}
	
	public float heal(float amount) {
		return setHealth (health + amount);
	}
	
	public float setHealth(float amount) {

		health = Mathf.Clamp (amount, 0, maxHealth);
		
		if (health == 0)
			kill ();
		
		return 0;
	}
	
	public void kill() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	  ////////////////////////
	 //  protected         //
	////////////////////////

	  ////////////////////////
	 //  private           //
	////////////////////////
}
