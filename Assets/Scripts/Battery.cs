// Battery pickup
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float batteryAmount = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResourceBar.instance.AddBattery(batteryAmount);
            Destroy(gameObject);
        }
    }
}