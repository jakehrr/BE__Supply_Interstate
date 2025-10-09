using UnityEngine;

public class LocationFocus : MonoBehaviour
{
    [SerializeField] private ToolbarHandler toolbar;
    [SerializeField] private Animator cameraAnim;

    [SerializeField] private bool zoomIn = false;

    private void Awake()
    {
        cameraAnim = GameObject.Find("CAMERA").GetComponent<Animator>();
    }

    public void MassZoomOut()
    {
        zoomIn = false;

        cameraAnim.SetBool("BapcoEnergies", zoomIn);
        cameraAnim.SetBool("BeVentures", zoomIn);
        cameraAnim.SetBool("BapcoUpstream", zoomIn);
        cameraAnim.SetBool("BapcoGas", zoomIn);

        toolbar.EnableButtonsFromZoom();
    }

    public void BapcoEnergiesZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoEnergies", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BeVenturesZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BeVentures", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BapcoUpstreamZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoUpstream", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BapcoGasZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoGas", zoomIn);

        toolbar.DisableButtonsForZoom();
    }
}
