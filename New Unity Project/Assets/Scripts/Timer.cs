using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    public float timeLeft;
    public bool timerOn;
    //public Text timerText;
	// Use this for initialization
	void Start () {
        timeLeft = 60f;
        timerOn = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (timerOn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft >= 0)
            {
                gameObject.transform.FindChild("timeleft").GetComponent<Text>().text =
                    Mathf.Round(timeLeft).ToString();
            }
            if (timeLeft <= 0)
            {
                gameObject.transform.FindChild("timeleft").GetComponent<Text>().text = "0";
                StartCoroutine(enableEnd());
            }
        }
        
	}

    IEnumerator enableEnd()
    {

        yield return new WaitForSeconds(1);
        GameObject.Find("HUDIngame").transform.FindChild("ButtonMenu").gameObject.SetActive(true);
        GameObject.Find("HUDIngame").transform.FindChild("Success").gameObject.SetActive(true);
    }

    public void timerOff()
    {
        timerOn = false;
    }
}
