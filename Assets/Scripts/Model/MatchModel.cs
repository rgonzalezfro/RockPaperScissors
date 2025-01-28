using System.Collections.Generic;

public class MatchModel
{
    public int RequiredWins = 3;

    public List<MoveSO> Moves;
    public List<PlayerModel> Players = new List<PlayerModel>();
    private List<RoundModel> Rounds = new List<RoundModel>();

    public MatchModel()
    {
        //Create CPUModel
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

    public Result LastRoundResult()
    {
        return Rounds[Rounds.Count - 1].Result;
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

