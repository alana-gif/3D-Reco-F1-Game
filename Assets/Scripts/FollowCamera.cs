using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform car;
    public float smoothSpeed = 5f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - car.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = car.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(car);
    }
}