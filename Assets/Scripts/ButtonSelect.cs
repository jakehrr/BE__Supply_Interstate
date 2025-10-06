using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    private ToolbarHandler toolbarHandlerAccess;

    private void Start()
    {
        toolbarHandlerAccess = GetComponentInParent<ToolbarHandler>();
    }

    public void ButtonSelected(int index)
    {
        toolbarHandlerAccess.HandleButtonPress(index);
    }
}
