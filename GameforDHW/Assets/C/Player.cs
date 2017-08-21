using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {
    Animator animator;
    public UIMnager sync;
    public int playerHP;
    public float playerAP;
    public float playerAS;
    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Move", true);
    }
   
	// Update is called once per frame
	void Update () {
        if(sync.Actionmode == true&& sync.gamemode ==true)
        {
            animator.SetBool("Move", false);
        }
        else
        {
            animator.SetBool("Move", true);
        }
        if(sync.attack == true && sync.gamemode == true)
        {
            animator.SetTrigger("Attack");
            sync.attack = false;
            sync.Actionmode = false;
        }
        if(sync.damage == true && sync.gamemode == true)
        {
            animator.SetBool("Damage", true);
            Invoke("DAMAGE", 0.5f);
        }
        /*if (playerlife <= 0 && sync.gamemode == true)
        {
            playerlife = 0;
            animator.SetBool("Die", true);
        }*/

    }
    public void DAMAGE()
    {
        animator.SetBool("Damage", false);
        sync.damage = false;
        sync.Actionmode = false;
    }
}
