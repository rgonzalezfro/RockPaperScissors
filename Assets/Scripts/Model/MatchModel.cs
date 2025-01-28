using System.Collections.Generic;
using System.Linq;

public class MatchModel
{
    public int RequiredWins = 3;

    public Dictionary<Move, MoveSO> Moves;
    public List<PlayerModel> Players = new List<PlayerModel>();
    private List<RoundModel> Rounds = new List<RoundModel>();

    public MatchModel()
    {
        //Create CPUModel
    }

    public void LoadMoves(List<MoveSO> moves)
    {
        Moves = new Dictionary<Move, MoveSO>();
        foreach (MoveSO move in moves)
        {
            Moves.Add(move.Move, move);
        }
    }

    public MoveSO GetMoveSO(Move move)
    {
        if (Moves.TryGetValue(move, out var moveSO))
        {
            return moveSO;
        }
        else
        {
            GameManager.Instance.LogError("Could not fin move {move} in dictionary");
            return null;
        }
    }

    public List<MoveSO> GetAllMoves()
    {
        return Moves.Values.ToList();
    }

    public void AddPlayer(string name)
    {
        Players.Add(new PlayerModel() { Name = name });
    }

    public void StartMatch()
    {
        Rounds.Clear();
    }

    public void AddRound(Move playerMove)
    {
        var round = new RoundModel();
        round.PlayerMove = playerMove;
        round.Player2Move = GetCPUMove();
        round.Calculate(Moves);

        if (round.Result == Result.Win)
        {
            Players[0].Wins++;
        }
        else if (round.Result == Result.Lose)
        {
            Players[1].Wins++;
        }

        Rounds.Add(round);
    }

    private Move GetCPUMove()
    {
        return Move.Rock;
    }

    public RoundModel GetLastRound()
    {
        return Rounds[Rounds.Count - 1];
    }

    public Result MatchResult()
    {
        return Players[0].Wins == RequiredWins ? Result.Win : Result.Lose;
    }

    public bool MatchEnded()
    {
        foreach (var player in Players)
        {
            if (player.Wins == RequiredWins)
            {
                return true;
            }
        }
        return false;
    }
}

