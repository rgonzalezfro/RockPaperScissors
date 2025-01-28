using System.Collections.Generic;

public class MoveSelectionState : State
{
    private MoveSelectionPanel panel;

    private Move selectedMove;

    public override void EnterState()
    {
        panel = UIManager.Instance.ShowPanel<MoveSelectionPanel>();
        panel.Setup(Model.Instance.GetAllMoves());
        panel.OnSelectMove += SelectMove;
        panel.OnConfirmMove += ConfirmMove;
    }

    private void SelectMove(Move move)
    {
        selectedMove = move;
        var model = Model.Instance;
        
        var selected = model.GetMove(move);
        var win = new List<MoveSO>();
        var lose = new List<MoveSO>();

        foreach (var item in selected.Win)
        {
            win.Add(model.GetMove(item));
        }
        foreach (var item in selected.Lose)
        {
            lose.Add(model.GetMove(item));
        }
        panel.ShowWinLoseDetails(selected, win, lose);
    }

    private void ConfirmMove()
    {
        Model.Instance.Match.AddRound(selectedMove);
        GameManager.Instance.ChangeState(new MoveRevealState());
    }

    public override void ExitState()
    {
        panel.OnSelectMove -= SelectMove;
        panel.OnConfirmMove -= ConfirmMove;
        UIManager.Instance.HidePanel<MoveSelectionPanel>();
    }
}