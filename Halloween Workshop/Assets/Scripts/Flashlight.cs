using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    private Light spotlight;
    private bool isOn = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spotlight = GetComponentInChildren<Light>();
        spotlight.enabled = isOn;
        Debug.Log(isOn);
    }

    public void ToggleLight()
    {
        isOn = !isOn;
        spotlight.enabled = isOn;
        Debug.Log(isOn);
    }
}
