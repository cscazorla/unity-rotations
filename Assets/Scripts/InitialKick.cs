using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// What happens when I add this script to a GameObject that doesn't have a Rigidbody attached to it?
[RequireComponent (typeof(Rigidbody))] 
public class InitialKick : MonoBehaviour {
	
	public Vector3 initialKick = new Vector3 (4f, 0, 0);
	private Rigidbody rb;

	// We want to set the angular velocity on enable
	// This function is called just after the object is enabled (before any other script)
	// https://docs.unity3d.com/Manual/ExecutionOrder.html
	void OnEnable () {
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = initialKick;
	}
	
}
