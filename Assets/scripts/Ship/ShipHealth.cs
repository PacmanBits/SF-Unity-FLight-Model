using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {
	
	public float maxHealth = 100;

	public float health { get; private set; }
	public float healthFrac {
		get {
			return health / maxHealth;
		}
	}

	public GameObject explosion;

	private Color healthFGColor = new Color(1,    0, 0) ;
	private Color healthBGColor = new Color(0.5f, 0, 0) ;
	private float barLength     = 200                   ;
	private float barHeight     = 10                    ;

	void Start() {
		health = maxHealth;
	}

	void OnGUI() {
		DrawQuad (new Rect (0, 0, barLength,              barHeight), healthBGColor);
		DrawQuad (new Rect (0, 0, barLength * healthFrac, barHeight), healthFGColor);
	}

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
	
	private void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
