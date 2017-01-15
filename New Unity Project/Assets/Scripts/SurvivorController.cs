using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SurvivorController : MonoBehaviour {

	public GameObject target;
	public GameObject safeArea;


	// Use this for initialization
	void Start () {
		//target inicial es el jugador


		safeArea = GameObject.Find ("City/Buildings/PlayerArea");
		gameObject.GetComponent<NavMeshAgent> ().destination = safeArea.transform.position;
	}

	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<NavMeshAgent> ().destination = Vector3.zero;


	}

	void setTarget(GameObject newTarget){
		target = newTarget;
	}
}
