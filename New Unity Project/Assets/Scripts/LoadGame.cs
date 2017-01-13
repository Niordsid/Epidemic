using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

	public GameObject hud;
	public GameObject city;

	private StartGame sgame;

	private Button btnJugar;

	void Awake(){

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
