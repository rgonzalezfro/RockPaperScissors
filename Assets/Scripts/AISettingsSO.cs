using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AISettingsSO", menuName = "Scriptable Objects/AISettingsSO")]
public class AISettingsSO : ScriptableObject
{
    public List<RubberBandRule> Rules;
}
