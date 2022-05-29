using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonScript : MonoBehaviour
{
    public int random;

    public static bool attackMode;

    private Animator animator;

    public GameObject fireBallpos;

    public GameObject fireBall;

    public float firetimer;

    public float maxfiretime;

    public Slider hp;

    public static int hero_energy;

    void Start()
    {
        hero_energy = 0;
        hp =GameObject.Find("Slider").GetComponent<Slider>();
        hp.value = 1f;//ÑªÌõÂú
        attackMode = false;
        animator = GetComponent<Animator>();
        maxfiretime = 1060;
    }

    void Update()
    {
        firetimer++;
        random = Random.Range(1, 10000);
        //¹¥»÷¸ÅÂÊ%1
        if (random % 100 == 1&&firetimer>maxfiretime)
        {
            attackMode = true;
            animator.SetBool("Attack", attackMode);
            firetimer = 0;
            StartCoroutine("DelayFunc1");
        }
    }

    IEnumerator DelayFunc1()
    {
        float timer = 0;
        while (timer < 1)
        {
            yield return new WaitForSeconds(1.17f);
            timer++;
        }
        var fireball = Instantiate(fireBall);
        fireball.transform.position = fireBallpos.transform.position;
        FireScript fsct = fireball.GetComponent<FireScript>();
        fsct.control = true;
        fsct.fireBallPos = fireBallpos;
        attackMode = false;
        animator.SetBool("Attack", attackMode);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.hp.value -= 0.2f;

    }



}

