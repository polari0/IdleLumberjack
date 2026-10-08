using Godot;
using System;

public partial class GameMeny : Control
{   
    [Export]
    public Godot.Collections.Dictionary<string, string> Menus = new Godot.Collections.Dictionary<string, string>()
    {
        {"UpgradeMenu", "res://Assets/Scenes/GameMenus/UpgradeMenu.tscn"},
    };
    private MarginContainer _marginContainer;

    [Export]
    public Godot.Collections.Array<Control> MenuButtons = new Godot.Collections.Array<Control>();


    public override void _Ready()
    {
        _marginContainer = GetParent<MarginContainer>();
        GameEvents.GameEventInstance.OnMenuButtonPressed += MenuButtonPressed;
        foreach(Control control in MenuButtons)
        {
            foreach (var children in control.GetChildren())
            {
                if (children is MenuButton menuButton)
                {
                    menuButton.GameMenu = this;
                }
                else
                {
                    GD.Print("Not a MenuButton");
                }
            }
        }
    }

    public void MenuButtonPressed(String name)
    {
        PackedScene a;
        a =GD.Load<PackedScene>(Menus[name]);
        _marginContainer.AddChild(a.Instantiate());
        Visible = false;
    }
}
