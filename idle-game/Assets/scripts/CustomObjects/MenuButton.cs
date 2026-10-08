using Godot;
using System;

public partial class MenuButton : Button
{
    
    [Export]
    public String ButtonName { get; private set; }

    // [Signal]
    // public delegate void CustomPressedEventHandler(String name);

    public GameMeny GameMenu;

    public void OnMouseEntered()
    {
        GD.Print("Mouse entered button");
    }

    public void OnMouseExited()
    {
        GD.Print("Mouse exited button");
    }

    public void OnguiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("MouseLeft") || @event is InputEventScreenTouch)
        {
            GameEvents.GameEventInstance.MenuButtonPressed(ButtonName);
        }
    }


}
