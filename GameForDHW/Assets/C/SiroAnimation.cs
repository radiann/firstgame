using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiroAnimation : MonoBehaviour {
    public UIMnager UIMANAGER;
    Animator siroanimator;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        siroanimator = GetComponent<Animator>();
        if (UIMANAGER.MainPANEL==true)
        {
            siroanimator.SetBool("Changed", false);
        }
        else
        {
            siroanimator.SetBool("Changed", true);
        }
    }
    public void SiroAction()
    {
        siroanimator.SetTrigger("Click");
        if (UIMANAGER.gamemode == false)
        {
            UIMANAGER.PanelNumber = 3;
            UIMANAGER.prevpanel = UIMANAGER.Panel3;
            UIMANAGER.Resultpanel.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            UIMANAGER.PanelNumber = 6;
            UIMANAGER.prevpanel = UIMANAGER.Gamepanel;
        }
        Invoke("fadeanim", 2.3f);
    }
    public void Changed()
    {
        siroanimator.SetTrigger("Change");
    }
    public void fadeanim()
    {
        UIMANAGER.FadeAnim();
    }
}
