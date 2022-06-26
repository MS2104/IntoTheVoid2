using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIshooting : MonoBehaviour
{
    public Camera fpscam;
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem muzzleflash;
    public float firerate = 15f;
    private float nextshot = 0f;
    public tracer tracer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(tracer.outofrange == false)
        {
            if (Time.time >= nextshot)
            {
                nextshot = Time.time + 1f / firerate;
                shoot();
            }
        } 
    }
    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {

            Debug.Log("niggabals");
            Debug.Log(hit.transform.name);
            target target = hit.transform.GetComponent<target>();

            if (target != null)
            {
                target.TakeDamge(damage);
                
            }

            
        }
    }
}
