using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTeleporter : MonoBehaviour {

	public Transform teleportSpot;
	public Transform playerMainSpot;

	GameObject player;

	void Start () {
		player = GameObject.Find("Player");
		playerMainSpot = GameObject.Find("PlayerMainTransform").transform;
	}


	public void Teleport() {
		player.transform.SetPositionAndRotation(teleportSpot.transform.position, Quaternion.identity);
		StartCoroutine("BeginTeleport");
	}

	IEnumerator BeginTeleport() 
	{
		yield return new WaitForSeconds(5f);
		player.transform.SetPositionAndRotation(playerMainSpot.transform.position, Quaternion.identity);
        yield return null;
    
	}

}
