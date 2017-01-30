using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float ShootCooldown = 0.2f;
	public float lastShoot = 0;
    public int numBullets;
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

	void Start () {
		
		setMovementEnabled ();
        //playerRigidBody = GetComponent<Rigidbody>();
		speed = 3f;

        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
        bulletSpawn = GameObject.Find("SpawnPoint").transform;

        numBullets = 1;
		//rotationSpeed = 10;
		//factor = 10;
	}
	
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


			//Movimiento
			if (Input.GetKey("up") || Input.GetKey(KeyCode.W) ) {
				transform.Translate (0, 0, 0.01f*speed);
				GetComponent<Animator> ().SetBool ("playerIsMoving", true);
				//Debug.Log ("Player is moving");
				//playerRigidBody.MovePosition(transform.position + transform.forward * speed);
			} else {
				
				GetComponent<Animator> ().SetBool ("playerIsMoving", false);
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
        if (numBullets == 1)
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;
            Destroy(bullet, 3.0f);    
        }

        if (numBullets == 2)
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position + new Vector3(-0.03f,0,-0.03f) , bulletSpawn.rotation *= Quaternion.Euler(0, -5, 0));
            var bullet1 = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position + new Vector3(0.03f, 0, 0.03f), bulletSpawn.rotation *= Quaternion.Euler(0, 5, 0));

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;
            Destroy(bullet, 3.0f);

            bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * 20;
            Destroy(bullet1, 3.0f);
        }

        if (numBullets == 3)
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position + new Vector3(-0.05f, 0, -0.05f), bulletSpawn.rotation *= Quaternion.Euler(0, -9, 0));
            var bullet1 = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            var bullet2 = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position + new Vector3(0.05f, 0, 0.05f), bulletSpawn.rotation *= Quaternion.Euler(0, 9, 0));

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;
            Destroy(bullet, 3.0f);

            bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * 20;
            Destroy(bullet1, 3.0f);

            bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * 20;
            Destroy(bullet2, 3.0f);
          
        }
    
    }


    public void addBullet(){
        if(numBullets < 3)
            numBullets++;

        Debug.Log("DAMAGE UP " + numBullets);
    }
}
