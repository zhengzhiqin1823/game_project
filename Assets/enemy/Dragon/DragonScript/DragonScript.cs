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

    public static int hero_energy;

    public BoxCollider2D col;

    public  bool fall;

    public bool StopFall;

    public int StopTime;

    public int currentHealth;

    public int maxHealth;

    public Image healthimg;

    public float ratio;

    private float invincibleTime = 1f;//无敌时间

    private bool isinvincible;

    private float invicibleTimer;//无敌时间计时

    private Vector3 fallpos;

    public bool down;

    private Rigidbody2D rigid;//利用刚体运动

    Vector2 startPos;

    public bool rise;
    void Start()
    {
        startPos = transform.position;
        col = GetComponent<BoxCollider2D>();
        hero_energy = 0;
        attackMode = false;
        animator = GetComponent<Animator>();
        maxfiretime = 1060;
        fall = false;
        maxHealth = 400;
        currentHealth = maxHealth;
        ratio = 1f;
        invincibleTime = 1f;
        invicibleTimer = invincibleTime;
        fallpos = new Vector3(0, 0, 0);
        down = false;//
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(currentHealth==0)
        {
            animator.SetBool("dead", true);
            StopTime = -1;
            return;
        }
        if (rise)
        {
            if (rigid.position.y <= startPos.y)
            {
                Vector2 trans = new Vector2(this.transform.position.x, this.transform.position.y + 0.1f);
                rigid.MovePosition(trans);
            }
            else rise = false;
        }
        changeHealthimg();
        if (isinvincible)
        {
            invicibleTimer -= Time.deltaTime;
            if (invicibleTimer < 0)
            {
                isinvincible = false;
            }
        }
        
        if (!fall)
        {
            firetimer++;
            random = Random.Range(1, 10000);
            //攻击概率%1
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
            if(!down)
            {
                Vector2 trans = new Vector2(this.transform.position.x, this.transform.position.y-0.1f);
                rigid.MovePosition(trans);
            }
            if(down)
            {
                if (StopTime >= 500)
                {
                    StopTime = 0;
                    fall = !fall;
                    down = !down;
                    animator.SetBool("Fall", false);
                    rise = true;
                    StopFall = false;
                }
                
                else 
                StopTime += 1;
                Debug.Log(StopTime);
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
        Debug.Log("hello");
        
        if (collision.gameObject.tag.Equals("envirment"))
        {
            down = true;
            animator.SetBool("Fall", true);
            
        }
           
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("environment"))
        {
            down = false;
            
        }
    }
    public void healthChange(int amount)
    {
        if (currentHealth == 0)
        {
            return;
        }
        if (amount < 0)
        {
            if (isinvincible) return;
            isinvincible = true;
            invicibleTimer = invincibleTime;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);//限制生命值范围
        ratio = (float)currentHealth / ((float)maxHealth);
    }
    private void changeHealthimg()
    {
        healthimg.fillAmount = Mathf.Lerp(healthimg.fillAmount, ratio, Time.deltaTime * 5);
    }
}

