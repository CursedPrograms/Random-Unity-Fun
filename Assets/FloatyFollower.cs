using UnityEngine;

[DisallowMultipleComponent]
public class FloatyFollower : MonoBehaviour
{
    public Transform target;      
    public float speed = 2.0f;    
    public float rotationSpeed = 5.0f;    
    public float floatAmplitude = 0.5f;       
    public float floatFrequency = 1.0f;       
    public float turnSmoothness = 0.1f;      

    Vector3 initialPosition;     
    float randomOffset;        

    void Start()
    {
        initialPosition = transform.position;
        randomOffset = Random.Range(0.0f, 2.0f * Mathf.PI);         
    }

    void Update()
    {
        if (target == null) return;
        Vector3 floatOffset = new Vector3(0.0f, Mathf.Sin(Time.time * floatFrequency + randomOffset) * floatAmplitude, 0.0f);
        Vector3 targetDirection = (target.position + floatOffset) - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        Vector3 movement = Vector3.Lerp(transform.position, target.position + floatOffset, speed * Time.deltaTime);
        transform.position = movement;
    }
}
