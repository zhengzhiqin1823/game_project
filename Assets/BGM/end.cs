using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    public Image image2;
    public Image image1;
    float time = 0.0f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        image2.gameObject.SetActive(true);
        image1.gameObject.SetActive(true);      
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        image1.rectTransform.sizeDelta= new Vector2(7680 - (1920* speed * time), 4320 - (1080 * speed * time));
    }
}
