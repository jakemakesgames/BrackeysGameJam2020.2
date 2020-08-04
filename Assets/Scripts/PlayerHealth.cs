using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject[] bloodstains;
    public GameObject bloodFX;

    PlayerInput playerInput;
    Controller2D controller;

    bool hasBeenHurt;

    private float bleedoutTimer;
    public float timeBtwmBleedout;

    Shake shake;

    void Start()
    {
        controller = GetComponent<Controller2D> ();
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();
        playerInput = FindObjectOfType<PlayerInput>();

        hasBeenHurt = false;

        bleedoutTimer = Time.time;
    }

    void LateUpdate() 
    {
        if (hasBeenHurt)
        {
            if (playerInput.directionalInput != Vector2.zero && controller.collisions.below  || controller.collisions.left || controller.collisions.right
            || playerInput.directionalGamepadInput != Vector2.zero && controller.collisions.below || controller.collisions.left || controller.collisions.right)
            {
                if (Time.time - bleedoutTimer > timeBtwmBleedout)
                {
                    int rand = Random.Range(0, bloodstains.Length);

                    Instantiate(bloodstains[rand], transform.position, transform.rotation);
                    bleedoutTimer = Time.time;
                }   
                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            shake.CamShake();

            int rand = Random.Range(0, bloodstains.Length);

            GameObject blood = Instantiate(bloodstains[rand], transform.position, transform.rotation) as GameObject;
            GameObject GFX = Instantiate(bloodFX, transform.position, transform.rotation) as GameObject;

            transform.position = respawnPoint.transform.position;
            blood.gameObject.transform.parent = other.gameObject.transform;

            Destroy(GFX, 5f);

            hasBeenHurt = true;
        }
    }
}
