using UnityEngine;

public class Collect : MonoBehaviour
{

    private string playerTag = "Player";

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            // Add logic for when the player collects the item
            Debug.Log("Item Collected!");
            Destroy(this);
        }
    }

}
