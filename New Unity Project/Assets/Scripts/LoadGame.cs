using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

	public GameObject hud;
	public GameObject city;

	public Camera CameraGame;
	public Camera CameraMenu;

	private StartGame sgame;

	private Button btnJugar;

	void Awake(){

		CameraGame = ((GameObject)Instantiate (Resources.Load ("Prefabs/CameraGame"), new Vector3(10.33f, 8f, -11.20f), Quaternion.Euler(23, -40, 0))).GetComponent<Camera>();
		CameraGame.name = "CameraGame";

		CameraMenu = ((GameObject)Instantiate(Resources.Load("Prefabs/CameraMenu"), Vector3.zero, Quaternion.identity)).GetComponent<Camera>();
		CameraMenu.name = "CameraMenu";

		sgame = new StartGame();

		hud = (GameObject)Instantiate(Resources.Load("Prefabs/HUD"), transform.position, transform.rotation);
		hud.name = "HUD";

		btnJugar = (Button)GameObject.Find ("Canvas/Panel/btnJugar").GetComponent<Button>();

		btnJugar.onClick.AddListener(()=> Play());
	}

	public void Play(){
		sgame.startGame ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
