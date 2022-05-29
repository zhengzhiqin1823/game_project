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
        go = false;
        src_pos = GameObject.FindGameObjectWithTag("hero").transform.position;
        transform.position = src_pos;
        dest_pos = GameObject.Find("Boss").transform.position;
        speed = 7f;
        direction = (dest_pos - src_pos).normalized;
    }
    private void Awake()
    {
        speed = 7f;

    }
    // Update is called once per frame
    void Update()
    {
        if(go==true)
            if (dest_pos != transform.position)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this);
        go = false;
    }
}
