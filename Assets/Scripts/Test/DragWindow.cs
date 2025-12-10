using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform dragTop;

    public void OnDrag(PointerEventData eventData)
    {
        dragTop.anchoredPosition += eventData.delta;
    }
}
