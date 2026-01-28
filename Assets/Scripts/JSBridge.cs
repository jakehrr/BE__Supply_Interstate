using System.Collections.Generic;
using UnityEngine;

public class JSBridge : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ToolbarHandlerV2 toolbar;

    // Category name -> Toolbar index map
    private Dictionary<string, int> categoryIndexMap = new Dictionary<string, int>()
    {
        { "Energies", 0 },
        { "BeVentures", 1 },
        { "Upstream", 2 },
        { "Gas", 3 },
        { "Refining", 4 },
        { "Tazweed", 5 },
        { "AirFuel", 6 }
    };

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (toolbar == null)
            Debug.LogError("[JSBridge] ToolbarHandlerV2 reference not set.");
    }

    // Called from JavaScript
    public void OnBrowserMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        Debug.Log("[JSBridge] Received message: " + message);

        string[] parts = message.Split('_');

        string action = parts[0];
        string level = parts.Length > 1 ? parts[1] : "";
        string category = parts.Length > 2 ? parts[2] : "";

        HandleMessage(action, level, category);
    }

    private void HandleMessage(string action, string level, string category)
    {
        if (toolbar == null)
            return;

        // Global = return to main map panel
        if (action == "Global")
        {
            HandleGlobal();
            return;
        }

        if (action == "View")
        {
            HandleView(level, category);
        }
    }

    private void HandleGlobal()
    {
        Debug.Log("[JSBridge] Global navigation requested");

        // Safest "reset" in your project
        toolbar.MapFromScroll();
    }

    private void HandleView(string level, string category)
    {
        if (!categoryIndexMap.TryGetValue(category, out int index))
        {
            Debug.LogWarning("[JSBridge] Unknown category: " + category);
            return;
        }

        Debug.Log($"[JSBridge] View request - Level: {level}, Index: {index}");

        // Level 1 = open expanded panel
        if (level == "Level1")
        {
            toolbar.ExtendedPanelOpen(index);
            return;
        }

        // Level 2 = go to explore view
        if (level == "Level2")
        {
            toolbar.buttonIndex = index;
            toolbar.ScrollingExplore();
        }
    }

#if UNITY_EDITOR
    [ContextMenu("TEST / View Level1 Energies")]
    private void TestViewLevel1Energies()
    {
        OnBrowserMessage("View_Level1_Energies");
    }

    [ContextMenu("TEST / View Level2 Energies")]
    private void TestViewLevel2Energies()
    {
        OnBrowserMessage("View_Level2_Energies");
    }

    [ContextMenu("TEST / View Level1 BeVentures")]
    private void TestViewLevel1BeVentures()
    {
        OnBrowserMessage("View_Level1_BeVentures");
    }

    [ContextMenu("TEST / View Level2 BeVentures")]
    private void TestViewLevel2BeVentures()
    {
        OnBrowserMessage("View_Level2_BeVentures");
    }

    [ContextMenu("TEST / Global")]
    private void TestGlobal()
    {
        OnBrowserMessage("Global");
    }
#endif
}
