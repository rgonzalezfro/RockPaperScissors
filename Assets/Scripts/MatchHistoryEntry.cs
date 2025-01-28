using System;

[Serializable]
public class MatchHistoryEntry
{
    public int Rounds;
    public string Result;

    public MatchHistoryEntry(int rounds, string result)
    {
        Rounds = rounds;
        Result = result;
    }
}