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

    private State currentState;

    private void Start()
    {
        ChangeState(new MainMenuState());
    }

    public void ChangeState(State newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    #region Utility

    public void Log(string log)
    {
        Debug.Log(log);
    }

    public void LogError(string log)
    {
        Debug.LogError(log);
    }

    public void ClearChildren(Transform container)
    {
        for (int i = 0; i < container.childCount; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }

    #endregion
}
