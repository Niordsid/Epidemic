using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public GameObject hud;
	public GameObject city;

	public Camera CameraMenu;
	public Camera CameraGame;
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGame(){

		GameObject.Find ("HUD").active = false;
		//GameObject.Find ("CameraMenu").active = false;

		CameraMenu =  GameObject.Find ("CameraMenu").GetComponent<Camera>();
		CameraGame =  GameObject.Find ("CameraGame").GetComponent<Camera>();

		CameraMenu.transform.position = CameraGame.transform.position;
		CameraMenu.transform.rotation = CameraGame.transform.rotation;

		CameraMenu.orthographicSize = CameraGame.orthographicSize;
		CameraMenu.nearClipPlane = CameraGame.nearClipPlane;

		GameObject.Find ("CameraGame").active = false;


		city = (GameObject) Instantiate(Resources.Load("Prefabs/City"), Vector3.zero, Quaternion.identity);




		//hud = (GameObject)Instantiate(Resources.Load("Prefabs/HUD"), transform.position, transform.rotation);

	}
}
