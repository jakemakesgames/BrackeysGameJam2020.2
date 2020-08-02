using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public int damage;

    public bool isPatrollingEnemy;
    public float speed;
    private bool movingRight = true;

    public Transform groundDetection;
    public float distance;

    public LayerMask whatIsGround;


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (!groundInfo.collider)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else 
            {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }
    }

    public void Die()
    {
        //rb2D.isKinematic = true;
        rb2D.gravityScale = 3f;
        rb2D.AddForce(new Vector2 (Random.Range(-200, 200), 600));
        transform.Rotate(new Vector3(0,0, Random.Range(-50, 50)));

        GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D col) 
    {

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().Hurt(damage);
        }
    }
}
