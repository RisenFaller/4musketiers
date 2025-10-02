using UnityEngine;

public class keyCardController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerKeyCardController>() != null)
        {
            PlayerKeyCardController playerKeyCardController = other.gameObject.GetComponent<PlayerKeyCardController>();
            playerKeyCardController.hasKey = true;
            Object.Destroy(this.gameObject);
        }
    }
}
