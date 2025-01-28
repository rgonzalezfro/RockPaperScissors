using UnityEngine;
using UnityEngine.UI;

public class RoundCounterPanel : UIPanel
{
    [SerializeField]
    private Color neutralColor;
    [SerializeField]
    private Color winColor;
    [SerializeField]
    private Color loseColor;
    [SerializeField]
    private Image[] images;

    int win;
    int lose;
    int neutral;

    int maxRounds = 5;

    public void ResetCount()
    {
        foreach (var image in images)
        {
            image.color = neutralColor;
        }
    }

    public void AddResult(int win, int lost)
    {
        this.win = win;
        this.lose = lost;
        this.neutral = maxRounds - win - lose;

        //if (result == Result.Win)
        //{
        //    newIndex = win - 1;
        //}
        //else if (result == Result.Lose)
        //{
        //    newIndex = win + neutral;
        //}

        UpdateScore();
    }

    private void UpdateScore()
    {
        int currentIndex = 0;
        for (var i = 0; i < win; i++)
        {
            images[currentIndex].color = winColor;
            currentIndex++;
        }

        for (var i = 0; i < neutral; i++)
        {
            images[currentIndex].color = neutralColor;
            currentIndex++;
        }

        for (var i = 0; i < lose; i++)
        {
            images[currentIndex].color = loseColor;
            currentIndex++;
        }
    }
}
