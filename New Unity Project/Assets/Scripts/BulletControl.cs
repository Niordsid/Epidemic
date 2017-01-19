using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
	
   
    void OnTriggerEnter(Collider collider)
    {        
        if (!collider.isTrigger)
        {
            if (collider.gameObject.name.Contains("Zombie"))
            {
                Destroy(collider.gameObject, 2.4f);
                Destroy(gameObject);
            }
        }
    }
}
