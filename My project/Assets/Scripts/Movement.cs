using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private bool faceRight = true;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreAll;
    public static int score;
    public static int MaxCount;
    public int Count;
    public static bool trigIce = false;
    public static bool isLight = false;
    public static bool isFinish = false;
    public static string lightPrefab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MaxCount = Count;
        scoreText.text = string.Format("{0} / {1}", 0, MaxCount);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 3f;
        else if (trigIce)
            speed = 2f;
        else speed = 6f;
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
                scoreAll.text = string.Format("{0} / {1}", score, MaxCount);
                Destroy(collision.gameObject);
                if (score != MaxCount + 1)
                {
                    scoreText.text = string.Format("{0} / {1}", score, MaxCount);
                }
            }
        }
        if (collision.gameObject.tag == "Light")
        {
            isLight = true;
            lightPrefab = collision.name;
        }
        if (collision.gameObject.tag == "Finish")
        {
            isFinish = true;
            Debug.Log("jkgh");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            trigIce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            trigIce = false;
        }
    }
}
