using BreakInfinity;
using Godot;
using System;
using System.Collections.Generic;

public partial class StatUpdgradeButton : Panel
{
    [Export]
    public string StatName = "";
    [Export]
    public int UpgradeLevel = 1;
    [Export]
    public double UpgradeLevelUpMultiplier = 1;

    [Export]
    public double UpgradeStatIncrease = 1;

    [Export]
    public  Godot.Collections.Dictionary<string, int> upgradeBaseCosts = new Godot.Collections.Dictionary<string, int>();

    public  Dictionary<string, double> upgradeCosts = new Dictionary<string, double>();

    private Resources _resources;

    private Label _upgradeCostLabel;

    public override void _Ready()
    {
        _resources = GetNode<Resources>("/root/Resources");
        _upgradeCostLabel = GetNode<Label>("%UpgradeInfo");
        var ListofKeys = new List<string>();
        foreach (var key in upgradeBaseCosts.Keys)
        {
            upgradeCosts[key] = (double)upgradeBaseCosts[key] * (UpgradeLevelUpMultiplier * (UpgradeLevel - 1));
            ListofKeys.Add(key);
        }
        _upgradeCostLabel.Text = "Upgrade Cost: " + string.Join(", ", ListofKeys.ConvertAll(key => $"{key}: {upgradeCosts[key]}"));
    }

    private void upgradeStat()
    {
        Stats._updateStat(StatName, UpgradeStatIncrease);
        UpgradeLevel++;
        foreach (var key in upgradeBaseCosts.Keys)
        {
            upgradeCosts[key] = (double)upgradeBaseCosts[key] * (UpgradeLevelUpMultiplier * (UpgradeLevel - 1));
            _resources.UseResource(key, upgradeCosts[key]);
        }
    }
        


}
