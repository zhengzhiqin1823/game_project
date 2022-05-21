using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragonScript : MonoBehaviour
{
    public GameObject fire;//火球挂载到该物体

    public GameObject character;//主角挂载到该物体

    private bool attackMode;//攻击模式

    private int random;//概率进入攻击状态

    private Animator animator;//挂载该脚本的物体的动画机

    private Vector2 character_pos;//要攻击的主角位置

    private Vector2 fire_cur_pos;//火球起始位置

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        attackMode = false;
        animator = GetComponent<Animator>();
        fire_cur_pos = transform.position;
        speed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 10);
        //设置攻击概率为20%
        if(random>=8)
        {
            attackMode = true;
            animator.SetBool("Attack", attackMode);//进入攻击模式

            character_pos = character.transform.position;//跟踪主角位置


            GameObject new_fire = GameObject.Instantiate(fire,fire.transform);

            
            Move(new_fire, character,fire_cur_pos, character_pos);//火焰移动


            attackMode = !attackMode;//退出攻击模式
            animator.SetBool("Attack", attackMode);
        }
    }

    private void Move(GameObject g,GameObject charac,Vector2 src,Vector2 dest)
    {
        Vector3 direction = (dest - src).normalized;
       while(g.transform.position!=charac.transform.position)
        {
            g.transform.position += speed  * direction * Time.deltaTime;
        }
    }
}
