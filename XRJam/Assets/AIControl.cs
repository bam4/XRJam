using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] goalLocations;
	UnityEngine.AI.NavMeshAgent agent;
	public Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		
		
		
		goalLocations = GameObject.FindGameObjectsWithTag("goal");
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);

		anim.SetTrigger("isWalking");
		anim.SetFloat("WOffset", Random.Range(0f,1f));
		float sm = Random.Range(.5f,2f);
		agent.speed *= sm;
		anim.SetFloat("SpeedMult", sm);
	}
	
	// Update is called once per frame
	void Update () {
		if(agent.remainingDistance < 1)
		{
			agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
		}
	}
}
