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

    public static Slider hp;

    public static int hero_energy;

    public BoxCollider col;

    public static bool fall;

    public bool StopFall;

    public int StopTime;

    void Start()
    {
        col = GetComponent<BoxCollider>();
        hero_energy = 0;
        hp =GameObject.Find("Slider").GetComponent<Slider>();
        hp.value = 1f;//ÑªÌõÂú
        attackMode = false;
        animator = GetComponent<Animator>();
        maxfiretime = 1060;
    }

    void Update()
    {
        fall = animator.GetBool("Fall");
        if(StopTime==500)
        {
            StopTime = 0;
            fall = !fall;
        }
        if (!fall)
        {
            firetimer++;
            random = Random.Range(1, 10000);
            //¹¥»÷¸ÅÂÊ%1
            if (random % 100 == 1 && firetimer > maxfiretime)
            {
                attackMode = true;
                animator.SetBool("Attack", attackMode);
                firetimer = 0;
                StartCoroutine("DelayFunc1");
            }
        }
        else
        {
            if(!StopFall)
            transform.position = new Vector3(transform.position.x, transform.position.y-0.1f, transform.position.z);
            if(StopFall)
            {
                StopTime += 1;
            }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("environment"))
            StopFall = true;
    }
    public static void healthChange()
    {
        hp.value -= 0.1f;
    }
}

