using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour {

    public float initialZombieHealth;
    private float currentZombieHealth;
    public Image healthBar;

	void Start () {
        currentZombieHealth = initialZombieHealth;        
	}

    public void damage()
    {
        if (currentZombieHealth > 0)
        {
            //Debug.Log(" zzz "+GameObject.Find("Player").GetComponent<PlayerPowerController>().getZombieDamage());
            currentZombieHealth -= GameObject.Find("Player").GetComponent<PlayerPowerController>().getZombieDamage();

            healthBar.fillAmount = currentZombieHealth / initialZombieHealth;

            //Debug.Log(currentZombieHealth + " " + healthBar.fillAmount + " " + initialZombieHealth);
        }
            
    }

    public float GetZombieHealth(){
        return currentZombieHealth;
    }


}
