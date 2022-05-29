using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class heroloadctr : MonoBehaviour
{
   private Rigidbody2D rigid;

    public Text progress;

    private AsyncOperation async = null;
    // Start is called before the first frame update
    void Start()
    {
         rigid = this.GetComponent<Rigidbody2D>();
        StartCoroutine("LoadScene");

    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x<=9)
        {
            Vector2 trans = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y);
            rigid.MovePosition(trans);
        }    
    }
    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("fight1");
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (this.transform.position.x>=9)
            {
                progress.text = "按任意键继续";
                if (Input.anyKeyDown)
                {
                    async.allowSceneActivation = true;
                }
            }
            yield return null;
        }

    }
}
