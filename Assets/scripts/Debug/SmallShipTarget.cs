using UnityEngine;
using System.Collections;

public class SmallShipTarget : MonoBehaviour {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	public Vector3 fieldSize = new Vector3(50, 50, 50);

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
			Random.Range(fieldSize.x / -2, fieldSize.x / 2),
			Random.Range(fieldSize.y / -2, fieldSize.y / 2),
			Random.Range(fieldSize.z / -2, fieldSize.z / 2)
		);
	}
}
