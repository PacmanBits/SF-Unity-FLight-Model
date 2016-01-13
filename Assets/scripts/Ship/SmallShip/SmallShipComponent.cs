using UnityEngine;
using System.Collections;

public class SmallShipComponent : ExMonoBehavior {
	protected SmallShip ship;
	
	protected virtual void Start () {
		ship = checkForComponent<SmallShip> (true);
	}
}
