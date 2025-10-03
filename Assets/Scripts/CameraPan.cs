using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [Header("Pan Settings")]
    [SerializeField] private float panSpeed = 2f;
    [SerializeField] private float smoothTime = 0.15f; // lower = snappier, higher = smoother
    [SerializeField] private Vector2 xBounds = new Vector2(-50f, 50f);
    [SerializeField] private Vector2 yBounds = new Vector2(-30f, 30f);
    [SerializeField] private Vector2 zBounds = new Vector2(-30f, 30f);

    private InputSystem_Actions playerInputActions;

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        playerInputActions = new InputSystem_Actions();
        playerInputActions.Enable();
        targetPosition = transform.localPosition;
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

            Vector3 moveDir = (-mouseInput.x * transform.right + -mouseInput.y * transform.up) * panSpeed * Time.deltaTime;

            targetPosition += moveDir;

            // Clamp the target position
            targetPosition.x = Mathf.Clamp(targetPosition.x, xBounds.x, xBounds.y);
            targetPosition.y = Mathf.Clamp(targetPosition.y, yBounds.x, yBounds.y);
            targetPosition.z = Mathf.Clamp(targetPosition.z, zBounds.x, zBounds.y);
        }

        // Smoothly move the camera towards the target
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, smoothTime);
    }
}
