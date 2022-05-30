using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScenceBegin : MonoBehaviour
{
    public Camera maincamera;

    public float distance;

    public float mindistance= 7.828065f;

    public float radio;

    public float dis;

    public GameObject hero;

    public GameObject dragon;
    private void Start()
    {
        radio = 0.6f;
    }
    void Update()
    {
        dis = Mathf.Sqrt((hero.transform.position.x - dragon.transform.position.x) * (hero.transform.position.x - dragon.transform.position.x) + (hero.transform.position.y - dragon.transform.position.y) * (hero.transform.position.y - dragon.transform.position.y));
        distance = radio * dis;
        CameraSizeChange();
    }
    public void CameraSizeChange()
    {
        if(distance<mindistance)
        {
            maincamera.orthographicSize = mindistance;
        }
        else
        {
            maincamera.orthographicSize = distance;
        }
    }
}
