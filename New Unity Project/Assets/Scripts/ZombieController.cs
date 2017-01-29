﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieController : MonoBehaviour {

	public GameObject target;
	public GameObject player;
	 

	// Use this for initialization
	void Start () {
		
		//target inicial es el jugador
		target = GameObject.Find ("Player");
		player = GameObject.Find ("Player");
		gameObject.GetComponent<NavMeshAgent> ().SetDestination(target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {

		try {
			if (gameObject.GetComponent<NavMeshAgent> ().enabled) {
				gameObject.GetComponent<NavMeshAgent> ().destination = target.transform.position;
			}
		} catch (System.Exception ex) {
			
		}



	}

	void setTarget(GameObject newTarget){
		target = newTarget;
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("COLISION " + collision.gameObject.name);


		//impacto en el zombie
		if (collision.gameObject.name.Contains("Bullet")) {
			gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			gameObject.GetComponent<Collider> ().enabled = false;
			GetComponent<Animator> ().SetBool ("bulletImpacted", true);
			Destroy (gameObject, 2.4f);
		}	
		if (collision.gameObject.name.Contains("Barrier")) {
			//gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			//gameObject.GetComponent<Collider> ().enabled = false;
			GetComponent<Animator> ().SetBool ("canAttack", true);
		}	
		else if (collision.gameObject.name.Contains("Survivor") || collision.gameObject.name.Contains("Player")) 
		{
			transform.LookAt (collision.gameObject.transform.position, Vector3.up);
			gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			GetComponent<Animator> ().SetBool ("canBite", true);

			if (collision.gameObject.name.Contains("Player")) {
				player.GetComponent<PlayerController> ().setMovementDisabled ();
				StartCoroutine (enablePlayerController());
			}
			else if (collision.gameObject.name.Contains("Survivor")) {
				collision.gameObject.GetComponent<SurvivorController> ().setMovementDisabled ();
				StartCoroutine (enableSurvivorController(collision.gameObject));
			}
		}	

	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.name.Contains ("Survivor") || collision.gameObject.name.Contains ("Player")) {
			GetComponent<Animator> ().SetBool ("canBite", false);
			GetComponent<Animator> ().SetBool ("walking", true);
			gameObject.GetComponent<NavMeshAgent> ().enabled = true;

		}
	}


	IEnumerator enablePlayerController(){
		
		yield return new WaitForSeconds(2);
		player.GetComponent<PlayerController> ().setMovementEnabled ();
	}

	IEnumerator enableSurvivorController(GameObject gameObject){

		yield return new WaitForSeconds(2);
		gameObject.transform.GetComponent<SurvivorController> ().setMovementEnabled ();
	}

	//Encontrar otro objetivo
	void OnTriggerEnter(Collider collider){
        //El zombie encuentra un sobreviviente
		if (collider.gameObject.name.Contains("Survivor")) {
			setTarget (collider.gameObject);
		}
	}
}
