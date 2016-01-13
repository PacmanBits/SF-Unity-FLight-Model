using UnityEngine;
using System.Collections;

public class SmallShipPilot : SmallShipComponent {
	protected SmallShip smallShip {
		get {
			return ship as SmallShip;
		}
	}
	
	public virtual float getThrottleModifier() {
		return 1;
	}
	
	public virtual Vector2 getHeading() {
		return new Vector2 (0, 0);
	}
}
