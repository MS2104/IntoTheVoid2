using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject leftdoor;
    public GameObject rightdoor;

    public Vector3 leftTarget;
    public Vector3 rightTatget;

    public Vector3 leftstart;
    public Vector3 rightstart;
    void Start()
    {
        leftstart = leftdoor.transform.localPosition;
        rightstart = rightdoor.transform.localPosition;
    }

 
    void Update()
    {
        
    }

    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(openthedoor(leftdoor, leftTarget));
        StartCoroutine(openthedoor(rightdoor, rightTatget));
    }

    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(openthedoor(leftdoor, leftstart));
        StartCoroutine(openthedoor(rightdoor, rightstart));
    }

    private IEnumerator openthedoor(GameObject door, Vector3 target)
    {
        Debug.Log("ik ga nu open ");
        while(door.transform.localPosition != target)
        {
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, target, Time.deltaTime * 1.0f);
            yield return null;
        }
    }
}
