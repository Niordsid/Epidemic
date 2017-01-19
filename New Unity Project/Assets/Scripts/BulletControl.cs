using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
	
   
    void OnCollisionEnter(Collision collison)
    { 
		Destroy(gameObject);
    }
}
