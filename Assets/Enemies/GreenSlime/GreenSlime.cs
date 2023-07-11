using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : Entity
{
    private float speed = 1.0f;
    private Vector3 dir;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        isDie = false;
        lives = 1;
        dir = transform.right;
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 1f + transform.right * dir.x * 0.7f, 0.1f);

        if (colliders.Length > 0 )
        {
            if (colliders[0].gameObject != Hero.Instance.gameObject)
            {
                dir *= -1f;
            }
            
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }

        if (lives < 1)
        {
            Die();
        }
    }
}