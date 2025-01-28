using System;
using TMPro;
using UnityEngine;

public class MainMenuPanel : UIPanel
{
    [SerializeField]
    TMP_InputField roundsInput;

    public event Action OnStartGame;
    public event Action OnMatchHistory;
    public event Action<int> OnRoundsChanged;

    private void Start()
    {
        roundsInput.onDeselect.AddListener(OnRoundsDeselect);
    }

    private void OnRoundsDeselect(string text)
    {
        if (int.TryParse(text, out int rounds))
        {
            OnRoundsChanged?.Invoke(rounds);
        }
        else
        {
            OnRoundsChanged?.Invoke(0);
        }
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
    }

    public void MatchHistory()
    {
        OnMatchHistory?.Invoke();
    }
}
