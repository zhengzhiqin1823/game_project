using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderControl : MonoBehaviour
{
    public int count;

    public Vector3 src, dest, direction;

    public GameObject thunder;

    // Start is called before the first frame update
    void Start()
    {
        count = DragonScript.hero_energy;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            GameObject.Instantiate(thunder);
        count = DragonScript.hero_energy;
        if (count>=1)
        {
            count = 0;
            DragonScript.hero_energy = count;
            src = GameObject.Find("hero").transform.position;
            dest= GameObject.Find("Boss").transform.position;
            direction = (dest - src).normalized;
            GameObject obj = GameObject.Instantiate(thunder);
            thunder.GetComponent<Thunder>().go = true;
            //obj.transform.position = GameObject.Find("hero").transform.position;
            
        }
    }
}
