using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    private float bakedRotation = 145.69f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.linearDamping = 5f;
        rb.angularDamping = 10f;
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");     // W/S
        float horizontal = Input.GetAxis("Horizontal"); // A/D

        transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);

        Vector3 forward = Quaternion.Euler(0, -bakedRotation, 0) * transform.forward;
        Vector3 move = forward * -vertical * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}


//debug attempts 
//////using UnityEngine;

//////public class CarController : MonoBehaviour
//////{


////////    void Update()
////////    {
////////        if (Input.GetKey(KeyCode.W))
////////        {
////////            Debug.Log("W pressed - transform.forward = " + transform.forward);
////////            Debug.Log("W pressed - transform.right = " + transform.right);
////////            Debug.Log("W pressed - actual move direction = " + (transform.forward * Input.GetAxis("Vertical")));
////////        }
////////    }
//////}