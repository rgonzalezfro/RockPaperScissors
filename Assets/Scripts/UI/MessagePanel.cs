using TMPro;
using UnityEngine;

public class MessagePanel : UIPanel
{
    [SerializeField]
    private TMP_Text message;

    public void SetText(string text)
    {
        message.text = text;
    }
}
