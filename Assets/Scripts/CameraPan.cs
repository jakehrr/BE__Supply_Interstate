using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [Header("Pan Settings")]
    [SerializeField] private float panSpeed = 2f;
    [SerializeField] private Vector2 xBounds = new Vector2(-50f, 50f);
    [SerializeField] private Vector2 yBounds = new Vector2(-30f, 30f);

    private InputSystem_Actions playerInputActions;

    private void Awake()
    {
        playerInputActions = new InputSystem_Actions();
        playerInputActions.Enable();
    }

    private void OnDestroy()
    {
        playerInputActions.Disable();
    }

    private void Update()
    {
        if (playerInputActions.Player.Attack.ReadValue<float>() == 1) 
        {
            Vector2 mouseInput = playerInputActions.Player.Look.ReadValue<Vector2>();

            // invert so dragging left moves camera left, etc.
            float moveX = -mouseInput.x * panSpeed * Time.deltaTime;
            float moveY = -mouseInput.y * panSpeed * Time.deltaTime;

            Vector3 newPos = transform.position + new Vector3(moveX, moveY, 0);

            // clamp inside bounds
            newPos.x = Mathf.Clamp(newPos.x, xBounds.x, xBounds.y);
            newPos.y = Mathf.Clamp(newPos.y, yBounds.x, yBounds.y);

            transform.position = newPos;
        }
    }

}
