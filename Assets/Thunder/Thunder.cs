using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{ 
    public Vector3 dest_pos;

    public Vector3 src_pos;

    public Vector3 direction;

    public float speed;

    public bool go;

    public GameObject thunder;
    // Start is called before the first frame update
    void Start()
    {
        src_pos = GameObject.FindGameObjectWithTag("hero").transform.position;
        transform.position = src_pos;
        dest_pos = GameObject.Find("Boss").transform.position;
        speed = 7f;
        direction = (dest_pos - src_pos).normalized;
    }
    private void Awake()
    {
        src_pos = GameObject.FindGameObjectWithTag("hero").transform.position;
        transform.position = src_pos;
        dest_pos = GameObject.Find("Boss").transform.position;
        speed = 7f;
        direction = (dest_pos - src_pos).normalized;
        speed = 7f;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (go == true)
        {
            //Debug.Log(dest_pos);
            //Debug.Log(transform.position);
            if (dest_pos != transform.position)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject g = collision.gameObject;
        if (collision.transform.tag.Equals("dragon"))
        {
            DragonScript ds = g.GetComponent<DragonScript>();
            ds.fall = true;
//            DragonScript.healthChange();
            go = false;
            GameObject.Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if (collision.transform.tag.Equals("dragon"))
        {
            DragonScript ds = g.GetComponent<DragonScript>();
            ds.fall = true;
            //            DragonScript.healthChange();
            go = false;
            GameObject.Destroy(this.gameObject);
        }
    }

}
