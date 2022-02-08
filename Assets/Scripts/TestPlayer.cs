using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPlayer : MonoBehaviour

{

    [Tooltip("The player movement speed.")]

    public float speed;

    [Tooltip("The jump height")]

    public float jumpForce;


    private float direction = 1;

    private Rigidbody2D rb2D;

    private bool jumpReady = true;

    SpriteRenderer sr;

    public Sprite[] side;

    int frameIndex = 0;

    float frameTimer;

    public float fps = 10;



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



        if (Input.GetKeyDown(KeyCode.Space) && jumpReady)

        {

            movement.y = jumpForce;

            jumpReady = false;

        }


        if (frameTimer <= 0)

        {

            if (frameIndex >= 3)

            {

                frameIndex = 0;

            }

            else

            {

                frameIndex++;

            }


            sr.sprite = side[frameIndex];

            frameTimer = (0.5f / fps);

        }


        rb2D.velocity = movement;

    }


    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("Wall"))

        {

            direction *= -1;

            sr.flipX = !sr.flipX;

            //rb2D.velocity *= direction;

        }

        else if (collision.gameObject.CompareTag("Floor"))

        {

            jumpReady = true;

        }

        else if (collision.gameObject.CompareTag("Spikes"))

        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        

    }


    private void OnCollisionExit2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("Floor"))

        {

            jumpReady = false;

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Coin"))

        {

            collision.gameObject.GetComponent<Coin>().Collect();

        }

        else if (collision.gameObject.CompareTag("Portal"))

        {

            collision.gameObject.GetComponent<ExitPortal>().teleport();

        }

    }

}