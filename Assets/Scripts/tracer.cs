using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracer : MonoBehaviour
{
    [SerializeField]
    public Transform m_Target;
    [SerializeField]
    public float m_Speed;
    public Collider range;
    public bool outofrange;

    void Update()
    {
        
        if (outofrange == false)
        {
            Vector3 lTargetDir = m_Target.position - transform.position;
            lTargetDir.y = 0.0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * m_Speed);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            outofrange = false;
            
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
}
