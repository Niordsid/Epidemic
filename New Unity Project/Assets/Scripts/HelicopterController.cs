using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour {


    private float dir;
    private GameObject box;

	void Start () {
        if (transform.position.z > 0)
            dir = -0.08f;
        else
            dir = 0.08f;

        Destroy(gameObject, 10);
        StartCoroutine(dropBox());

	}
	
	
	void Update () {
        transform.position = transform.position + new Vector3(0, 0, dir);
	}


    IEnumerator dropBox()
    {

        yield return new WaitForSeconds(2.5f);
        box = (GameObject)Instantiate(Resources.Load("Prefabs/Box"), new Vector3(transform.position.x, transform.position.y - 1, transform.position.z),Quaternion.identity);
    }


}
