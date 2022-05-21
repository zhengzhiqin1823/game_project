using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public static bool control = false;

    GameObject obj;

    public GameObject parent;

    public Vector3 dest_pos;

    public Vector3 src_pos;

    private Vector3 direction;

    private Transform t;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        t = transform;

        speed = 7f;

        src_pos = transform.position;

        //transform.GetComponent<Renderer>().enabled = false;//当前物体隐藏


        obj = GameObject.Instantiate(parent, t);//单例
        obj.transform.position = src_pos;//设置初始位置

    }

    // Update is called once per frame
    void Update()
    {
        if(control)
        {
            if(obj==null)
            obj = GameObject.Instantiate(parent,t);//单例
            src_pos = transform.position;
            dest_pos = GameObject.FindGameObjectWithTag("hero").transform.position;
            direction = (dest_pos - src_pos).normalized;
            if (src_pos != dest_pos)
                obj.transform.position += direction * speed * Time.deltaTime;
            if(obj.transform.position.y<=dest_pos.y)
            {
                Destroy(obj);
                obj = null;
            }
        }
    }
}
