using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool keycollected = false;
    public GameObject objcol;
    public GameObject mission;
    public GameObject keycard;
    public AudioSource asound;
    public GameObject key;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card")
        {
            //asound.Play();
            
            keycollected = true;
            Destroy(other);
            Debug.Log("pickup keycard");
            keycard.SetActive(false);
        }
    }

    private void Update()
    {
        if (keycollected == true)
        {
            mission.SetActive(false);
            objcol.SetActive(true);
            key.SetActive(true);
        }

        else if(keycollected == false)
        {
            mission.SetActive(true);
            objcol.SetActive(false);
        }
    }
}
