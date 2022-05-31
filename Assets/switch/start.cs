using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public void sample()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
