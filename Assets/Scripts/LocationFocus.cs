using UnityEngine;

public class LocationFocus : MonoBehaviour
{
    [SerializeField] private Animator cameraAnim;

    [SerializeField] private bool bapcoGasFocus;
    [SerializeField] private bool bapcoUpstreamFocus;
    [SerializeField] private bool bapcoEnergiesFocus;
    [SerializeField] private bool beVenturesFocus;

    private void Awake()
    {
        cameraAnim = GameObject.Find("CAMERA").GetComponent<Animator>();
    }

    public void BapcoGasZoom()
    {
        bapcoGasFocus = !bapcoGasFocus;

        cameraAnim.SetBool("BapcoGas", bapcoGasFocus);
    }

    public void BapcoUpstreamZoom()
    {
        bapcoUpstreamFocus = !bapcoUpstreamFocus;

        cameraAnim.SetBool("BapcoUpstream", bapcoUpstreamFocus);
    }

    public void BapcoEnergiesZoom()
    {
        bapcoEnergiesFocus = !bapcoEnergiesFocus;

        cameraAnim.SetBool("BapcoEnergies", bapcoEnergiesFocus);
    }

    public void BeVenturesZoom()
    {
        beVenturesFocus = !beVenturesFocus;

        cameraAnim.SetBool("BeVentures", beVenturesFocus);
    }
}
