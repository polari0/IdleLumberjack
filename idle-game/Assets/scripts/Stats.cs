using Godot;
using System;
using System.Collections.Generic;

public static class Stats
{

    /// <summary>
    /// A dictionary holding each and every stat in the game. 
    /// Naming convention is ItemName_StatType_AffectedAtribute. For example, Axe_Base_Damage is the base damage of the axe.
    /// Or Axe_Multiplier_Damage is the damage multiplier of the axe.
    /// Upgrading a stat should work as follows: Add value to current value. If the stat is a multiplier, then the value of base 
    /// stat should be multiplied by the value of the multiplier. For example, if Axe_Base_Damage is 1 and 
    /// Axe_Multiplier_Damage is 10, then the final damage of the axe should be 10.
    /// To find out which stat the multiplier effects parse out multiplier from the stat name. For example, 
    /// Axe damage multiplier becomes Axe_damage then finds the base stat with name Axe_Base_Damage and multiplies the base stat 
    /// by the multiplier.
    /// </summary>
    private static Dictionary<string, double> _stats = new Dictionary<string, double>()
    {
        { "Axe_Base_Damage", 1 },
        { "Axe_Base_Speed", 1 },
        { "Axe_Base_Area", 100 },
        { "ResourceGain_Base_Wood", 1},
        { "ResourceGain_Base_Planks", 1},

        { "Axe_Multiplier_Damage", 1 },
        { "Axe_Multiplier_Speed", 1 },
        { "Axe_Multiplier_Area", 1 },
        { "ResourceGain_Multiplier_Wood", 1},
        { "ResourceGain_Multiplier_Planks", 1},

    };


    public static void _updateStat(string statName, double value)
    {
        if (_stats.ContainsKey(statName))
        {
            var currentValue = _stats[statName];
            _stats[statName] = currentValue + value;
            if(_isMultiplier(statName))
            {
                _applyMultiplier(statName);
            }
        }
    }

    private static bool _isMultiplier(string statName)
    {
        if (statName.Contains("_Multiplier_")){
            return true;
        }
        else{
            return false;
        }
    }

    private static void _applyMultiplier(string statName)
    {
        if (_isMultiplier(statName))
        {
            var baseStatName = statName.Replace("_Multiplier_", "_Base_");
            if (_stats.ContainsKey(baseStatName))
            {
                var baseValue = _stats[baseStatName];
                var multiplierValue = _stats[statName];
                _stats[baseStatName] = baseValue * multiplierValue;

                GD.Print($"Applied multiplier: {statName} with value {multiplierValue} to {baseStatName}. New value: {_stats[baseStatName]}");
            }
        }
    }
}
