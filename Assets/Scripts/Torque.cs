using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour {

	public Vector3 torque;
	public float torqueTime;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (torqueTime >= 0f) {
			rigidBody.AddTorque (torque);

			// Time.deltaTime will be the actual frame rate on the FixedUpdate loop
			torqueTime -= Time.deltaTime; 
		}

	}
}
