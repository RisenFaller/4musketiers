using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    public Flashlight flashlight;


    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            flashlight.ToggleLight();
        }
    }
}
