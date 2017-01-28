using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInChildren<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision coll)
    {
        
        if (!coll.gameObject.name.Contains("Floor"))
        {
            GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject,1.5f);
        }
    }

}
