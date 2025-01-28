using System.Collections;
using UnityEngine;

public class MatchStartState : State
{
    public override void EnterState()
    {
        // Initialize match
        Model.Instance.ResetPlayers();
        Model.Instance.AddPlayer("Player");
        Model.Instance.AddPlayer("CPU");
        Model.Instance.StartMatch();

        GameManager.Instance.StartCoroutine(StartMatchMessage());
    }

    private IEnumerator StartMatchMessage()
    {
        UIManager.Instance.ShowPanel<MessagePanel>();
        yield return new WaitForSeconds(2);
        GameManager.Instance.ChangeState(new MoveSelectionState());
    }

    public override void ExitState()
    {
        UIManager.Instance.HidePanel<MessagePanel>();
        var panel = UIManager.Instance.ShowPanel<RoundCounterPanel>();
        panel.ResetCount(Model.Instance.Match.MaxRounds);
    }
}