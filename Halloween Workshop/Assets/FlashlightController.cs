using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    public Flashlight flashlight;

    void OnAttack()
    {
        flashlight.ToggleLight();
        Debug.Log("hi");
    }
}
