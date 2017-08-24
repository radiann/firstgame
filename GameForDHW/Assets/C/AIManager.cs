using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {
    public UIMnager sync2;
    public AIStatus AS;
    public bool AIDead;
    public float Aihp;
    // Use this for initialization
    void Start() {
        sync2.GetComponent<UIMnager>();
        AS.GetComponent<AIStatus>();
        Aihp = AS.AIHP;
}
	
	// Update is called once per frame
	void Update () {
		
	}
}

