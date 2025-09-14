using UnityEngine;

public class BottomTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Ball"))
        {
            GameManager.Instance.LoseLife();
            c.GetComponent<BallController>().ResetBall();
        }
    }
}
