public class MatchFinishState : State
{
    MatchFinishPanel panel;

    public override void EnterState()
    {
        panel = UIManager.Instance.ShowPanel<MatchFinishPanel>();
        panel.Setup(Model.Instance.Match.MatchResult());
        panel.OnRestart += RestartGame;
        panel.OnExit += ExitMatch;

       
    }

    private void RestartGame()
    {
        GameManager.Instance.ChangeState(new MatchStartState());
    }

    private void ExitMatch()
    {
        GameManager.Instance.ChangeState(new MainMenuState());
    }

    public override void ExitState()
    {
        panel.OnExit -= ExitMatch;
        panel.OnRestart -= RestartGame;
        UIManager.Instance.HidePanel<MatchFinishPanel>();
        UIManager.Instance.HidePanel<RoundCounterPanel>();
    }
}