public class MainMenuState : State
{
    MainMenuPanel panel;

    public override void EnterState()
    {
        panel = UIManager.Instance.ShowPanel<MainMenuPanel>();
        panel.OnStartGame += StartGame;
        panel.OnRoundsChanged += RoundsChanged;
        panel.OnMatchHistory += MatchHistory;
    }

    private void RoundsChanged(int rounds)
    {
        Model.Instance.SetRounds(rounds);
    }

    private void StartGame()
    {
        GameManager.Instance.ChangeState(new MatchStartState());
    }

    private void MatchHistory()
    {
        GameManager.Instance.ChangeState(new MatchHistoryState());
    }

    public override void ExitState()
    {
        panel.OnMatchHistory -= MatchHistory;
        panel.OnRoundsChanged -= RoundsChanged;
        panel.OnStartGame -= StartGame;
        UIManager.Instance.HidePanel<MainMenuPanel>();
    }
}
