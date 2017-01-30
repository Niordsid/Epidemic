using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerController : MonoBehaviour {


    private int playerPower;

    private float zombieDamage;

    void Start () {
        playerPower = 0;
        zombieDamage = 1.0f;
	}


    public void increasePower()
    {
        if (playerPower < 5)
        {
            playerPower++;
        }

        updatePowerUp();
    }

    public int getPlayerPower()
    {
        return playerPower;
    }

    public float getZombieDamage()
    {
        return zombieDamage;
    }

    public void updatePowerUp()
    {
        if(playerPower == 1){
            zombieDamage = 2.0f;
            Debug.Log("DAMAGE UP " + zombieDamage);
        }

        if (playerPower == 2)
        {
            zombieDamage = 3.0f;
            Debug.Log("DAMAGE UP " + zombieDamage);
        }

        if (playerPower == 3)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().addBullet();
            Debug.Log("DAMAGE UP " + zombieDamage);
        }

        if (playerPower == 4)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().addBullet();
        }
    }
}
