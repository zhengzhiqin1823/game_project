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
        {  //����size��С  
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minmum, maximum);
            //���ָı� 
            Camera.main.orthographicSize = Camera.main.orthographicSize - Input.GetAxis("Mouse   ScrollWheel") * ChangeSpeed;
        }
    }
    public void CameraSizeChange()
    {

    }
}
