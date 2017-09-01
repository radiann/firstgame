using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public UIMnager UImanager;
    public Button storybutton2;
    public PlayerStatus status;
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
    public void JobSelect()
    {
        UImanager.JobPanel.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void Jobback()
    {
        UImanager.JobPanel.GetComponent<CanvasGroup>().alpha = 0;
    }
    public void HPAdd()
    {
        status.PlayerHP += 1;
    }
    public void HPSub()
    {
        status.PlayerHP -= 1;
    }
    public void APAdd()
    {
        status.PlayerAP += 1;
    }
    public void APSub()
    {
        status.PlayerAP -= 1;
    }
    public void LPAdd()
    {
        status.PlayerLP += 1;
    }
    public void LPSub()
    {
        status.PlayerLP -= 1;
    }
    /// <summary>
    /// GameSelect
    /// </summary>
    public void Storybutton1()
    {
        UImanager.kaisou = 1;
        UImanager.finishikaisou = 5;
    }
    public void Storybutton2()
    {
        UImanager.kaisou = 5;
        UImanager.finishikaisou = 10;
    }
    public void Stage1Select()
    {
        UImanager.Stage1Image.enabled = true;
        UImanager.Stage2Image.enabled = false;
    }
    public void Stage2Select()
    {
        UImanager.Stage1Image.enabled = false;
        UImanager.Stage2Image.enabled = true;
    }
    /// <summary>
    /// Item
    /// </summary>
    public void sarubezi()
    {
        if (UImanager.isDie == true)
        {
            UImanager.gamemode = false;
            UImanager.Timer = false;
            UImanager.Resultpanel.GetComponent<CanvasGroup>().alpha = 1;
        }

    }
    public void ItemReturn()
    {
        UImanager.gamemode = false;
        UImanager.Timer = false;
        UImanager.Resultpanel.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void timespeed()
    {
        UImanager.kaisouspeed = 2;
    }
}
