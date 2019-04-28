using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNonKinematic : MonoBehaviour {

	Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
	}
	
	

	public void MakeNonKinematicMethod () {
		myRigidbody.isKinematic = false;
		myRigidbody.useGravity = true;
	}
}
