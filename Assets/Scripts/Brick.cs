using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points = 100;

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = c.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                // Reflete a bola com base na normal do ponto de colisão
                Vector2 normal = c.contacts[0].normal;
                ballRb.velocity = Vector2.Reflect(ballRb.velocity, normal).normalized * ballRb.velocity.magnitude;
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(points);
                GameManager.Instance.BrickDestroyed();
            }
            else
            {
                Debug.LogWarning("GameManager não encontrado!");
            }

            Destroy(gameObject);
        }
    }
}
