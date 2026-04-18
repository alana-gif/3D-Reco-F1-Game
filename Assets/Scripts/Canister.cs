// Canister pickup
using UnityEngine;

public class Canister : MonoBehaviour
{
    public float canisterAmount = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResourceBar.instance.AddCanister(canisterAmount);
            Destroy(gameObject);
        }
    }
}