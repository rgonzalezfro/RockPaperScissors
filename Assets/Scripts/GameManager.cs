using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public MatchModel Model;

    [SerializeField]
    private List<MoveSO> Moves;

    private State currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(State newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    private void Start()
    {
        Model = new MatchModel();
        Model.Moves = Moves;

        ChangeState(new MainMenuState());
    }

    public void Log(string log)
    {
        Debug.Log(log);
    }
}
