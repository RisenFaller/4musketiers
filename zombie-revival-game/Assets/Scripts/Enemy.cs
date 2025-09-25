using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    public float speed = 5f;          // Movement speed
    public float touchDistance = 1f;  // Distance to trigger the effect

    private void OnEnable()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Move towards the player
        transform.LookAt(playerTransform);
        transform.position += transform.forward * speed * Time.deltaTime;

        // Check if close enough to trigger
        TouchPlayer();
    }

    private void TouchPlayer()
    {
        RaycastHit hit;

        // Cast a small sphere in front to detect the player
        if (Physics.SphereCast(transform.position, 0.1f, transform.forward, out hit, touchDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                // Enable HappyJump
                HappyJump jump = GetComponent<HappyJump>();
                if (jump != null)
                    jump.enabled = true;

                // Stop this script so the enemy stops moving
                this.enabled = false;
            }
        }
    }
}