using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bossScenceload : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (this.transform.position.x <= 9)
        {
            Vector2 trans = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y);
            rigid.MovePosition(trans);
        }
    }
    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("Boss_Scene");
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (this.transform.position.x >= 9)
            {
                    async.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
