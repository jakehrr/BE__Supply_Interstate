using UnityEngine;
using UnityEngine.UI;

public class ToolbarHandler : MonoBehaviour
{
    public GameObject[] selectedGlow;

    [SerializeField] private GameObject exploreText;
    [SerializeField] private GameObject exploreButton;
    [SerializeField] private GameObject mapButton;

    private Animator toolbarAnimator;
    private int lastSelectedIndex = -1; 

    private void Start()
    {
        toolbarAnimator = GetComponent<Animator>();
    }

    /// Toolbar Buttons
    /// 
    /// This method controls opening and closing the primary information window when one of the buttons in the toolbar are pressed. If they're pressed once it opens, if they press the same button again it closes. 

    public void HandleButtonPress(int index)
    {
        bool sameButtonPressed = (index == lastSelectedIndex);

        if (sameButtonPressed)
        {
            CloseToolbar();

            foreach (GameObject g in selectedGlow)
                g.SetActive(false);

            lastSelectedIndex = -1; 
        }
        else
        {
            foreach (GameObject g in selectedGlow)
                g.SetActive(false);

            selectedGlow[index].SetActive(true);
            OpenToolbar();

            lastSelectedIndex = index;
        }
    }


    /// Fires when toolbar button is pressed. 
    /// 
    /// When the user clicks one of the toolbar buttons, it calls this method playing the animation and displaying the correct information. 
    
    public void OpenToolbar()
    {
        toolbarAnimator.SetBool("OpenToolbar", true);
        exploreText.SetActive(false);
        exploreButton.SetActive(true);
        mapButton.SetActive(true);
    }

    /// Fires when toolbar button is pressed twice.
    /// 
    /// This method is ONLY called when the same button has been pressed twice. It will close the expanded toolbar, putting it back in its default state. 

    public void CloseToolbar()
    {
        toolbarAnimator.SetBool("OpenToolbar", false);
        exploreText.SetActive(true);
        exploreButton.SetActive(false);
        mapButton.SetActive(false);
    }

    /// When toolbar is expanded, displays the explore information panel. 
    /// 
    /// This button is displayed only once the main toolbar has been expanded. When pressed, we play an animation which hide the main expanded toolbar UI, and displays the rolling animated text (WORK IN PROGRESS)

    public void Explore()
    {
        foreach (GameObject g in selectedGlow)
            g.SetActive(false);

        lastSelectedIndex = -1;

        toolbarAnimator.SetBool("Explore", true);
    }
}
