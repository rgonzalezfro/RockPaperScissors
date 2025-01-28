using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    #region Singleton

    public static Model Instance { get; private set; }

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

    [SerializeField]
    private List<MoveSO> moves;

    [SerializeField]
    private List<RubberBandRule> rules;

    [SerializeField]
    private int requiredWins;

    private Dictionary<Move, MoveSO> movesDict;
    private List<PlayerModel> players;
    private MatchModel match;

    public MatchModel Match => match;
    public List<PlayerModel> Players => players;

    private void Start()
    {
        LoadMoves(moves);
    }

    private void LoadMoves(List<MoveSO> moves)
    {
        movesDict = new Dictionary<Move, MoveSO>();
        foreach (MoveSO move in moves)
        {
            movesDict.Add(move.Move, move);
        }
    }

    public MoveSO GetMove(Move move)
    {
        if (movesDict.TryGetValue(move, out var moveSO))
        {
            return moveSO;
        }
        else
        {
            Debug.LogError($"Could not fin move {move} in dictionary");
            return null;
        }
    }

    public List<MoveSO> GetAllMoves()
    {
        return moves;
    }

    public void ResetPlayers()
    {
        if (players == null)
        {
            players = new List<PlayerModel>();
        }
        else
        {
            players.Clear();
        }
    }

    public void AddPlayer(string name)
    {
        players.Add(new PlayerModel() { Name = name });
    }

    public void SetRounds(int rounds)
    {
        requiredWins = rounds > 0 ? rounds : 1;
    }

    public void StartMatch()
    {
        var aiModel = new AIModel(movesDict, rules);
        match = new MatchModel(players, movesDict, requiredWins, aiModel);
    }

    public List<MatchHistoryEntry> GetHistory()
    {
        return HistoryManager.GetHistory();
    }

    public void ClearHistory()
    {
        HistoryManager.DeleteHistory();
    }
}
