using System.Collections.Generic;
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
    private Transform imageContainer;
    [SerializeField]
    private Image imagePrefab;

    private List<Image> images;

    int win;
    int lose;
    int neutral;

    int maxRounds = 5;

    public void ResetCount(int maxRounds)
    {
        this.maxRounds = maxRounds;

        GameManager.Instance.ClearChildren(imageContainer);
        CreateCounter(maxRounds);

        foreach (var image in images)
        {
            image.color = neutralColor;
        }
    }

    private void CreateCounter(int maxRounds)
    {
        images = new List<Image>();
        for (int i = 0; i < maxRounds; i++)
        {
            images.Add(Instantiate(imagePrefab, imageContainer));
        }
    }

    public void AddResult(int win, int lost)
    {
        this.win = win;
        this.lose = lost;
        this.neutral = maxRounds - win - lose;

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
