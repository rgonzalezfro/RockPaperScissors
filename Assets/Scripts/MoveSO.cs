using UnityEngine;

[CreateAssetMenu(fileName = "MoveSO", menuName = "Scriptable Objects/MoveSO")]
public class MoveSO : ScriptableObject
{
    [SerializeField]
    public Move Move;

    public Move[] Lose;
    public Move[] Win;
}
