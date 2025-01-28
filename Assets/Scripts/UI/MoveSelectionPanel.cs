using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveSelectionPanel : UIPanel
{
    [SerializeField]
    public GameObject ButtonPrefab;
    [SerializeField]
    public Transform ButtonsContainer;

    public event Action<Move> OnSelectMove;

    public void Setup(List<MoveSO> moves)
    {
        ClearButtons();
        CreateButtons(moves);
    }

    private void ClearButtons()
    {
        for (int i = 0; i < ButtonsContainer.childCount; i++)
        {
            Destroy(ButtonsContainer.GetChild(i).gameObject);
        }
    }

    private void CreateButtons(List<MoveSO> moves)
    {
        foreach (MoveSO move in moves)
        {
            var button = Instantiate(ButtonPrefab, ButtonsContainer);
            button.GetComponentInChildren<TMP_Text>().text = move.Move.ToString();
            button.GetComponent<Button>().onClick.AddListener(() => SelectMove(move.Move));
        }
    }

    public void SelectMove(Move move)
    {
        OnSelectMove?.Invoke(move);
    }
}
