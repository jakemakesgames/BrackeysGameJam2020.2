using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public bool isRewinding = false; // are we currently rewinding?
    
    List<PointInTime> pointsInTime; // a list of PointsInTime (refer to PointInTime class)

    public float recordTime = 5f;

    public GameObject trail;

    void Start()
    {
        pointsInTime = new List<PointInTime>();
    }

    void Update()
    {
        // if the enter key is being pressed down, call the StartRewind function
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        
        // if the enter key has been released, call the StopRewind function
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }

    void FixedUpdate() 
    {
        // if we ARE rewinding, call the "Rewind" function, else call the "Record" function
        if (isRewinding)
        {
            Rewind();
        } else 
        {
            Record(); 
        }
    }
    
    void Rewind()
    {
        // if the pointInTime count is GREATER THAN 0
        if (pointsInTime.Count > 0)
        {
            // add a point in time into the list at index 0, log the position and rotation of this object


            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;

            Instantiate(trail, transform.position, transform.rotation);
            pointsInTime.RemoveAt(0);
        } 
        else 
        {
            // call the StopRewind function
            StopRewind();
        }
        
    }

    // a function to Record the points in time
    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    void StartRewind()
    {
        // ensure we set isRewinding to true
        isRewinding = true;
        PlayerController.instance.rb2D.isKinematic = true;
    }

    void StopRewind()
    {
        // enduse we set isRewinding to false
        isRewinding = false;
        PlayerController.instance.rb2D.isKinematic = false;
    }
}
