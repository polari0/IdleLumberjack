using Godot;
using System;

public partial class GameManager : Node
{
    [Export]
    public MarginContainer MarginContainer;

    public void OnGameMenuButtonPressed()
    {
        foreach (var child in MarginContainer.GetChildren())
        {
            if (child is GameMeny gameMenu)
            {
                gameMenu.Visible = true;
            }
            else if (child is not GameMeny)
            {
                child.QueueFree();
            }
        }
    }
}
