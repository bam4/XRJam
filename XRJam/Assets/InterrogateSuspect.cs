﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrogateSuspect : MonoBehaviour {


	public bool IsSecretAgent = false;
	public GameObject explosion;
	public AudioSource myAudioSource;
	public AudioClip Annoyed;

	
	public void Interrogate() {
		if (IsSecretAgent) {
			Instantiate(explosion, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		} else {
			myAudioSource.clip = Annoyed;
			myAudioSource.Play();

		}
	}
}
