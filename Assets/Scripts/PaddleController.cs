using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * speed * Time.deltaTime);

        // limitar movimento
        float x = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector3(x, transform.position.y, 0);
    }
}
