using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragonScript : MonoBehaviour
{
    public int random;

    public static bool attackMode;

    public Animator animator;

    void Start()
    {
        attackMode = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        random = Random.Range(1, 10000);
        //¹¥»÷¸ÅÂÊ%1
        if (random % 100 == 1)
        {
            attackMode = true;
            animator.SetBool("Attack", attackMode);


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
        FireScript.control = true;
        attackMode = false;
        animator.SetBool("Attack", attackMode);
    }
}

