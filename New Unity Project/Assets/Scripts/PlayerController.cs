using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	//public float rotationSpeed;
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


	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody>();
		speed = 0.1f;

        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
        bulletSpawn = GameObject.Find("SpawnPoint").transform;
		//rotationSpeed = 10;
		//factor = 10;
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)) 
		{
			lookPos = hit.point;
		}

		Vector3 lookDir = lookPos - transform.position;
		lookDir.y = 0;

		transform.LookAt (transform.position + lookDir, Vector3.up);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }  
	}

	void FixedUpdate(){
		if (Input.GetKey("up")) {
			//transform.Translate (0, 0, 0.01f);
            playerRigidBody.MovePosition(transform.position + transform.forward * speed);
			Debug.Log ("up");
		}
		if (Input.GetKey("down")) {
			//transform.Translate (0, 0, -0.01f);
            playerRigidBody.MovePosition(transform.position - transform.forward  * speed);
			Debug.Log ("down");
		}
		if (Input.GetKey("right")) {
			//transform.Translate (0.01f, 0, 0);
            playerRigidBody.MovePosition(transform.position + transform.right * speed);
			Debug.Log ("right");
		}
		if (Input.GetKey("left")) {
			//transform.Translate (-0.01f, 0, 0);
            playerRigidBody.MovePosition(transform.position - transform.right * speed);
			Debug.Log ("left");
		}
	}

    private void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
      
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;
        
        Destroy(bullet, 3.0f);      
    
    }
}
