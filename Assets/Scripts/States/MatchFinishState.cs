public class MatchFinishState : State
{
    MatchFinishPanel panel;

    public override void EnterState()
    {
        panel = UIManager.Instance.ShowPanel<MatchFinishPanel>();
        panel.Setup(GameManager.Instance.Model.MatchResult());
        panel.OnRestart += RestartGame;
    }

    private void RestartGame()
    {
        GameManager.Instance.ChangeState(new MatchStartState());
    }

    public override void ExitState()
    {
        panel.OnRestart -= RestartGame;
        UIManager.Instance.HidePanel<MatchFinishPanel>();
        UIManager.Instance.HidePanel<RoundCounterPanel>();
    }
}