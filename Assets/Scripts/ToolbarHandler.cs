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

    public void OpenToolbar()
    {
        toolbarAnimator.SetBool("OpenToolbar", true);
        exploreText.SetActive(false);
        exploreButton.SetActive(true);
        mapButton.SetActive(true);
    }

    public void CloseToolbar()
    {
        toolbarAnimator.SetBool("OpenToolbar", false);
        exploreText.SetActive(true);
        exploreButton.SetActive(false);
        mapButton.SetActive(false);
    }
}
