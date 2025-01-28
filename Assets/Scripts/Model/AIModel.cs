using System;
using System.Collections.Generic;
using System.Linq;

public class AIModel
{
    private Random random;
    private Dictionary<Move, MoveSO> possibleMoves;
    private List<MoveSO> possibleMovesList;
    private List<RubberBandRule> rubberBandRules;

    public AIModel(Dictionary<Move, MoveSO> possibleMoves, List<RubberBandRule> rubberBandRules)
    {
        random = new Random();
        this.possibleMoves = possibleMoves;
        this.possibleMovesList = possibleMoves.Values.ToList();
        this.rubberBandRules = rubberBandRules;
    }

    /// <summary>
    /// Higher points ahead result in higer chance of a losing move
    /// </summary>
    /// <returns>A random move</returns>
    public Move MakeMove(Move playerMove, int pointsAhead)
    {
        Move move;
        var rule = CalculateRubberbandRule(pointsAhead);
        if (rule != null && ShouldLose(rule))
        {
            var playerMoveSo = possibleMoves[playerMove];
            int index = random.Next(0, playerMoveSo.Win.Length - 1);
            move = playerMoveSo.Win[index];
        }
        else 
        { 
            var randomIndex = random.Next(0, possibleMovesList.Count - 1);
            move = possibleMovesList[randomIndex].Move;
        }

        return move;
    }

    private bool ShouldLose(RubberBandRule rule)
    {
        int decision = random.Next(0, 100);
        return decision <= rule.LoseChancePercent;
    }

    private RubberBandRule CalculateRubberbandRule(int pointsAhead)
    {
        if (rubberBandRules == null)
        {
            return null;
        }
        RubberBandRule ruleToApply = null;
        foreach (var rule in rubberBandRules)
        {
            if (pointsAhead >= rule.PointsAhead)                    // has enough points for the rule
            {
                if (ruleToApply == null)
                {
                    ruleToApply = rule;
                }
                else if (rule.PointsAhead < ruleToApply.PointsAhead)     // it is a lower level rule
                {
                    ruleToApply = rule;
                }
            }
        }
        return ruleToApply;
    }
}
