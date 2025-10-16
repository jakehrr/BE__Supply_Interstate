using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarHandlerV2 : MonoBehaviour
{
    private int buttonIndex;

    [Header("Generic References")]
    [SerializeField] private ExploreTextScroll textScrollScript;
    [SerializeField] private LocationFocus zoomOutReference;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator connectionAnim;
    //[SerializeField] private GameObject[] connectionGo;
    [SerializeField] private GameObject[] worldspaceLocationBoxes;
    [SerializeField] private GameObject[] allMainPanelButtons;
    [SerializeField] private GameObject[] allExpandedButtons;
    [SerializeField] private GameObject[] allScrollingButtons;

    [Header("UI Change Elements")]
    [SerializeField] private string[] locationNames;
    [SerializeField] private string[] text1Paragraphs;
    [SerializeField] private string[] text2Paragraphs;
    [SerializeField] private string[] scrollingTextParagraph;

    [Header("Primary Text References")]
    [SerializeField] private TextMeshProUGUI namedLocationBox;
    [SerializeField] private TextMeshProUGUI textSet1;
    [SerializeField] private TextMeshProUGUI textSet2;
    [SerializeField] private TextMeshProUGUI scrollingTextSet1;
    [SerializeField] private TextMeshProUGUI scrollingTextSet2;

    [Header("Main UI Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject expandedPanel;
    [SerializeField] private GameObject scrollingExplore;

    public void ExtendedPanelOpen(int index)
    {
        foreach(GameObject go in allMainPanelButtons)
            go.GetComponent<Button>().enabled = false;
        foreach(GameObject go in allExpandedButtons)
            go.GetComponent<Button>().enabled = false;
        foreach(GameObject go in worldspaceLocationBoxes)
            go.SetActive(false);

        worldspaceLocationBoxes[index].SetActive(true);
        buttonIndex = index;
        namedLocationBox.text = locationNames[index];
        textSet1.text = text1Paragraphs[index];
        textSet2.text = text2Paragraphs[index];

        anim.SetBool("ExpandedPanel", true);
        anim.SetBool("MainPanel", false);

        StartCoroutine(ExtendedPanelOpenTimer());
    }

    public void ExpandedPanelClose()
    {
        anim.SetBool("ExpandedPanel", false);
        anim.SetBool("MainPanel", true);
        foreach (GameObject go in worldspaceLocationBoxes)
            go.SetActive(false);
        StartCoroutine(MainPanelOpenTimer());
    }

    public void ScrollingExplore()
    {
        foreach(GameObject go in allExpandedButtons)
            go.GetComponent<Button>().enabled = false;

        zoomOutReference.ZoomOutForScroll();

        anim.SetBool("ExpandedPanel", false);
        anim.SetBool("ExploreScroll", true);

        scrollingTextSet1.text = scrollingTextParagraph[buttonIndex];
        scrollingTextSet2.text = scrollingTextParagraph[buttonIndex];

        // We are using this switch case to change the settings variables in the explore text scroll. 
        ChangeScrollSettings();
        textScrollScript.enabled = true;
        textScrollScript.ResetTextPos();

        StartCoroutine(ScrollingPanelOpenTimer());
    }

    public void ExpandedPanelFromExplore()
    {
        foreach(GameObject go in allScrollingButtons)
            go.GetComponent<Button>().enabled = false;

        foreach (GameObject go in worldspaceLocationBoxes)
            go.SetActive(false);

        worldspaceLocationBoxes[buttonIndex].gameObject.SetActive(true);
        HandleCameraFromScrollToExpanded();
        connectionAnim.SetInteger("ConnectionState", 0);
        anim.SetBool("ExpandedPanel", true);
        anim.SetBool("ExploreScroll", false);

        textScrollScript.enabled = false;
        StartCoroutine(ExpandedPanelFromScrollTimer());
    }

    public void MapFromScroll()
    {
        foreach (GameObject go in allScrollingButtons)
            go.GetComponent<Button>().enabled = false;

        foreach (GameObject go in worldspaceLocationBoxes)
            go.SetActive(false);

        connectionAnim.SetInteger("ConnectionState", 0);

        anim.SetBool("MainPanel", true);
        anim.SetBool("ExploreScroll", false);

        textScrollScript.enabled = false;

        StartCoroutine(MapFromScrollTimer());
    }

    private void ChangeScrollSettings()
    {
        switch (buttonIndex)
        {
            case 0:
                // Bapco Energies
                textScrollScript.endTop = -161f;
                textScrollScript.endBottom = 161f;
                textScrollScript.beginSecondThreshold = 80f;
                textScrollScript.scrollDuration = 25f;

                foreach (GameObject go in worldspaceLocationBoxes)
                    go.SetActive(true);

                connectionAnim.SetInteger("ConnectionState", 1);

                break;
            case 1:
                // BeVentures
                textScrollScript.endTop = -161f;
                textScrollScript.endBottom = 161f;
                textScrollScript.beginSecondThreshold = 80f;
                textScrollScript.scrollDuration = 25f;

                foreach (GameObject go in worldspaceLocationBoxes)
                    go.SetActive(true);

                connectionAnim.SetInteger("ConnectionState", 2);

                break;
            case 2:
                // Bapco Upstream
                textScrollScript.endTop = -187f;
                textScrollScript.endBottom = 187f;
                textScrollScript.beginSecondThreshold = 115f;
                textScrollScript.scrollDuration = 25f;

                worldspaceLocationBoxes[3].SetActive(true);
                worldspaceLocationBoxes[4].SetActive(true);

                connectionAnim.SetInteger("ConnectionState", 3);

                break;
            case 3:
                // Bapco Gas
                textScrollScript.endTop = -195f;
                textScrollScript.endBottom = 195f;
                textScrollScript.beginSecondThreshold = 133f;
                textScrollScript.scrollDuration = 25f;

                foreach (GameObject go in worldspaceLocationBoxes)
                    go.SetActive(true);

                connectionAnim.SetInteger("ConnectionState", 4);

                break;
            case 4:
                // Bapco Refining
                textScrollScript.endTop = -456f;
                textScrollScript.endBottom = 456f;
                textScrollScript.beginSecondThreshold = 370f;
                textScrollScript.scrollDuration = 50f;

                break;
            case 5:
                // Bapco Tazweed
                textScrollScript.endTop = -382;
                textScrollScript.endBottom = 382f;
                textScrollScript.beginSecondThreshold = 290f;
                textScrollScript.scrollDuration = 50f;

                break;
            case 6:
                // Bapco Air Fueling
                textScrollScript.endTop = -312;
                textScrollScript.endBottom = 312f;
                textScrollScript.beginSecondThreshold = 238f;
                textScrollScript.scrollDuration = 50f;

                break;
        }
    }

    private void HandleCameraFromScrollToExpanded()
    {
        switch (buttonIndex)
        {
            case 0:
                // Bapco Energies Camera Zoom
                zoomOutReference.BapcoEnergiesZoom();
                break;

            case 1:
                // BeVentures Camera Zoom
                zoomOutReference.BeVenturesZoom();
                break;

            case 2:
                // Bapco Upstream Camera Zoom

                break;

            case 3:
                // Bapco Gas Camera Zoom

                break;

            case 4:
                // Bapco Refining Camera Zoom

                break;

            case 5:
                // Bapco Tazweed Camera Zoom

                break;

            case 6:
                // Bapco Air Fueling Camera Zoom

                break;
        }
    }

    // Timer Enumerator Methods
    private IEnumerator ExtendedPanelOpenTimer()
    {
        yield return new WaitForSeconds(1f);
        mainPanel.SetActive(false);
        expandedPanel.SetActive(true);

        yield return new WaitForSeconds(1f);
        foreach (GameObject go in allExpandedButtons)
            go.GetComponent<Button>().enabled = true;
    }

    private IEnumerator MainPanelOpenTimer()
    {
        yield return new WaitForSeconds(1f);
        expandedPanel.SetActive(false);
        mainPanel.SetActive(true);

        yield return new WaitForSeconds(1f);
        foreach (GameObject go in allMainPanelButtons)
            go.GetComponent<Button>().enabled = true;
    }

    private IEnumerator ScrollingPanelOpenTimer()
    {
        yield return new WaitForSeconds(1f);
        expandedPanel.SetActive(false);
        scrollingExplore.SetActive(true);

        yield return new WaitForSeconds(1f);
        foreach(GameObject go in allScrollingButtons)
            go.GetComponent<Button>().enabled = true;
    }

    private IEnumerator ExpandedPanelFromScrollTimer()
    {
        yield return new WaitForSeconds(1f);
        scrollingExplore.SetActive(false);
        expandedPanel.SetActive(true);

        yield return new WaitForSeconds(1f);    
        foreach(GameObject go in allExpandedButtons)
            go.GetComponent<Button>().enabled = true;
    }

    private IEnumerator MapFromScrollTimer()
    {
        yield return new WaitForSeconds(1f);
        scrollingExplore.SetActive(false);
        mainPanel.SetActive(true);

        yield return new WaitForSeconds(1f);
        foreach(GameObject go in allMainPanelButtons)
            go.GetComponent<Button>().enabled = true;
    }
}
