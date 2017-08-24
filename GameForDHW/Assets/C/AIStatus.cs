using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStatus : MonoBehaviour {
    public UIMnager uimanager;
    public int AINumber,AILevel;
    public float AIAP,AIHP,AIAS;

	// Use this for initialization
	void Start () {
        uimanager.GetComponent<UIMnager>();
        AIHP = 10;
        AIAP = 3;
        AIAS = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
