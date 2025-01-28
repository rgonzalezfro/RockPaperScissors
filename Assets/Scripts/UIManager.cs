using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private Dictionary<Type, UIPanel> panels = new Dictionary<Type, UIPanel>();

    private Dictionary<Type, UIPanel> activePanels = new Dictionary<Type, UIPanel>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (var panel in GetComponentsInChildren<UIPanel>(true))
        {
            panels[panel.GetType()] = panel;
        }
    }

    public T ShowPanel<T>() where T : UIPanel
    {
        T _panel = null;
        if (activePanels.TryGetValue(typeof(T), out var active))
        {
            return active as T;
        }

        if (panels.TryGetValue(typeof(T), out var panel))
        {
            _panel = panel as T;
            _panel.gameObject.SetActive(true);

            activePanels.Add(_panel.GetType(), _panel);
        }
        else
        {
            Debug.LogError($"Panel of type {typeof(T).Name} not found.");
        }
        return _panel;
    }

    public void HidePanel<T>()
    {
        if (activePanels.TryGetValue(typeof(T), out var panel))
        {
            panel.gameObject.SetActive(false);
            activePanels.Remove(typeof(T));
        }
        else
        {
            Debug.LogError($"Panel of type {typeof(T).Name} not found.");
        }
    }

    public void HideAllPanels()
    {
        foreach (var panel in activePanels.Values)
        {
            panel.gameObject.SetActive(false);
        }
        activePanels.Clear();
    }
}
