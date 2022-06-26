using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointcontroler : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetwaypointindex = 0;
    private float mindis = 0.1f;
    private int lastwaypointindex;

    public float movementspeed = 6;

    private float rotationspeed = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        lastwaypointindex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetwaypointindex];

    }

    // Update is called once per frame
    void Update()
    {
        float rotationstep = rotationspeed * Time.deltaTime;


        float movementstep = movementspeed * Time.deltaTime;

        Vector3 directiontotarget = targetWaypoint.position - transform.position;
        Quaternion rotationtotarget = Quaternion.LookRotation(directiontotarget);
        transform.rotation = rotationtotarget;


        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        Checkdistancetowaypoint(distance);




        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementstep);


    }

    void Checkdistancetowaypoint(float currentDistance)
    {
        if (currentDistance <= mindis)
        {
            targetwaypointindex++;
            UpdatetargetWaypoint();

        }

    }

    void UpdatetargetWaypoint()
    {
        if (targetwaypointindex > lastwaypointindex)
        {


            targetwaypointindex = 0;
        }



        targetWaypoint = waypoints[targetwaypointindex];





    }
}
