using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private EnemyInfo info;
    [SerializeField] private float speedMultiplier;
    

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-10000, 10000), Random.Range(-10000, 10000)).normalized * info.speed * speedMultiplier;
    }

    void Update()
    {
        //draw ray
        //Debug.DrawRay(transform.position, transform.position + new Vector3(rb.velocity.x, rb.velocity.y, 0f), Color.red);
        LockVelocity();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
        }
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            //Debug.Log(collision.gameObject.transform.right);

            //float speed = rb.velocity.magnitude;
            //Vector2 direction = Vector2.Reflect(rb.velocity, collision.gameObject.transform.right).normalized;
            //rb.velocity = direction * speed; 
            rb.velocity = new Vector2(Random.Range(-10000, 10000), Random.Range(-10000, 10000)).normalized * info.speed * speedMultiplier;
        }
    }
    private void LockVelocity()
    {
        rb.velocity = rb.velocity.normalized * info.speed * speedMultiplier;
    }
}
