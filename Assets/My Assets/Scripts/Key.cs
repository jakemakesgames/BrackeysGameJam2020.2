using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag ("Player"))
        {
            door.SetActive(false);
            Destroy(gameObject);
        }
    }
}
