﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheVRHead : MonoBehaviour {

	public Transform followHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(followHead.position.x -.7f, followHead.position.y - 1.2f, followHead.position.z);
	}
}
