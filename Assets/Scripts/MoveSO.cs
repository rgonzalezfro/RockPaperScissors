using UnityEngine;

[CreateAssetMenu(fileName = "MoveSO", menuName = "Scriptable Objects/MoveSO")]
public class MoveSO : ScriptableObject
{
    [SerializeField]
    public Move Move;

    [SerializeField]
    public Sprite Image;

    public Move[] Lose;
    public Move[] Win;
}
