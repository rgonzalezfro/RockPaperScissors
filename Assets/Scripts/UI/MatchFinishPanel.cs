using System;
using TMPro;
using UnityEngine;

public class MatchFinishPanel : UIPanel
{
    [SerializeField]
    TMP_Text resultTxt;

    const string WIN_TXT = "Congratulations! You won the match";
    const string LOSE_TXT = "Better luck next time. You lost the match";

    public event Action OnRestart;
    public event Action OnExit;

    public void Setup(Result result)
    {
        if (result == Result.Win)
        {
            resultTxt.text = WIN_TXT;
        }
        else
        {
            resultTxt.text = LOSE_TXT;
        }
    }

    public void Restart()
    {
        OnRestart?.Invoke();
    }

    public void ExitMatch()
    {
        OnExit?.Invoke();
    }
}
