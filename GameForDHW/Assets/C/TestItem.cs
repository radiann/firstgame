using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour {

    public ItemC itemc;
	// Use this for initialization
	void Start () {
        Inventory.instance.Add(itemc);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Inventory.instance.Add(itemc);
            Debug.Log("CC");
        }
	}
}
