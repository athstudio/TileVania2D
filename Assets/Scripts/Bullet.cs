using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;

    Rigidbody2D rigidbody2D;
    PlayerMovement player;
    float xSpeed;
    
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        // Куда смотрит перс, туда и летят пули
        player = FindObjectOfType<PlayerMovement>(); 
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    
    void Update()
    {
        rigidbody2D.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
