using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public UIMnager UImanager;
    public Button storybutton2;
	// Use this for initialization
	void Start () {
        UImanager.GetComponent<UIMnager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(UImanager.rememberkaisou <= 4)
        {
            storybutton2.interactable = false;
        }
        else
        {
            storybutton2.interactable = true;
        }
	}
    public void Storybutton1()
    {
        UImanager.finishikaisou = 5;
    }
    public void Storybutton2()
    {
        UImanager.finishikaisou = 10;
    }
}
