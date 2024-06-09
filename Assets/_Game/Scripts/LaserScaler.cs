using UnityEngine;

public class LaserScaler : MonoBehaviour
{
    public Transform laser;

    private Vector3 originalScale;
    private Vector3 originalPosition;
    public float maxDistance = 100f;
    public LayerMask groundLayer;

    private void Start()
    {
        originalScale = laser.localScale;
        originalPosition = laser.position;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, maxDistance, groundLayer);

        Debug.DrawRay(transform.position, Vector2.up * maxDistance, Color.red);

        if (hit.collider != null)
        {
            float distance = Vector2.Distance(transform.position, hit.point);
            laser.localScale = new Vector3(laser.localScale.x, distance/1.95f, laser.localScale.z);
            laser.position = transform.position + Vector3.up * 0.48f;
        }
        else
        {
            laser.localScale = originalScale;
            laser.position = originalPosition;
        }
    }
}