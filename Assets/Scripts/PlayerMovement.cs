using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The player movement speed.")]
    public float speed;
    [Tooltip("The jump height")]
    public float jumpForce;

    private float direction = 1;
    private Rigidbody2D rb2D;
    SpriteRenderer sr;
    public Sprite[] side;
    int frameIndex = 0;
    float frameTimer;
    public float fps = 5;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(1, 0) * speed * direction;
        rb2D.velocity = movement;
        sr = GetComponent<SpriteRenderer>();
        frameTimer = (0.5f / fps);

    }

    void Update()
    {
        Vector2 movement = new Vector2(1, 0) * speed * direction;
        movement.y = rb2D.velocity.y;
        frameTimer -= Time.deltaTime;
        if(frameTimer >= 0)
        {
            if(frameIndex >= 3)
            {
                frameIndex = 0;
            }
            else
            {
                frameIndex++;
            }
            
            sr.sprite = side[frameIndex];
            frameTimer = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.y = jumpForce;
        }

        rb2D.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
            sr.flipX = !sr.flipX;
        }
    }
}
