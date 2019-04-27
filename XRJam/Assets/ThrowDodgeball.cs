using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ThrowDodgeball : MonoBehaviour {

	public GameObject Dodgeball;
	

	public Valve.VR.InteractionSystem.Hand hand;
	
	bool DodgeballReady = true;

	// Update is called once per frame
	void Update () {
		if (SteamVR_Actions._default.InteractUI.GetState(SteamVR_Input_Sources.Any) ) {
			if (DodgeballReady) {
				SpawnDodgeball();
				DodgeballReady = false;
			}
		}
	}

	

	public void SpawnDodgeball () {
		Debug.Log("Spawning dodgeball");
		GameObject spawnedDodgeball = GameObject.Instantiate( Dodgeball, hand.transform.position, Quaternion.identity );
		spawnedDodgeball.SetActive( true );
		
		hand.AttachObject( spawnedDodgeball, Valve.VR.InteractionSystem.GrabTypes.None, Valve.VR.InteractionSystem.Hand.AttachmentFlags.SnapOnAttach );

	}

	
}
