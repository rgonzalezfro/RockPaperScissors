public class MoveRevealState : State
{
    private int countdownTime = 3;

    MoveRevealPanel panel;
    public override void EnterState()
    {
        var model = GameManager.Instance.Model;
        var lastRound = model.GetLastRound();
        var p1selection = model.GetMoveSO(lastRound.PlayerMove);
        var p2selection = model.GetMoveSO(lastRound.Player2Move);

        panel = UIManager.Instance.ShowPanel<MoveRevealPanel>();
        panel.SetUp(model.Players[0].Name,model.Players[1].Name, lastRound.Result, p1selection, p2selection);
        panel.StartCountdown(countdownTime);
        panel.OnRevealed += UpdateCounter;
        panel.OnContinue += EndRound;
    }

    private void UpdateCounter()
    {
        var players = GameManager.Instance.Model.Players;
        var panel = UIManager.Instance.ShowPanel<RoundCounterPanel>();
        panel.AddResult(players[0].Wins, players[1].Wins);
    }

    public void EndRound()
    {
        if (GameManager.Instance.Model.MatchEnded())
        {
            GameManager.Instance.ChangeState(new MatchFinishState());
        }
        else
        {
            GameManager.Instance.ChangeState(new MoveSelectionState());
        }
    }

    public override void ExitState()
    {
        panel.OnRevealed -= UpdateCounter;
        panel.OnContinue -= EndRound;
        UIManager.Instance.HidePanel<MoveRevealPanel>();
    }
}