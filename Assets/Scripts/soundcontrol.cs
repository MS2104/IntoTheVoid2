using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundcontrol : MonoBehaviour
{
    public AudioSource osund;
    float speed = 0.0005f;
    private IEnumerator FadeOut()
    {
        
        while (osund.volume < 1)
        {

            osund.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("FadeOut");
        }
    }
}
