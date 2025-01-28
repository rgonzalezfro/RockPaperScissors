public class MoveRevealState : State
{
    private int countdownTime = 3;

    MoveRevealPanel panel;
    public override void EnterState()
    {
        var model = Model.Instance;
        var lastRound = model.Match.GetLastRound();
        var p1selection = model.GetMove(lastRound.PlayerMove);
        var p2selection = model.GetMove(lastRound.Player2Move);

        panel = UIManager.Instance.ShowPanel<MoveRevealPanel>();
        panel.SetUp(model.Players[0].Name, model.Players[1].Name, lastRound.Result, p1selection, p2selection);
        panel.StartCountdown(countdownTime);
        panel.OnRevealed += UpdateCounter;
        panel.OnContinue += EndRound;
        panel.OnResetMatch += ResetMatch;
        panel.OnExitMatch += ExitMatch;
    }

    private void UpdateCounter()
    {
        var players = Model.Instance.Players;
        var panel = UIManager.Instance.ShowPanel<RoundCounterPanel>();
        panel.AddResult(players[0].Wins, players[1].Wins);
    }

    private void EndRound()
    {
        if (Model.Instance.Match.MatchEnded())
        {
            GameManager.Instance.ChangeState(new MatchFinishState());
        }
        else
        {
            GameManager.Instance.ChangeState(new MoveSelectionState());
        }
    }

    private void ResetMatch()
    {
        UIManager.Instance.HidePanel<RoundCounterPanel>();
        GameManager.Instance.ChangeState(new MatchStartState());
    }

    private void ExitMatch()
    {
        UIManager.Instance.HidePanel<RoundCounterPanel>();
        GameManager.Instance.ChangeState(new MainMenuState());
    }

    public override void ExitState()
    {
        panel.OnExitMatch -= ExitMatch;
        panel.OnResetMatch -= ResetMatch;
        panel.OnRevealed -= UpdateCounter;
        panel.OnContinue -= EndRound;
        UIManager.Instance.HidePanel<MoveRevealPanel>();
    }
}