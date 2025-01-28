using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance { get; private set; }

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
    #endregion

    #region State Manager (move to other class for Single responsibility)

    private State currentState;

    public void ChangeState(State newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    #endregion

    #region Logs utility

    public void Log(string log)
    {
        Debug.Log(log);
    }

    public void LogError(string log)
    {
        Debug.LogError(log);
    }

    #endregion

    public MatchModel Model;

    //Add settings as scriptable objects

    [SerializeField]
    private List<MoveSO> Moves;

    private void Start()
    {
        Model = new MatchModel();
        Model.LoadMoves(Moves);

        ChangeState(new MainMenuState());
    }
}
