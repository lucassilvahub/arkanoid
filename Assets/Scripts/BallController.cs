using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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
            if (paddle)
                transform.position = paddle.transform.position + Vector3.up * 0.5f;

            if (Input.GetKeyDown(KeyCode.Space))
                Launch();
        }
    }

    void FixedUpdate()
    {
        if (launched && rb.velocity.magnitude > 0.01f)
        {
            // Mantém a velocidade constante
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    void Launch()
    {
        launched = true;
        Vector2 dir = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
        rb.velocity = dir * speed;
    }

    public void ResetBall()
    {
        launched = false;
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Bounce especial no paddle
        if (coll.gameObject.CompareTag("Paddle"))
        {
            float paddleX = coll.transform.position.x;
            float hitX = coll.contacts[0].point.x;
            float offset = hitX - paddleX;
            float width = coll.collider.bounds.size.x;

            float ratio = offset / (width / 2f); // -1 .. 1
            Vector2 dir = new Vector2(ratio, 1f).normalized;
            rb.velocity = dir * speed;
        }
        else
        {
            // Corrige qualquer perda de energia nas colisões
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
