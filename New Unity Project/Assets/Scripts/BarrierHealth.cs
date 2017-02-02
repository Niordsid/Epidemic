using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierHealth : MonoBehaviour {
    
    public float initialBarrierHealth;
    private float currentBarrierHealth;
    public Image healthBar;

    void Start()
    {
        currentBarrierHealth = initialBarrierHealth;
    }

    public void damage()
    {
	//        Debug.Log("damage bar");
        if (currentBarrierHealth > 0)
        {
            currentBarrierHealth -= 1f;
            healthBar.fillAmount = currentBarrierHealth / initialBarrierHealth;
        }

        if (currentBarrierHealth == 0)
        {
            GameObject.Find("HUDIngame").transform.FindChild("ButtonMenu").gameObject.SetActive(true);
            GameObject.Find("HUDIngame").transform.FindChild("YouDied").gameObject.SetActive(true);
            GameObject.Find("HUDIngame").GetComponent<Timer>().timerOff();
        }

    }

    public float GetBarrierHealth()
    {
        return currentBarrierHealth;
    }
}
