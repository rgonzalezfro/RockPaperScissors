using System.Collections.Generic;

public class RoundModel
{
    public Move PlayerMove;
    public Move Player2Move;
    public Result Result;

    public void Calculate(Dictionary<Move, MoveSO> moves)
    {
        if (PlayerMove == Player2Move)
        {
            Result = Result.Tie;
        }
        else
        {
            Result = CalculateResult(PlayerMove, Player2Move, moves);
        }
    }

    private Result CalculateResult(Move p1Move, Move p2Move, Dictionary<Move, MoveSO> moves)
    {
        var p1MoveSO = moves[p1Move];
        foreach (var move in p1MoveSO.Win)
        {
            if (move == p2Move)
            {
                return Result.Win;
            }
        }
        return Result.Lose;
    }
}
