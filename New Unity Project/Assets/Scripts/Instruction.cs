using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruction: MonoBehaviour{

    int count;

    void Start()
    {
        count = 0;
    }

    public void AddCount()
    {
        if (count < 4)
        {
            count++;
            if (count == 1)
            {
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction1").gameObject.SetActive(false);
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction2").gameObject.SetActive(true);
            }

            if (count == 2)
            {
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction2").gameObject.SetActive(false);
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction3").gameObject.SetActive(true);
            }
            if (count == 3)
            {
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction3").gameObject.SetActive(false);
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction4").gameObject.SetActive(true);
            }
            if (count == 4)
            {
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction4").gameObject.SetActive(false);
                GameObject.Find("Instructions").transform.FindChild("Canvas/instruction5").gameObject.SetActive(true);
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
        
}