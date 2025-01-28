using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchHistoryPanel : UIPanel
{
    [SerializeField]
    private Transform container;

    [SerializeField]
    private HistoryItem prefab;

    public event Action OnExitHistory;
    public event Action OnClearHistory;

    public void CreateItems(List<MatchHistoryEntry> entries)
    {
        GameManager.Instance.ClearChildren(container);

        foreach (MatchHistoryEntry entry in entries)
        {
            var item = Instantiate(prefab, container);
            item.Setup(entry.Rounds.ToString(), entry.Result);
        }
    }

    public void ExitHistory()
    {
        OnExitHistory?.Invoke();
    }

    public void ClearHistory()
    {
        OnClearHistory?.Invoke();
    }
}
