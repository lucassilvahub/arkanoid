using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points = 100;

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ball"))
        {
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
