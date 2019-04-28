using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLineRendererOff : MonoBehaviour {

	public static bool ballInHand = false;
	GameObject Player;

	void Start() {
		Player = GameObject.Find("Player");
	}

	public void NoLineRenderer () {
		ballInHand = true;
		//Player.GetComponent<PickAScreen>().myLineRenderer.enabled = false;
	}
	
	public void YesLineRenderer () {
		ballInHand = false;
		Player.GetComponent<PickAScreen>().myLineRenderer.enabled = true;
	}
}
