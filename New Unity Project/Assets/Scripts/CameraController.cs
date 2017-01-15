using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	GameObject player;
	Vector3 distance;

	// Use this for initialization
	void Start () {		

		distance = transform.position - GameObject.Find ("Player").transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {	
		transform.position = GameObject.Find ("Player").transform.position + distance;
		
	}
}
