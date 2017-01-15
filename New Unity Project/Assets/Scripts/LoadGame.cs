using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadGame : MonoBehaviour {

	GameObject hud;
	GameObject city;

	Camera CameraGame;
	Camera CameraMenu;

	public Vector3 CameraGamePosition; 		//10.33f, 8f, -11.20f
	public Quaternion CameraGameRotation;	//Quaternion.Euler(23, -40, 0)

	private StartGame sgame;

	private Button btnJugar;


	private bool playing = false;


	public GameObject zombie;
	public float zombieCreationTime = 2;
	public float lastZombieCreated = 0;

	public GameObject survivor;
	public float survivorCreationTime = 10;
	public float lastSurvivorCreated = 0;


	void Awake(){

		CameraGame = ((GameObject)Instantiate (Resources.Load ("Prefabs/CameraGame"), new Vector3(15f, 21.5f, -15f), Quaternion.Euler(45, -45, 0))).GetComponent<Camera>();
		CameraGame.name = "CameraGame";

		CameraMenu = ((GameObject)Instantiate(Resources.Load("Prefabs/CameraMenu"), Vector3.zero, Quaternion.identity)).GetComponent<Camera>();
		CameraMenu.name = "CameraMenu";

		sgame = new StartGame();

		hud = (GameObject)Instantiate(Resources.Load("Prefabs/HUD"), transform.position, transform.rotation);
		hud.name = "HUD";

		//Butons
		btnJugar = (Button)GameObject.Find ("Canvas/Panel/btnJugar").GetComponent<Button>();

		btnJugar.onClick.AddListener(()=> Play());
	}

	public void Play(){
		sgame.startGame ();
		playing = true;
		city = GameObject.Find ("City");
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playing) {	
			//Creacion de zombies
			if (Time.time > lastZombieCreated + zombieCreationTime) 
			{
				createZombie ();
				lastZombieCreated = Time.time;
			}

			//Creacion de sobrevivientes
			if (Time.time > lastSurvivorCreated + survivorCreationTime) 
			{
				createSurvivor ();
				lastSurvivorCreated = Time.time;
			}
		}
	}

	public void createZombie(){

		string randomPoint = Random.Range (1, 12).ToString();
		Debug.Log ("RANDOMPOINT : " + randomPoint);

		Vector3 zombieOrigin = city.transform.FindChild("ZombieSpawnPoints").FindChild("Point" + randomPoint).transform.position ;

		//zombie = (GameObject) Instantiate(Resources.Load("Prefabs/Zombie"), zombieOrigin, Quaternion.identity);
        zombie = (GameObject)Instantiate(Resources.Load("Prefabs/Zombie_Lambent_Male"), zombieOrigin, Quaternion.identity);
	}

	public void createSurvivor(){

		string randomPoint = Random.Range (1, 12).ToString();
		Debug.Log ("RANDOMPOINT : " + randomPoint);

		Vector3 survivorOrigin = city.transform.FindChild("ZombieSpawnPoints").FindChild("Point" + randomPoint).transform.position ;

		survivor = (GameObject) Instantiate(Resources.Load("Prefabs/Survivor"), survivorOrigin, Quaternion.identity);
	}
}
