using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{
    [Header("Camera Look Variables")]
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private Transform worldOrigin;
    [SerializeField] private float targetDistance;
    [SerializeField] private float smoothTime = 3f;

    [Header("Focus Targets")]
    [SerializeField] private Transform[] focusTargets;
    [SerializeField] private float orbitSpeed = 20f;
    [SerializeField] private GameObject focusedUI;

    [Header("Private Variables")]
    private float XRotation;
    private float YRotation;
    private Vector3 currentRotation;
    private Vector3 nextRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    private bool isOrbiting = false;
    private Transform currentFocusTarget;
    private Camera cam;

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

    private void Start()
    {
        cam = GetComponent<Camera>();

        currentRotation = transform.localEulerAngles;
        nextRotation = currentRotation;
        XRotation = currentRotation.y;
        YRotation = currentRotation.x;
    }

    private void Update()
    {
        if (!isOrbiting)
        {
            UserInputCameraRotation();
        }
        else
        {
            HandleOrbit();
        }

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        Transform pivot = isOrbiting && currentFocusTarget != null ? currentFocusTarget : worldOrigin;
        transform.position = pivot.position - transform.forward * targetDistance;
    }

    private void UserInputCameraRotation()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            XRotation += mouseX;
            YRotation += mouseY;
            YRotation = Mathf.Clamp(YRotation, 30, 45);

            nextRotation = new Vector3(YRotation, XRotation, 0);
        }
    }

    private void HandleOrbit()
    {
        if (currentFocusTarget == null)
            return;

        XRotation += orbitSpeed * Time.deltaTime;
        YRotation = Mathf.Clamp(YRotation, 30, 45);

        nextRotation = new Vector3(YRotation, XRotation, 0);
    }

    public void FocusOnTarget(int index)
    {
        if (index < 0 || index >= focusTargets.Length) return;

        currentFocusTarget = focusTargets[index];
        cam.orthographicSize = 8;
        focusedUI.SetActive(true);
        isOrbiting = true;
    }

    public void StopOrbit()
    {
        cam.orthographicSize = 12;
        focusedUI.SetActive(false);
        isOrbiting = false;
        currentFocusTarget = null;
    }
}
