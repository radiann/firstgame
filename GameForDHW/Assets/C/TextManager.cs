using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour {
    public Text StatusHP, StatusAP, StatusLP;
    public PlayerStatus status;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StatusHP.text = status.PlayerHP.ToString();
        StatusAP.text = status.PlayerAP.ToString();
        StatusLP.text = status.PlayerLP.ToString();
	}
}
