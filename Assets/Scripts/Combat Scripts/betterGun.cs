using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class betterGun : MonoBehaviour
{
    public Camera fpscam;
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem muzzleflash;
    public GameObject impacteffect;
    public float firerate = 15f;
    private float nextshot = 0f;
    public float ammo = 20;
    public Text textGameObject;
    public AudioSource shotsound;
    public AudioClip impact;
    public AudioSource battletheme;
    public AudioSource normaltheme;
    public bool playaudio = true;
    float decrease = 0.0005f;


    // Update is called once per frame
    void Update()
    {
        textGameObject.GetComponent<UnityEngine.UI.Text>().text = ammo.ToString();

        if (Input.GetButton("Fire1") && Time.time >= nextshot)
        {
            if (ammo > 0)
            {
                nextshot = Time.time + 1f / firerate;
                shoot();
                ammo -= 1;
                shotsound.PlayOneShot(impact, 0.7f);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 20;
            Debug.Log("reloaded");
        }

        void shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
            {
                muzzleflash.Play();

                Debug.Log(hit.transform.name);
                target2 target2 = hit.transform.GetComponent<target2>();

                if (target2 != null)
                {
                    target2.TakeDamge(damage);
                    StartCoroutine("StartSound");
                }

                GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }

        


    }
    IEnumerator StartSound()
    {
        // - After 0 seconds, prints "Starting 0.0"
        // - After 2 seconds, prints "WaitAndPrint 2.0"
        // - After 2 seconds, prints "Done 2.0"
        print("Starting " + Time.time);
        if(playaudio == true)
        {
            StartCoroutine("FadeOut");
            battletheme.Play();
            playaudio = false;
        }
        
        // Start function WaitAndPrint as a coroutine. And wait until it is completed.
        // the same as yield return WaitAndPrint(2.0f);
        yield return StartCoroutine(EndSound(20.0f));
        print("Done " + Time.time);
    }





    // suspend execution for waitTime seconds
    IEnumerator EndSound(float waitTime)
    {
     
        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
        
        if (battletheme.volume == 0f)
        {
            normaltheme.Play();
            StopCoroutine("FadeOut");
            battletheme.volume = 1f;
        }
        
        playaudio = true;
    }
    public IEnumerator FadeOut()
    {

        while (battletheme.volume < 1)
        {

            battletheme.volume -= decrease;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
