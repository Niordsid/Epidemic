using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private ParticleSystem[] particles;
    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        particles = GetComponentsInChildren<ParticleSystem>();
        Destroy(gameObject, 10f);
    }


    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerPowerController>().increasePower();
            foreach (ParticleSystem ps in particles)
            {
                if (ps.name.Contains("Power"))
                {
                    ps.Play();
                    //Debug.Log(ps.name+ " done!!");
                }
                    
            }
            mesh.enabled = false;
            Destroy(gameObject, 1f);
        }

        //Debug.Log("" + coll.gameObject.name);
        if (!(coll.gameObject.name.Contains("Road") || coll.gameObject.name.Contains("Pav") || coll.gameObject.name.Contains("Player")))
        {

            mesh.enabled = false;

            foreach (ParticleSystem ps in particles)
            {
                if (!ps.name.Contains("Power"))
                {
                    ps.Play();
                    //Debug.Log(ps.name + " explode!!");
                }
                    
            }

            Destroy(gameObject, 1.5f);

        }
    }

}
