using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private bool faceLeft = true;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreAll;
    public static int score;
    public static int MaxCount;
    public int Count;
    public static bool trigIce = false;
    public static bool isLight = false;
    public static bool isFinish = false;
    public static string lightPrefab;
    public Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        anim.SetFloat("Horizontal", Mathf.Abs(moveVector.x));
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Vertical", Mathf.Abs(moveVector.y));

        //if (!faceLeft && moveVector.x < 0)
        //{
        //    Flip();
        //}
        //else if (faceLeft && moveVector.x > 0)
        //{
        //    Flip();
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    anim.SetFloat("moveTop", Mathf.Abs(moveVector.y));
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    anim.SetFloat("moveDown", Mathf.Abs(moveVector.y));
        //}
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        faceLeft = !faceLeft;
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
            Debug.Log(isFinish);
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
