using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour {

    public int initialZombieHealth = 5;
    private int currentZombieHealth;
    public Image healthBar;

	void Start () {
        currentZombieHealth = initialZombieHealth;        
	}

    public void damage()
    {
        if (currentZombieHealth > 0)
        {
            currentZombieHealth -= 1;

            healthBar.fillAmount = currentZombieHealth / 5.0f;
        }
            
    }

    public int GetZombieHealth(){
        return currentZombieHealth;
    }


}
