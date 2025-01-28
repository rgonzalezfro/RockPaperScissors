using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Name;
    [SerializeField]
    private Image Image;

    public void Setup(Move move, Sprite image)
    {
        Name.text = move.ToString();
        Image.sprite = image;
    }
}
