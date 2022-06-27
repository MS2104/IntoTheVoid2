using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class target : MonoBehaviour
{
    public Slider slider;
    public float health = 50f;

    public void maxHealth()
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void TakeDamge(float amount)
    {
        health -= amount;
        slider.value = health;
        if (health <= 0f)
        {
            if(gameObject.tag == "Player")
            {
                Debug.Log("wryyy");
                SceneManager.LoadScene("gameover");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
            deaded();
        }

        

        void deaded()
        {
            Destroy(gameObject);
            Debug.Log("deadplayer");
        }
        
    }
    public void Start()
    {
        maxHealth();
    }
}
