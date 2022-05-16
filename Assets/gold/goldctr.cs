using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldctr : MonoBehaviour
{
    public int goldnum;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.transform.tag.Equals("hero"))
        {
            heroctr ctr = g.GetComponent<heroctr>();
            ctr.goldChange(goldnum);
            GameObject.Destroy(this.gameObject);
        }
    }
    public void setnum(int amount)
    {
        this.goldnum = amount;
    }
}
