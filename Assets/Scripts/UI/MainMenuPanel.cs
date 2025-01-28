using System;

public class MainMenuPanel : UIPanel
{
    public event Action OnStartGame;

    public void StartGame()
    {
        OnStartGame?.Invoke();
    }
}
