using UnityEngine;
using System.Collections;

public class SmallShipTarget : ExMonoBehavior {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public float fieldWidth = 100;
	public float fieldDepth = 100;

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

	void Start() {
		this.transform.position = newRandomPosition();
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<SmallShip> () != null)
			this.transform.position = newRandomPosition();
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

	private Vector3 newRandomPosition() {
		return new Vector3(
			Random.Range(gameManager.gameOrigin.x - fieldWidth / 2, gameManager.gameOrigin.x + fieldWidth / 2),
			Random.Range(gameManager.gameOrigin.y, gameManager.gameOrigin.y + gameManager.gameHeight),
			Random.Range(gameManager.gameOrigin.z - fieldDepth / -2, gameManager.gameOrigin.z + fieldDepth / 2)
		);
	}
}
