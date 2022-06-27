using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitch : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quit()
    {
        SceneManager.LoadScene("Main");
        //Application.Quit();
        Debug.Log("isquitting");
    }
}
