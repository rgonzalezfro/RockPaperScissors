using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MoveRevealPanel : UIPanel
{
    [SerializeField]
    private TMP_Text countdown;

    [SerializeField]
    private GameObject resultGO;

    [SerializeField]
    private TMP_Text resultTxt;

    [SerializeField]
    private TMP_Text player1Name;

    [SerializeField]
    private TMP_Text player2Name;

    [SerializeField]
    private MoveItem player1Selection;
    [SerializeField]
    private MoveItem player2Selection;

    public event Action OnRevealed;
    public event Action OnContinue;

    public void SetUp(string player1, string player2, Result result, MoveSO p1selection, MoveSO p2selection)
    {
        player1Name.text = player1;
        player2Name.text = player2;
        resultTxt.text = result.ToString();

        player1Selection.Setup(p1selection.Move, p1selection.Image);
        player2Selection.Setup(p2selection.Move, p2selection.Image);

        resultGO.SetActive(false);
        countdown.gameObject.SetActive(true);
    }

    public void StartCountdown(int seconds)
    {
        StartCoroutine(CountdownCoroutine(seconds));
    }

    public void Continue()
    {
        OnContinue?.Invoke();
    }

    private IEnumerator CountdownCoroutine(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            countdown.text = (seconds - i).ToString();
            yield return new WaitForSeconds(1);
        }
        countdown.gameObject.SetActive(false);
        resultGO.SetActive(true);
        OnRevealed?.Invoke();
    }
}
