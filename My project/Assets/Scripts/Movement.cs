using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private bool faceRight = true;
    public TextMeshProUGUI scoreText;
    public static int score;
    public static int MaxCount;
    public int Count;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MaxCount = Count;
        scoreText.text = string.Format("{0} / {1}", 0, MaxCount);
    }


    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
            speed = 6f;
        else speed = 3f;
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
            if (TimeCounter.TimeRemaining > 0)
            {
                score++;
                Destroy(collision.gameObject);
                if (score != MaxCount + 1)
                {
                    scoreText.text = string.Format("{0} / {1}", score, MaxCount);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            speed = 3f;
            Debug.Log("gd");
        }
    }
}
