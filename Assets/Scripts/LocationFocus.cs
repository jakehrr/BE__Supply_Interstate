using UnityEngine;

public class LocationFocus : MonoBehaviour
{
    [SerializeField] private ToolbarHandler toolbar;
    [SerializeField] private Animator cameraAnim;
    [SerializeField] private Animator triggerableAnim;

    [SerializeField] private bool zoomIn = false;

    private void Awake()
    {
        cameraAnim = GameObject.Find("CAMERA").GetComponent<Animator>();
        triggerableAnim = GameObject.Find("TRIGGERED").GetComponent<Animator>();    
    }

    public void MassZoomOut()
    {
        zoomIn = false;

        // Go back to default
        cameraAnim.SetBool("BapcoEnergies", zoomIn);
        cameraAnim.SetBool("BeVentures", zoomIn);
        cameraAnim.SetBool("BapcoUpstream", zoomIn);
        cameraAnim.SetBool("BapcoGas", zoomIn);
        cameraAnim.SetBool("BapcoRefining", zoomIn);
        cameraAnim.SetBool("BapcoTazweed", zoomIn);
        cameraAnim.SetBool("BapcoAirFueling", zoomIn);

        // Go back to default
        triggerableAnim.SetBool("Energies", zoomIn);
        triggerableAnim.SetBool("Ventures", zoomIn);
        triggerableAnim.SetBool("Upstream", zoomIn);
        triggerableAnim.SetBool("Gas", zoomIn);
        triggerableAnim.SetBool("Refining", zoomIn);
        triggerableAnim.SetBool("Tazweeds", zoomIn);
        triggerableAnim.SetBool("AirFueling", zoomIn);

        toolbar.EnableButtonsFromZoom();
    }

    public void BapcoEnergiesZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoEnergies", zoomIn);
        triggerableAnim.SetBool("Energies", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BeVenturesZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BeVentures", zoomIn);
        triggerableAnim.SetBool("Ventures", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BapcoUpstreamZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoUpstream", zoomIn);
        triggerableAnim.SetBool("Upstream", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BapcoGasZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoGas", zoomIn);
        triggerableAnim.SetBool("Gas", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BapcoRefiningZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoRefining", zoomIn);
        triggerableAnim.SetBool("Refining", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BapcoTazweedZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoTazweed", zoomIn);
        triggerableAnim.SetBool("Tazweeds", zoomIn);

        toolbar.DisableButtonsForZoom();
    }

    public void BapcoAirFuelingZoom()
    {
        zoomIn = !zoomIn;

        cameraAnim.SetBool("BapcoAirFueling", zoomIn);
        triggerableAnim.SetBool("AirFueling", zoomIn);

        toolbar.DisableButtonsForZoom();
    }
}
