using UnityEngine;

public class UILookAt : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private void LateUpdate()
    {
        Vector3 forward = cam.transform.forward;
        transform.rotation = Quaternion.LookRotation(forward);
    }
}
