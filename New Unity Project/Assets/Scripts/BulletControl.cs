using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        print("Hit taget Object : "+ collision.gameObject.name); 
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
