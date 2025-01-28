using TMPro;
using UnityEngine;

public class HistoryItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text rounds;
    [SerializeField]
    private TMP_Text result;

    public void Setup(string rounds, string result)
    {
        this.rounds.text = rounds;
        this.result.text = result;
    }
}
