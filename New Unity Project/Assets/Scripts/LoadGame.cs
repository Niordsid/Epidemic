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

    public GameObject helicopter;
    public float helicopterCreationTime = 7;
    public float lastHelicopterCreated = 0;


	void Awake(){

		CameraGame = ((GameObject)Instantiate (Resources.Load ("Prefabs/CameraGame"), new Vector3(15f, 21.5f, -15f), Quaternion.Euler(45, -45, 0))).GetComponent<Camera>();
		CameraGame.name = "CameraGame";

		CameraMenu = ((GameObject)Instantiate(Resources.Load("Prefabs/CameraMenu"), Vector3.zero, Quaternion.identity)).GetComponent<Camera>();
		CameraMenu.name = "CameraMenu";

		sgame = new StartGame();

		hud = (GameObject)Instantiate(Resources.Load("Prefabs/MainMenu"), transform.position, transform.rotation);
		hud.name = "HUD";

		//Butons
		btnJugar = (Button)GameObject.Find ("Menu/Play_Button").GetComponent<Button>();

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

            //Creacion de sobrevivientes
            if (Time.time > lastHelicopterCreated + helicopterCreationTime)
            {
                createHelicopter();
                lastHelicopterCreated = Time.time;
            }
		}
	}

	public void createZombie(){

		string randomPoint = Random.Range (1, 12).ToString();
		//Debug.Log ("RANDOMPOINT : " + randomPoint);

		Vector3 zombieOrigin = city.transform.FindChild("ZombieSpawnPoints").FindChild("Point" + randomPoint).transform.position ;

		//zombie = (GameObject) Instantiate(Resources.Load("Prefabs/Zombie"), zombieOrigin, Quaternion.identity);
        if(Random.Range(0,2) == 0)
            zombie = (GameObject)Instantiate(Resources.Load("Prefabs/Zombie_Lambent_Male"), zombieOrigin, Quaternion.identity);
        else
            zombie = (GameObject)Instantiate(Resources.Load("Prefabs/GreyZombie"), zombieOrigin, Quaternion.identity);
	}

	public void createSurvivor(){

		string randomPoint = Random.Range (1, 12).ToString();
		//Debug.Log ("RANDOMPOINT : " + randomPoint);

		Vector3 survivorOrigin = city.transform.FindChild("ZombieSpawnPoints").FindChild("Point" + randomPoint).transform.position ;

		survivor = (GameObject) Instantiate(Resources.Load("Prefabs/Survivor"), survivorOrigin, Quaternion.identity);
	}

    public void createHelicopter()
    {

        float z;
        Quaternion r;
        if (Random.Range(0, 2) > 0){
            r = Quaternion.Euler(new Vector3(0, 180, 0));
            z = 10;
        }
            
        else {
            r = Quaternion.identity;
            z = -10;
        }
           
        helicopter = (GameObject)Instantiate(Resources.Load("Prefabs/Helicopter"), new Vector3(Random.Range(-6,5),7,z) , r);
    }

   
}
