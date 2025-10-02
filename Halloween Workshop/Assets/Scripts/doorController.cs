using System;
using Unity.VisualScripting;
using UnityEngine;

public class doorController : MonoBehaviour
{

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorhinge;

    private bool open = false;
    
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
            if (playerKeyCardController.hasKey)
            {
                openDoor();
            }
        }    }

    private void OnTriggerExit(Collider other)
    {
        if (open)
        {
            closeDoor();
        }
    }

    private void openDoor()
    {
        door.transform.RotateAround(doorhinge.transform.position, doorhinge.transform.up, -140);
        open = true;
    }

    private void closeDoor()
    {
        door.transform.RotateAround(doorhinge.transform.position, doorhinge.transform.up, 140);
        open = false;
    }
}
