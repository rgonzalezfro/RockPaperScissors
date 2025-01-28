public class MainMenuState : State
{
    MainMenuPanel panel;

    public override void EnterState()
    {
        panel = UIManager.Instance.ShowPanel<MainMenuPanel>();
        panel.OnStartGame += StartGame;
    }

    private void StartGame()
    {
        GameManager.Instance.ChangeState(new MatchStartState());
    }

    public override void ExitState()
    {
        panel.OnStartGame -= StartGame;
        UIManager.Instance.HidePanel<MainMenuPanel>();
    }
}
