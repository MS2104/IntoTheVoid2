using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pausecontrol : MonoBehaviour
{
    public bool Pauzechecker = false;
    public GameObject Pauze;
    public GameObject BG;
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pauzechecker = !Pauzechecker;
            if (Pauzechecker == true)
            {
                Pauze.SetActive(true);
                Time.timeScale = 0;
            }
            if (Pauzechecker == false)
            {
                Time.timeScale = 1;
                Pauze.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            Debug.Log("AAAAA");
        }
    }

    public void resume()
    {
        Debug.Log(" asdkasmdkasmdkasmd");
        Pauzechecker = false;
        Debug.Log(" asdkasmdkasmdkasmd");
        Time.timeScale = 1;
        Pauze.SetActive(false);
        BG.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void quit()
    {
        SceneManager.LoadScene("Main");
        Application.Quit();
        Debug.Log("isquitting");
    }
}
