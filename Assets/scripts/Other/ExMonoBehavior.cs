﻿using UnityEngine;
using System.Collections;

public class ExMonoBehavior : MonoBehaviour {

	    ////////////////////////
	   ////                ////
	  ////   Properties   ////
	 ////                ////
	////////////////////////

	  ////////////////////////
	 //  public            //
	////////////////////////

	// TODO: find a way to make this protected
	public static GameManager gameManager;

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

	protected T checkForComponent<T>(bool addIfNotFound = false) where T: Component {
		T comp = gameObject.GetComponent<T> ();

		if (comp == null) {
			//			string name = typeof(T).Name;

			if(addIfNotFound) {
				//				Debug.LogWarning("No " + name + " component found on object, creating new " + name + ".");
				comp = gameObject.AddComponent<T>();
				//			} else {
				//				Debug.LogWarning("No " + name + " component found on object.");
			}
		}

		return comp;
	}
	  ////////////////////////
	 //  private           //
	////////////////////////

}
