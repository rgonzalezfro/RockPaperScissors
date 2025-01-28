public class MatchHistoryState : State
{
    MatchHistoryPanel panel;
    public override void EnterState()
    {
        panel = UIManager.Instance.ShowPanel<MatchHistoryPanel>();

        panel.OnClearHistory += ClearHistory;
        panel.OnExitHistory += ExitHistory;

        panel.CreateItems(Model.Instance.GetHistory());
    }

    private void ExitHistory()
    {
        GameManager.Instance.ChangeState(new MainMenuState());
    }

    private void ClearHistory()
    {
        Model.Instance.ClearHistory();
    }

    public override void ExitState()
    {
        panel.OnExitHistory -= ExitHistory;
        panel.OnClearHistory -= ClearHistory;
        UIManager.Instance.HidePanel<MatchHistoryPanel>();
    }
}