using System.Collections.Generic;

public class RoundModel
{
    public Move PlayerMove;
    public Move Player2Move;
    public Result Result;

    public void Calculate(List<MoveSO> moves)
    {
        if (PlayerMove == Player2Move)
        {
            Result = Result.Tie;
        }
        else
        {
            Result = CalculateResult(PlayerMove, Player2Move, moves);
        }

        GameManager.Instance.Log($"Calculated: p1 {PlayerMove}, p2 {Player2Move}, result {Result}");
    }

    private Result CalculateResult(Move p1Move, Move p2Move, List<MoveSO> moves)
    {
        var p1MoveSO = moves.Find(x => x.Move == p1Move);
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
