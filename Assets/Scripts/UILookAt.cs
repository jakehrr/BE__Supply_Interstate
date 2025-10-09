using UnityEngine;

public class UILookAt : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private void Awake()
    {
        cam = GameObject.Find("CAMERA").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 forward = cam.transform.forward;
        transform.rotation = Quaternion.LookRotation(forward);
    }
}
