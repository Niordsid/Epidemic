using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float ShootCooldown = 0.2f;
	public float lastShoot = 0;
	//public float factor;

	//private Vector3 mousePosition;
	private Vector3 lookPos;

	//private Quaternion initialRotation;
	//private Quaternion finalRotation;

	private float horizontalMovement;
	private float verticalMovement;

    private Rigidbody playerRigidBody;
    private GameObject bulletPrefab;
    
    public Transform bulletSpawn;

	private bool isMovementEnabled;

	public void setMovementEnabled(){
		isMovementEnabled = true;
	}

	public void setMovementDisabled(){
		isMovementEnabled = false;
	}


	// Use this for initialization
	void Start () {
		
		setMovementEnabled ();
        //playerRigidBody = GetComponent<Rigidbody>();
		speed = 3f;

        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
        bulletSpawn = GameObject.Find("SpawnPoint").transform;
		//rotationSpeed = 10;
		//factor = 10;
	}
	
	// Update is called once per frame
	void Update () {

		if (isMovementEnabled) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100)) 
			{
				lookPos = hit.point;
			}

			Vector3 lookDir = lookPos - transform.position;
			lookDir.y = 0;

			transform.LookAt (transform.position + lookDir, Vector3.up);

	        if (Input.GetMouseButton(0))
	        {
				//Debug.Log ("DISPARO");
				if (Time.time > lastShoot + ShootCooldown) {
					GetComponent<Animator> ().SetBool ("playerIsShooting", true);
					Fire();
					lastShoot = Time.time ;
				}
	        } else {
				GetComponent<Animator> ().SetBool ("playerIsShooting", false);
				}


			//Moviemiento
			if (Input.GetKey("up") || Input.GetKey(KeyCode.W) ) {
				transform.Translate (0, 0, 0.01f*speed);
				GetComponent<Animator> ().SetBool ("playerIsMoving", true);
				//Debug.Log ("Player is moving");
				//playerRigidBody.MovePosition(transform.position + transform.forward * speed);
			} else {
				
				GetComponent<Animator> ().SetBool ("playerIsmoving", false);
				//Debug.Log ("Player is NOT moving");
			}

		}
	}

	void FixedUpdate(){
		/*
		if (isMovementEnabled) {

			if (Input.GetKey("up") || Input.GetKey(KeyCode.W) ) {
				transform.Translate (0, 0, 0.01f*speed);
				GetComponent<Animator> ().SetBool ("playerIsmoving", true);
				Debug.Log ("Player is moving");
	            //playerRigidBody.MovePosition(transform.position + transform.forward * speed);
			} else {
				GetComponent<Animator> ().SetBool ("playerIsmoving", false);
				Debug.Log ("Player is NOT moving");
			}


			if (Input.GetKey("down") || Input.GetKey(KeyCode.S)) {
				transform.Translate (0, 0, -0.01f*speed);
	            //playerRigidBody.MovePosition(transform.position - transform.forward  * speed);
			}
			if (Input.GetKey("right") || Input.GetKey(KeyCode.D)) {
				transform.Translate (0.01f*speed, 0, 0);
	            //playerRigidBody.MovePosition(transform.position + transform.right * speed);
			}
			if (Input.GetKey("left") || Input.GetKey(KeyCode.A)) {
				transform.Translate (-0.01f*speed, 0, 0);
	            //playerRigidBody.MovePosition(transform.position - transform.right * speed);
			}


		}
		*/
	}

    private void Fire()
    {
		
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
      
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;        
        Destroy(bullet, 3.0f);      
    
    }
}
