using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusEffect : MonoBehaviour {

	public float magnusConstant = 0.2f;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidBody.AddForce (magnusConstant*Vector3.Cross (rigidBody.angularVelocity, rigidBody.velocity));
	}
}
