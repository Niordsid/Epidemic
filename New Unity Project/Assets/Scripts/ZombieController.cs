using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieController : MonoBehaviour {

	public GameObject target;
	public GameObject player;
	 
	void Start () {
		
		//target inicial es el jugador
		target = GameObject.Find ("Player");
		player = GameObject.Find ("Player");
		gameObject.GetComponent<NavMeshAgent> ().SetDestination(target.transform.position);
	}
	
	void Update () {

		try {
			if (gameObject.GetComponent<NavMeshAgent> ().enabled) {
				gameObject.GetComponent<NavMeshAgent> ().destination = target.transform.position;
			}
		} catch (System.Exception ex) {
            Debug.LogWarning(ex);
		}

	}

	void setTarget(GameObject newTarget){
		target = newTarget;
	}

	void OnCollisionEnter(Collision collision)
	{        
		//impacto en el zombie
		if (collision.gameObject.name.Contains("Bullet")) {

            GetComponent<ZombieHealth>().damage();

            if (GetComponent<ZombieHealth>().GetZombieHealth() <= 0)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
                GetComponent<Animator>().SetBool("bulletImpacted", true);
                Destroy(gameObject, 2.4f);
            }
			
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

                if (!player.GetComponent<Animator>().GetBool("playerIsHurt"))
                {
                    player.GetComponent<PlayerController>().setMovementDisabled();
                    player.GetComponent<Animator>().SetBool("playerIsHurt", true);
                    player.GetComponent<Collider>().enabled = false;
                    StartCoroutine(enablePlayerController());
                }
				
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

        player.GetComponent<Collider>().enabled = true;        
		yield return new WaitForSeconds(2);
		player.GetComponent<PlayerController> ().setMovementEnabled ();
        player.GetComponent<Animator>().SetBool("playerIsHurt", false);
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
