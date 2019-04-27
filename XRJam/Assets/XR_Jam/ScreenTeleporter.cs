using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ScreenTeleporter : MonoBehaviour {

	public Transform teleportSpot;
	public Transform playerMainSpot;

	GameObject player;

	void Start () {
		player = GameObject.Find("Player");
		playerMainSpot = GameObject.Find("PlayerMainTransform").transform;
	}

	void Update () {
		if (SteamVR_Actions._default.Teleport.GetState(SteamVR_Input_Sources.Any) ) {
			player.transform.SetPositionAndRotation(playerMainSpot.transform.position, player.transform.rotation);
		}
	}


	public void Teleport() {
		player.transform.SetPositionAndRotation(teleportSpot.transform.position, player.transform.rotation);
		StartCoroutine("BeginTeleport");
	}

	IEnumerator BeginTeleport() 
	{
		yield return new WaitForSeconds(5f);
		player.transform.SetPositionAndRotation(playerMainSpot.transform.position, Quaternion.identity);
        yield return null;
    
	}

}
