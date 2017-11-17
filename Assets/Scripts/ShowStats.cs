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
		// https://en.wikipedia.org/wiki/Tennis_racket_theorem
		// Unity doesn't simulate this. Thats why we have created UnstableRotation

		Debug.Log (name + " intertia tensor " + rb.inertiaTensor);
		// Notes: 
		// - Mass is specified by the parent's Rigidbody (check)
		// - Colliders distribute mass evenly
		// - Local axis must be aligned with symmetry (Local/Global buttons on the Editor)
		// - Inertia tensor calculated about Center Of Mass of the object

		// Scene 02 Cylinder
		// If two axis are equal (I) then we do not have an unstable axis

		// Scene 03 Sphere
		// Calculate moment of inertia: https://en.wikipedia.org/wiki/List_of_moments_of_inertia
		// We have complete symmetry (3-axis) => It will be stable
		// I = (2*m*r^2) / 5 = 0.4 Unity calculates this right
		// Why the calculation of I in 02 Cylinder doesnt match? 
		// - Unity says 1.2 and it should be 1.3 (m*L^2/12) according to the Maths
		// - Capsule collider vs Mesh Renderer (there are bits of mass missing)



		// Scene 04 Parallel Axis Theorem
		// How does Unity calculate I for compound objects?
		// It always rotates around the center of the mass
		// https://en.wikipedia.org/wiki/Parallel_axis_theorem
		// Compare I when Man is an isolated object (125.8, 2.0, 125.8)
		// and when the Discus is attached (in the Hierarchy and collider) to it (99.8,22.0,115.7)
		// The Discus is contributing to I (I = I_0 + mr^2)
		// Also de Center of Mass is changing
		Debug.Log (name + " Center of Mass " + rb.centerOfMass);
		// Move the Discus around

		// If we enable now the Initiak Kick (0,2,0) Unity rotates the system around
		// the center of mass 



		// Scene 05 Torques
		// Tau = I * alpha    VS      F = m * a
		// https://www.4physics.com/phy_demo/newton/newton_rot.htm
		// https://www.4physics.com/phy_demo/newton/newton_rot2.htm
		// Apply Torque script to the sphere. Check out left hand rule. Angular Drag.

		// Duplicate the sphere. This one will have only 20kgs of mass
		// The same torque produces different results (the lower the mass the faster it accelerates)
		// I is different on each sphere so the resistance to acceleration is different.

		// How should I scale up the second ball to match the same I ?
		// I_sphere1 = 2/5 * m1 * r1^2 = 10
		// I_sphere2 = 2/5 * m2 * r2^2 = 2
		// (2.2354,2.2354,2.2354)
		// Now it gets the same acceleration




		// Scene 06 Magnus Effect
		// Football ball    W x V  => produces magnus effect
		// https://en.wikipedia.org/wiki/Magnus_effect
		// https://qph.ec.quoracdn.net/main-qimg-2758763144b4ed978f42cbdeb0d2a63b
		// Wolfram Alpha: [1,1,0]x[1,0,0]
		// https://www.wolframalpha.com/input/?i=%5B1,1,0%5Dx%5B1,0,0%5D

	}
}
