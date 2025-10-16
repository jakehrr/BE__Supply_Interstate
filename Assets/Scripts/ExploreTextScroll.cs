using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ExploreTextScroll : MonoBehaviour
{
    [Header("Settings")]
    public float scrollDuration = 10f;
    [SerializeField] private float startTop = 322f;
    [SerializeField] private float startBottom = -322f;           
    public float endTop = -185f;               
    public float endBottom = 185f;
    public float beginSecondThreshold = -10f;

    [Header("References")]
    [SerializeField] private RectTransform textSet1;
    [SerializeField] private RectTransform textSet2;

    private float timerA = 0f;
    private float timerB = 0f;
    private bool activateTextB = false;
    private bool activateTextA = true; 

    private Vector2 startPos;
    private Vector2 endPos;

    private void Start()
    {
        // Set our start & end position to the start bottom and end bottom variables (top and bottom of rect transform). 
        startPos = new Vector2(0f, startBottom);
        endPos = new Vector2(0, endBottom);

        // Anchor our text sets to the starting position ready to be moved towards the end position.
        textSet1.anchoredPosition = startPos;
        textSet2.anchoredPosition = startPos;
    }

    private void Update()
    {
        float timeDelta = Time.deltaTime;

        // Create a timer for timer A based on delta time, which will then move the first text set up towards the end position. 
        if (activateTextA)
        {
            timerA += timeDelta;
            float tA = timerA / scrollDuration;
            textSet1.anchoredPosition = Vector2.Lerp(startPos, endPos, tA);

            // If text set 2 hasn't started moving, and text set 1 reaches the threshold, allow text set B to start moving. 
            if (!activateTextB && textSet1.anchoredPosition.y >= beginSecondThreshold)
            {
                activateTextB = true;
                timerB = 0f;
            }

            // If text set 1 has reached the end position, reset it back to the start to restart its loop. 
            // However, wait until text set 2 reaches threshold before reactivating.
            if (tA >= 1f)
            {
                activateTextA = false;
                timerA = 0f;
                textSet1.anchoredPosition = startPos;
            }
        }

        // Once active, begin moving text set 2 using the same method towards the end position. 
        if (activateTextB)
        {
            timerB += timeDelta;
            float tB = timerB / scrollDuration;
            textSet2.anchoredPosition = Vector3.Lerp(startPos, endPos, tB);

            // When text set 2 reaches threshold, allow text set 1 to move again.
            if (!activateTextA && textSet2.anchoredPosition.y >= beginSecondThreshold)
            {
                activateTextA = true;
                timerA = 0f;
            }

            // If text set 2 has reached the end position, reset it back to the start to reset its loop. 
            if (tB >= 1f)
            {
                activateTextB = false;
                timerB = 0f;
                textSet2.anchoredPosition = startPos;
            }
        }

        // Safety catch to keep loop secure. 
        if (timerA == 0f && !activateTextA)
        {
            // Only reset if both have finished a full cycle
            if (!activateTextB)
                activateTextB = false;
        }
    }

    public void ResetTextPos()
    {
        // Set our start & end position to the start bottom and end bottom variables (top and bottom of rect transform). 
        startPos = new Vector2(0f, startBottom);
        endPos = new Vector2(0, endBottom);

        // Anchor our text sets to the starting position ready to be moved towards the end position.
        textSet1.anchoredPosition = startPos;
        textSet2.anchoredPosition = startPos;

        timerA = 0f; 
        timerB = 0f;

        activateTextB = false;
    }
}
