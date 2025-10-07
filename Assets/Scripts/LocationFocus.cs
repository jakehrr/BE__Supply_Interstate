using UnityEngine;

public class LocationFocus : MonoBehaviour
{
    [Header("FOV Handling Variables")]
    [SerializeField] private float FOVDefault = 2.76f;
    [SerializeField] private float FOVFocusedVal = 1.12f;
    [SerializeField] private float FOVZoomSpeed = 2f;
    [SerializeField] private float lerpSpeed = 2f;

    [Header("Position Vectors")]
    [SerializeField] private Vector3 defaultCameraPosition = new Vector3(-30.186f, 26.102f, -31.933f);
    [SerializeField] private Vector3[] focusedLocationVectors;

    [Header("Rotation Vectors")]
    [SerializeField] private Quaternion defaultCameraRotation = Quaternion.Euler(30f, 45f, 0f);
    [SerializeField] private Quaternion[] focusedRotationVectors;

    private CameraPan cameraPanScript;
    private bool beginZoom = false;
    private float lerpProgress = 0f;
    private int locationIndex;

    private Vector3 startPos;
    private Quaternion startRot;

    private void Start()
    {
        cameraPanScript = GetComponent<CameraPan>();
    }

    private void Update()
    {
        if (beginZoom)
        {
            lerpProgress += Time.deltaTime * lerpSpeed;
            float t = Mathf.Clamp01(lerpProgress);

            Vector3 targetPos = focusedLocationVectors[locationIndex];
            Quaternion targetRot = focusedRotationVectors[locationIndex];

            transform.position = Vector3.Lerp(startPos, targetPos, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(FOVDefault, FOVFocusedVal, t);

            if (t >= 1f)
            {
                beginZoom = false;
            }
        }
    }

    public void FocusOnTarget(int targetIndex)
    {
        cameraPanScript.enabled = false;
        locationIndex = targetIndex;

        startPos = transform.position;
        startRot = transform.rotation;
        lerpProgress = 0f;

        beginZoom = true;
    }
}
