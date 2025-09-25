using UnityEngine;

public class HappyJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpHeight = 1.5f;      // How high the object jumps
    public float jumpSpeed = 3f;         // How fast the object jumps
    public float stretchAmount = 0.2f;   // Amount of squash & stretch

    private Vector3 originalScale;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Make it bounce up and down happily
        float newY = startPos.y + Mathf.Abs(Mathf.Sin(Time.time * jumpSpeed)) * jumpHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Squash and stretch effect
        float stretch = 1 + Mathf.Sin(Time.time * jumpSpeed) * stretchAmount;
        float squash = 1 - Mathf.Sin(Time.time * jumpSpeed) * stretchAmount * 0.5f;

        transform.localScale = new Vector3(originalScale.x * squash, originalScale.y * stretch, originalScale.z * squash);
    }
}