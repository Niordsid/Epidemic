using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {



	public GameObject hud;
	public GameObject city;
	public GameObject player;

	public Camera CameraMenu;
	public Camera CameraGame;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void startGame(){

		GameObject.Find ("HUD").active = false;

		CameraMenu =  GameObject.Find ("CameraMenu").GetComponent<Camera>();
		CameraGame =  GameObject.Find ("CameraGame").GetComponent<Camera>();

		CameraMenu.transform.position = CameraGame.transform.position;
		CameraMenu.transform.rotation = CameraGame.transform.rotation;

		CameraMenu.orthographicSize = CameraGame.orthographicSize;
		CameraMenu.nearClipPlane = CameraGame.nearClipPlane;

		CameraMenu.backgroundColor = CameraGame.backgroundColor;

		CameraGame.enabled = false;
		CameraGame.GetComponent<AudioListener> ().enabled = false;


		city = (GameObject) Instantiate(Resources.Load("Prefabs/City"), Vector3.zero, Quaternion.identity);
		city.name = "City";

		player = (GameObject) Instantiate(Resources.Load("Prefabs/Player"), Vector3.zero, Quaternion.identity);
		player.name = "Player";

		CameraMenu.gameObject.AddComponent<CameraController> ();

		Destroy (CameraGame);
	}


}
