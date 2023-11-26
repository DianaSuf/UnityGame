using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private bool faceRight = true;
    public Text scoreText;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        if (!faceRight && moveVector.x > 0)
        {
            Flip();
            Debug.Log("right");
        }
        else if (faceRight && moveVector.x < 0)
        {
            Flip();
            Debug.Log("left");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CollectiveSquare")
        {
            if (Timer.TimeRemaining > 0)
            {
                score++;
                Destroy(collision.gameObject);
                if (score != 3)
                    scoreText.text = "Score: " + score;
                else
                    scoreText.text = "All Collected!";
            }
        }
    }
}
