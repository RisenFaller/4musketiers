using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    
    [SerializeField] Camera _camera;
    [SerializeField] float moveSpeed;
    
    private Vector3 goalPosition;
    private bool needsToMove = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (needsToMove)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, goalPosition, moveSpeed * Time.deltaTime);
            if (this.transform.position == goalPosition)
            {
                needsToMove = false;
            }
        }
    }

    void OnClick(InputValue value)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Debug.Log(mousePosition);
        Ray cameraRay = _camera.ScreenPointToRay(mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(cameraRay);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    goalPosition = hit.point;
                    needsToMove = true;
                }
            }
        }
    }
}
