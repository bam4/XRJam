using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour {

	public float timeToSelfDestruct;

	// Use this for initialization
	public void SelfDestructMethod () {
		StartCoroutine("StartSelfDestruct");
	}
	
	IEnumerator StartSelfDestruct () {
		yield return new WaitForSeconds(timeToSelfDestruct);
		Destroy(this.gameObject);
		yield return null;
	}
}
