public class MoveSelectionState : State
{
    MoveSelectionPanel panel;

    public override void EnterState()
    {
        panel = UIManager.Instance.ShowPanel<MoveSelectionPanel>();
        panel.Setup(GameManager.Instance.Model.Moves);
        panel.OnSelectMove += SelectMove;
    }

    public void SelectMove(Move move)
    {
        GameManager.Instance.Model.AddRound(move);
        GameManager.Instance.ChangeState(new MoveRevealState());
    }

    public override void ExitState()
    {
        panel.OnSelectMove -= SelectMove;
        UIManager.Instance.HidePanel<MoveSelectionPanel>();
    }
}