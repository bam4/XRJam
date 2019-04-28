using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballSpawner : MonoBehaviour {

	public GameObject Dodgeball;
	GameObject spawnedDodgeball;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.GetChildCount() == 0) {
			spawnedDodgeball = Instantiate(Dodgeball, this.transform.position, Quaternion.identity);
			spawnedDodgeball.transform.SetParent(this.transform);
		}
	}
}
