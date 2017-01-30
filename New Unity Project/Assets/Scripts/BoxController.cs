﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
    private ParticleSystem[] particles;
    private MeshRenderer mesh;
    
    void Start () {
        mesh = GetComponent<MeshRenderer>();
        particles = GetComponentsInChildren<ParticleSystem>();
        Destroy(gameObject, 10f);
	}
	

    public void OnCollisionEnter(Collision coll)
    {
        //Debug.Log("" + coll.gameObject.name);
        if (!(coll.gameObject.name.Contains("Road") || coll.gameObject.name.Contains("Pav")))
        {

            mesh.enabled = false;

            if (coll.gameObject.name.Contains("Player"))
            {
                Destroy(gameObject);
            }
            else
            {
                foreach (ParticleSystem ps in particles)
                {
                    ps.Play();
                }

                Destroy(gameObject, 1.5f);
            }
            
        }
    }

}
