using System.Collections.Generic;

public class MatchModel
{
    private int requiredWins;
    private int maxRounds;
    private Dictionary<Move, MoveSO> moves;
    private List<PlayerModel> players = new List<PlayerModel>();
    private List<RoundModel> rounds = new List<RoundModel>();
    private AIModel AIModel;

    public int MaxRounds => maxRounds;

    public MatchModel(List<PlayerModel> players, Dictionary<Move, MoveSO> moves, int requiredWins, AIModel aiModel)
    {
        this.players = players;
        this.moves = moves; 
        this.requiredWins = requiredWins;
        this.maxRounds = (requiredWins - 1) * 2 + 1;
        this.AIModel = aiModel;
    }

    public void AddRound(Move playerMove)
    {
        int cpuPointsAhead = players[1].Wins - players[0].Wins;

        var round = new RoundModel();
        round.PlayerMove = playerMove;
        round.Player2Move = AIModel.MakeMove(playerMove, cpuPointsAhead);
        round.Calculate(moves);

        if (round.Result == Result.Win)
        {
            players[0].Wins++;
        }
        else if (round.Result == Result.Lose)
        {
            players[1].Wins++;
        }

        rounds.Add(round);

        if (MatchEnded())
        {
            HistoryManager.SaveMatchHistory(requiredWins, MatchResult().ToString());
        }
    }

    public RoundModel GetLastRound()
    {
        return rounds[rounds.Count - 1];
    }

    public Result MatchResult()
    {
        return players[0].Wins == requiredWins ? Result.Win : Result.Lose;
    }

    public bool MatchEnded()
    {
        foreach (var player in players)
        {
            if (player.Wins == requiredWins)
            {
                return true;
            }
        }
        return false;
    }
}

