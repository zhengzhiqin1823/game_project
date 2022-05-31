using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start_fight : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public GameObject obj;
    public float speed;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time<=5)
        {
            image1.rectTransform.sizeDelta = new Vector2(1920 * speed * (time-0.5f), 1080 * speed * (time-0.5f));
            if (time >= (7680 / 1920 / speed)+0.5)
            {
                image1.gameObject.SetActive(false);
                image2.gameObject.SetActive(false);
                obj.SetActive(true);
            }
        }
    }
}
