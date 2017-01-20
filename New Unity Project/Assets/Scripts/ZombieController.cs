using System.Collections;
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
		gameObject.GetComponent<NavMeshAgent> ().destination = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		try {
			gameObject.GetComponent<NavMeshAgent> ().destination = target.transform.position;
		} catch (System.Exception ex) {
			
		}



	}

	void setTarget(GameObject newTarget){
		target = newTarget;
	}

	void OnCollisionEnter(Collision collision)
	{
		//impacto en el zombie
		if (collision.gameObject.name.Contains("Bullet")) {
			gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			gameObject.GetComponent<Collider> ().enabled = false;
			GetComponent<Animator> ().SetBool ("bulletImpacted", true);
			Destroy (gameObject, 2.4f);
		}	
		else if (collision.gameObject.name.Contains("Barrier")) {
			//gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			//gameObject.GetComponent<Collider> ().enabled = false;
			GetComponent<Animator> ().SetBool ("canAttack", true);
		}	
		else if (collision.gameObject.name.Contains("Survivor") || collision.gameObject.name.Contains("Player")) 
		{
			transform.LookAt (collision.gameObject.transform.position, Vector3.up);
			gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			//gameObject.GetComponent<Collider> ().enabled = false;
			GetComponent<Animator> ().SetBool ("canBite", true);

			if (collision.gameObject.name.Contains("Player")) {
				player.GetComponent<PlayerController> ().setMovementDisabled ();
				StartCoroutine (enablePlayerController());
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

	//Encontrar otro objetivo
	void OnTriggerEnter(Collider collider){
        //El zombie encuentra un sobreviviente
		if (collider.gameObject.name.Contains("Survivor")) {
			setTarget (collider.gameObject);
		}
	}
}
