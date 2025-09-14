using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;
    private bool launched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        ResetBall();
    }

    void Update()
    {
        if (!launched)
        {
            GameObject paddle = GameObject.Find("Paddle");
            if (paddle) transform.position = paddle.transform.position + Vector3.up * 0.5f;

            if (Input.GetKeyDown(KeyCode.Space)) Launch();
        }
    }

    void Launch()
    {
        launched = true;
        rb.velocity = new Vector2(1, 1).normalized * speed;
    }

    public void ResetBall()
    {
        launched = false;
        rb.velocity = Vector2.zero;
    }
}
