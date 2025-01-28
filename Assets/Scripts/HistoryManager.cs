using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class HistoryManager
{
    private static List<MatchHistoryEntry> history;

    private static string filePath = Application.persistentDataPath + "/history_data.dat";

    public static void SaveMatchHistory(int rounds, string result)
    {
        var entry = new MatchHistoryEntry(rounds, result);

        if (history == null)
        {
            history = new List<MatchHistoryEntry>();
        }

        history.Add(entry);

        try
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, history);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to save history: " + ex.Message);
        }
    }

    public static List<MatchHistoryEntry> GetHistory()
    {
        if (history == null)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        history = (List<MatchHistoryEntry>)formatter.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError("Failed to load history: " + ex.Message);
                }
            }
            else
            {
                history = new List<MatchHistoryEntry>();
            }
        }

        return history;
    }

    public static void DeleteHistory()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        history = new List<MatchHistoryEntry>();
    }
}
