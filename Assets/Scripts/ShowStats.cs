using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html
[ExecuteInEditMode]
public class ShowStats : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		// Mass is all about how hard is it to take something and to accelerate it
		// This will show how hard is it to accelerate the object around axis X,Y,Z
		// It has like it's got three types of mass around the three different axis
		// The x axis has the intermediate value, so the rotation will be unstable about this axis (intermediate axis theorem)

		Debug.Log (name + " intertia tensor " + rb.inertiaTensor);
		// Notes: 
		// - Mass is specified by the parent's Rigidbody (check
		// - Colliders distribute mass evenly
		// - Local axis must be aligned with symmetry (Local/Global buttons on the Editor)
		// - Inertia tensor calculated about Center Of Mass of the object

		// Scene 02 Cylinder
		// If two axis are equal then we do not have an unstable axis

		// Scene 03 Sphere
		// Calculate moment of inertia: https://en.wikipedia.org/wiki/List_of_moments_of_inertia
		// We have complete symmetry (3-axis) => It will be stable
		// I = (2*m*r^2) / 5 = 0.4
		// Why the calculation of I in 02 Cylinder doesnt match? 
		// - Unity says 1.2 and it should be 1.3 (m*L^2/12) according to the Maths
		// - Capsule collider vs Mesh Renderer (there are bits of mass missing)



//		Debug.Log (name + " COM " + rb.centerOfMass);
	}
}
