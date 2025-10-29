using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarouselPopulation : MonoBehaviour
{
    public int index;

    [SerializeField] private GameObject carouselContent;
    [SerializeField] private GameObject carouselText;

    [SerializeField] private List<GameObject> populatedTextObjects = new List<GameObject>();

    [SerializeField] private string bapcoEnergiesText;
    [SerializeField] private string beVenturesText;
    [SerializeField] private string[] upstreamText;
    [SerializeField] private string[] gasText;
    [SerializeField] private string[] refiningText;
    [SerializeField] private string[] tazweedText;
    [SerializeField] private string[] airfuelingText;

    private void OnEnable()
    {
        PopulateCarousel(index, 3); 
    }

    public void PopulateCarousel(int index, int numOfPages)
    {
        for(int i = 0;  i < numOfPages; i++)
        {
            populatedTextObjects.Add(Instantiate(carouselText));
        }

        foreach (GameObject go in populatedTextObjects)
        {
            go.transform.parent = carouselContent.transform;
            go.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 350); 
        }

        switch (index)
        {
            case 0:
                populatedTextObjects[0].GetComponent<TextMeshProUGUI>().text = bapcoEnergiesText;

                break;

            case 1:
                populatedTextObjects[0].GetComponent<TextMeshProUGUI>().text = beVenturesText;

                break;

            case 2:
                populatedTextObjects[0].GetComponent<TextMeshProUGUI>().text = upstreamText[0];
                populatedTextObjects[1].GetComponent<TextMeshProUGUI>().text = upstreamText[1];
                break;

            case 3:
                populatedTextObjects[0].GetComponent<TextMeshProUGUI>().text = gasText[0];
                populatedTextObjects[1].GetComponent<TextMeshProUGUI>().text = gasText[1];
                populatedTextObjects[2].GetComponent<TextMeshProUGUI>().text = gasText[2];

                break;

            case 4:
                populatedTextObjects[0].GetComponent<TextMeshProUGUI>().text = refiningText[0];
                populatedTextObjects[1].GetComponent<TextMeshProUGUI>().text = refiningText[1];
                populatedTextObjects[2].GetComponent<TextMeshProUGUI>().text = refiningText[2];
                populatedTextObjects[3].GetComponent<TextMeshProUGUI>().text = refiningText[3];
                populatedTextObjects[4].GetComponent<TextMeshProUGUI>().text = refiningText[4];

                break;

            case 5:
                populatedTextObjects[0].GetComponent<TextMeshProUGUI>().text = tazweedText[0];
                populatedTextObjects[1].GetComponent<TextMeshProUGUI>().text = tazweedText[1];
                populatedTextObjects[2].GetComponent<TextMeshProUGUI>().text = tazweedText[2];

                break;

            case 6:
                populatedTextObjects[0].GetComponent<TextMeshProUGUI>().text = airfuelingText[0];
                populatedTextObjects[1].GetComponent<TextMeshProUGUI>().text = airfuelingText[1];
                populatedTextObjects[2].GetComponent<TextMeshProUGUI>().text = airfuelingText[2];

                break;
            
        }
    }
}
