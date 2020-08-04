using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject[] bloodstains;
    public GameObject bloodFX;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            int rand = Random.Range(0, bloodstains.Length);

            Instantiate(bloodstains[rand], transform.position, transform.rotation);
            GameObject GFX = Instantiate(bloodFX, transform.position, transform.rotation) as GameObject;

            transform.position = respawnPoint.transform.position;

            Destroy(GFX, 5f);
        }
    }
}
