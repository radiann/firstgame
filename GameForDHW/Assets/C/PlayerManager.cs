using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour {
    Animator animator;
    public UIMnager sync;
    public PlayerStatus PS;
    public bool isDead;
    public float playerhp;
    // Use this for initialization
    void Start()
    {
        sync.GetComponent<UIMnager>();
        PS.GetComponent<PlayerStatus>();
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Move", true);
        isDead = false;
        Invoke("TESTdebug", 2);
        playerhp = PS.PlayerHP;
    }
   
	// Update is called once per frame
	void Update () {
        if (sync.gamemode == false)
        {
            playerhp = PS.PlayerHP;
        }
        if (sync.Actionmode == true&& sync.gamemode ==true)
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
        if (playerhp <= 0 && sync.gamemode == true)
        {
            playerhp = 0;
            isDead = true;
            sync.isDie = true;
            animator.SetBool("Die", true);
        }
        else
        {
            isDead = false;
            sync.isDie = false;
            animator.SetBool("Die", false);
        }

    }
    public void DAMAGE()
    {
        animator.SetBool("Damage", false);
        sync.damage = false;
        sync.Actionmode = false;
    }
    public void TESTdebug()
    {
        Debug.Log("HP" + playerhp);
        Invoke("TESTdebug", 2);
    }
    public void Revival()
    {
        playerhp = PS.PlayerHP;
    }
    public void attackspeed()
    {
        PS.PlayerAS = 2;
    }
}
