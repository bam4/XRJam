using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ScreenTeleporter : MonoBehaviour {

	public Transform teleportSpot;
	Transform playerMainSpot;

	public delegate void TeleportAction();
    public static event TeleportAction GoToSecurity;
	public static event TeleportAction LeaveSecurity;

	GameObject player;


	void Start () {
		player = GameObject.Find("Player");
		playerMainSpot = GameObject.Find("PlayerMainTransform").transform;
	}

	void Update () {
		if (SteamVR_Actions._default.Teleport.GetState(SteamVR_Input_Sources.Any) ) {
			player.transform.SetPositionAndRotation(playerMainSpot.transform.position, player.transform.rotation);
			GoToSecurity();
			StopCoroutine("BeginTeleport");
		}
	}


	public void Teleport() {
		player.transform.SetPositionAndRotation(teleportSpot.transform.position, player.transform.rotation);
		LeaveSecurity();
		StartCoroutine("BeginTeleport");
	}

	IEnumerator BeginTeleport() 
	{
		yield return new WaitForSeconds(5f);
		player.transform.SetPositionAndRotation(playerMainSpot.transform.position, Quaternion.identity);
		GoToSecurity();
        yield return null;
    
	}

}
