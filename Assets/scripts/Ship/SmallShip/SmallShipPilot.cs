using UnityEngine;
using System.Collections;

public class SmallShipPilot : ShipPilot {
	protected SmallShip smallShip {
		get {
			return ship as SmallShip;
		}
	}
}
