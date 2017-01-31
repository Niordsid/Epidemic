using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    public float timeLeft;
    //public Text timerText;
	// Use this for initialization
	void Start () {
        timeLeft = 60f;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft >= 0 )
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

    IEnumerator enableEnd()
    {

        yield return new WaitForSeconds(1);
        GameObject.Find("Succes").SetActive(true);
        GameObject.Find("ButtonMenu").SetActive(true);
    }
}
