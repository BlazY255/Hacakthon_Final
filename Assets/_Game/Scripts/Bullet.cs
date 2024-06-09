using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == Constants.Player || hitInfo.gameObject.tag == Constants.Wall || hitInfo.gameObject.tag == Constants.Ground|| hitInfo.gameObject.tag == Constants.Laser)
        {
            Destroy(gameObject);
        }
        if (hitInfo.CompareTag("Player"))
        {
            GameManager.instance.Die();
            Debug.Log("DEAD");
        }
       
    }
}