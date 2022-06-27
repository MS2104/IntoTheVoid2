using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracer : MonoBehaviour
{
    [SerializeField]
    public GameObject m_Target;
    [SerializeField]
    public float m_Speed;
    public Collider range;
    public bool outofrange;
    public Camera fpscam;
    public float damage = 10f;
    public ParticleSystem muzzleflash;
    public float firerate = 15f;
    private float nextshot = 0f;
    public waypointcontroler Walking;
    public float ranges;

    void Update()
    {

        if (outofrange == true)
        {
            Walking.enabled = true;
            Debug.Log("walkagain");
        }

        if (outofrange == false)
        {
            Vector3 lTargetDir = m_Target.gameObject.transform.position - transform.position;
            lTargetDir.y = 0.0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * m_Speed);
            Debug.Log("tracking");

            if (Time.time >= nextshot)
            {
                nextshot = Time.time + 1f / firerate;
                shoot();
            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            outofrange = false;
            Walking.enabled = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            outofrange = true;
        }
    }
    private void Start()
    {

        outofrange = true;
    }




    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, ranges))
        {
            Walking.enabled = false;
            Debug.Log("Should be shooting");
            Debug.Log(hit.transform.name);
            target target = hit.transform.GetComponent<target>();

            if (target != null)
            {
                Debug.Log("HittedPlayer");
                target.TakeDamge(damage);

            }


        }
    }
}
