using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float lerpSpeed;
    
    private float offset;
    
    void Start()
    {
        if(target == null) return;
        offset = transform.position.z - target.transform.position.z;
    }

    private void FixedUpdate()
    {
        if(target == null) return;
        
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z + offset);
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}