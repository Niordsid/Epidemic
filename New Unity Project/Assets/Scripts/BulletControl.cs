using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        print("Hit taget Object : "+ collision.gameObject.name); 

		if (collision.gameObject.name.Contains("Zombie")) {
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
    }

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name.Contains("Zombie")) {
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
