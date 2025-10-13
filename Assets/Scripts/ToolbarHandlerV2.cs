using TMPro;
using UnityEngine;

public class ToolbarHandlerV2 : MonoBehaviour
{
    private int buttonIndex;

    [SerializeField] private ExploreTextScroll textScrollScript;

    [Header("UI Change Elements")]
    [SerializeField] private string[] locationNames;
    [SerializeField] private string[] text1Paragraphs;
    [SerializeField] private string[] text2Paragraphs;
    [SerializeField] private string[] scrollingTextParagraph;

    [Header("Primary UI References")]
    [SerializeField] private TextMeshProUGUI namedLocationBox;
    [SerializeField] private TextMeshProUGUI textSet1;
    [SerializeField] private TextMeshProUGUI textSet2;
    [SerializeField] private TextMeshProUGUI scrollingTextSet1;
    [SerializeField] private TextMeshProUGUI scrollingTextSet2;

    [Header("Main UI Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject expandedPanel;
    [SerializeField] private GameObject scrollingExplore;

    public void MainPanelOpen(int index)
    {
        buttonIndex = index;
        namedLocationBox.text = locationNames[index];
        textSet1.text = text1Paragraphs[index];
        textSet2.text = text2Paragraphs[index];

        mainPanel.SetActive(false);
        expandedPanel.SetActive(true);
    }

    public void ExpandedPanelClose()
    {
        expandedPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void ScrollingExplore()
    {
        scrollingTextSet1.text = scrollingTextParagraph[buttonIndex];
        scrollingTextSet2.text = scrollingTextParagraph[buttonIndex];

        // We are using this switch case to change the settings variables in the explore text scroll. 
        ChangeScrollSettings();

        expandedPanel.SetActive(false);
        scrollingExplore.SetActive(true);
        textScrollScript.enabled = true;

        textScrollScript.ResetTextPos();
    }

    public void ExpandedPanelFromExplore()
    {
        textScrollScript.enabled = false;
        scrollingExplore.SetActive(false);
        expandedPanel.SetActive(true);
    }

    public void MapFromScroll()
    {
        textScrollScript.enabled = false;
        scrollingExplore.SetActive(false);
        mainPanel.SetActive(true);
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

                break;
            case 1:
                // BeVentures
                textScrollScript.endTop = -161f;
                textScrollScript.endBottom = 161f;
                textScrollScript.beginSecondThreshold = 80f;
                textScrollScript.scrollDuration = 25f; 

                break;
            case 2:
                // Bapco Upstream
                textScrollScript.endTop = -187f;
                textScrollScript.endBottom = 187f;
                textScrollScript.beginSecondThreshold = 115f;
                textScrollScript.scrollDuration = 25f; 

                break;
            case 3:
                // Bapco Gas
                textScrollScript.endTop = -195f;
                textScrollScript.endBottom = 195f;
                textScrollScript.beginSecondThreshold = 133f;
                textScrollScript.scrollDuration = 25f;

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
}
