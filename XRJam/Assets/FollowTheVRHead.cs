using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheVRHead : MonoBehaviour {

	public Transform followHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(followHead.position.x - .3f, followHead.position.y - .7f, followHead.position.z);
	}
}
