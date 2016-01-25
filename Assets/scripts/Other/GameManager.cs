using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
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

	    ////////////////////////
	   ////                ////
	  ////     Unity      ////
	 ////                ////
	////////////////////////

	protected virtual void Awake() {}
	protected virtual void Start() {}
	protected virtual void Update() {}

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
}

public static class InputManager {

	public interface IInputValue {
		bool down();
		bool up();
		bool stay();
		float value();
	}

	public static IInputValue getInputValueObj(KeyCode keyCode) {
		return new KeyValue (keyCode);
	}
	
	public static IInputValue getInputValueObj(int button) {
		return new MouseButtonValue (button);
	}

	public class KeyValue:IInputValue {
		private KeyCode key;

		public KeyValue(KeyCode keyCode) {
			key = keyCode;
		}

		public bool down() {
			return UnityEngine.Input.GetKeyDown (key);
		}

		public bool up() {
			return UnityEngine.Input.GetKeyUp (key);
		}

		public bool stay() {
			return UnityEngine.Input.GetKey (key);
		}

		public float value() {
			return UnityEngine.Input.GetKey (key) ? 1 : 0;
		}
	}
	
	public class MouseButtonValue:IInputValue {
		private int button;
		
		public MouseButtonValue(int mouseButton) {
			button = mouseButton;
		}
		
		public bool down() {
			return UnityEngine.Input.GetMouseButtonDown (button);
		}
		
		public bool up() {
			return UnityEngine.Input.GetMouseButtonUp (button);
		}
		
		public bool stay() {
			return UnityEngine.Input.GetMouseButton (button);
		}
		
		public float value() {
			return UnityEngine.Input.GetMouseButton (button) ? 1 : 0;
		}
	}
}
