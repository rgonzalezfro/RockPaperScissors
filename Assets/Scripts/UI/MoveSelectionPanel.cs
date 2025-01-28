using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveSelectionPanel : UIPanel
{
    [SerializeField]
    private GameObject infoContainer;
    [SerializeField]
    private Transform winContainer;
    [SerializeField]
    private Transform loseContainer;
    [SerializeField]
    private MoveItem moveItemPrefab;
    [SerializeField]
    private MoveItem moveItemSelected;

    [SerializeField]
    private GameObject ButtonPrefab;
    [SerializeField]
    private Transform ButtonsContainer;

    public event Action<Move> OnSelectMove;
    public event Action OnConfirmMove;

    public void Setup(List<MoveSO> moves)
    {
        infoContainer.SetActive(false);

        GameManager.Instance.ClearChildren(ButtonsContainer);
        CreateButtons(moves);
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

    public void ConfirmMove()
    {
        OnConfirmMove?.Invoke();
    }

    public void ShowWinLoseDetails(MoveSO selected, List<MoveSO> win, List<MoveSO> lose)
    {
        GameManager.Instance.ClearChildren(winContainer);
        GameManager.Instance.ClearChildren(loseContainer);

        moveItemSelected.Setup(selected.Move, selected.Image);

        foreach (MoveSO move in win)
        {
            var item = Instantiate(moveItemPrefab, winContainer);
            item.Setup(move.Move, move.Image);
        }
        foreach (MoveSO move in lose)
        {
            var item = Instantiate(moveItemPrefab, loseContainer);
            item.Setup(move.Move, move.Image);
        }

        infoContainer.SetActive(true);
    }
}
