using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScenceBegin : MonoBehaviour
{
    public Camera main;

    public float distance;

    public float mindistance= 7.828065f;

    public float radio;

    
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {  //限制size大小  
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minmum, maximum);
            //滚轮改变 
            Camera.main.orthographicSize = Camera.main.orthographicSize - Input.GetAxis("Mouse   ScrollWheel") * ChangeSpeed;
        }
    }
    public void CameraSizeChange()
    {

    }
}
