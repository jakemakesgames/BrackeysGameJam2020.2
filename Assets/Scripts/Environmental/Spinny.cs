using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinny : MonoBehaviour
{
    private float rotZ;
    public float rotationSpeed;
    public bool clockwiseRotation;

    public bool stationarySawblade;

    public bool pivotSawblade;
    public GameObject pivotPoint;

    void Update()
    {
        if (stationarySawblade)
        {
            if (!clockwiseRotation)
        {
            rotZ += Time.deltaTime * rotationSpeed;
        } 
        else 
        {
            rotZ -= Time.deltaTime * rotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0,0, rotZ);
        }

        if (pivotSawblade)
        {
            transform.RotateAround(pivotPoint.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }


}
