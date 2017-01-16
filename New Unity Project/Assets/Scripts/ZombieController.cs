using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieController : MonoBehaviour {

	public GameObject target;
	 

	// Use this for initialization
	void Start () {
		
		//target inicial es el jugador
		target = GameObject.Find ("Player");
		gameObject.GetComponent<NavMeshAgent> ().destination = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<NavMeshAgent> ().destination = target.transform.position;
	}

	void setTarget(GameObject newTarget){
		target = newTarget;
	}

	
	void OnTriggerEnter(Collider collider){
        //El zombie encuentra un sobreviviente
		if (collider.gameObject.name.Contains("Survivor")) {
			setTarget (collider.gameObject);
		}
        //El zombie es impactado por una bala
        if (collider.gameObject.name.Contains("Bullet")) {
            print("Zombie Died");
            GetComponent<Animator>().SetBool("bulletImpacted", true);
        }
	}
}
