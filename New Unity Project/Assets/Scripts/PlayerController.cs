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
				if (Time.time > lastShoot + ShootCooldown) {
					Fire();
					lastShoot = Time.time ;
				}
	        }  
		}
	}

	void FixedUpdate(){

		if (isMovementEnabled) {

			if (Input.GetKey("up")) {
				transform.Translate (0, 0, 0.01f*speed);
	            //playerRigidBody.MovePosition(transform.position + transform.forward * speed);
			}
			if (Input.GetKey("down")) {
				transform.Translate (0, 0, -0.01f*speed);
	            //playerRigidBody.MovePosition(transform.position - transform.forward  * speed);
			}
			if (Input.GetKey("right")) {
				transform.Translate (0.01f*speed, 0, 0);
	            //playerRigidBody.MovePosition(transform.position + transform.right * speed);
			}
			if (Input.GetKey("left")) {
				transform.Translate (-0.01f*speed, 0, 0);
	            //playerRigidBody.MovePosition(transform.position - transform.right * speed);
			}

		}
	}

    private void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
      
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;        
        Destroy(bullet, 3.0f);      
    
    }
}
