using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public int PlayerLP,CharNumber,PlayerEXP,PlayerGold,CharEXP;
    public int SPlayerHP, SPlayerLP, SPlayerAP, SPlayerEXP, SPlayerGold, SCHAREXP;
    public float PlayerAS, PlayerAP,PlayerHP;
    //public float SPlayerAS;
    // Use this for initialization
    void Start () {
        PlayerHP = 20;
        PlayerLP = 10;
        PlayerAP = 5.0f;
        PlayerAS = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

    }
}
