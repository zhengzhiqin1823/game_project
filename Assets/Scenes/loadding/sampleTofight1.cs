using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class sampleTofight1 : MonoBehaviour
{
    public GameObject obj;
    public Image image1;
    public Image image2;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.transform.tag.Equals("hero"))
        {
            obj.GetComponent<heroctr>().enabled = false;
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(true);
        }
    }
}
