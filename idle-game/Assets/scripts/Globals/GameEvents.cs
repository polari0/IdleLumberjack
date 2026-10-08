using Godot;
using System;
using System.ComponentModel;

public sealed class GameEvents
{

    private static readonly Lazy<GameEvents> lazy = new Lazy<GameEvents>(() => new GameEvents());

    public static GameEvents GameEventInstance {get { return lazy.Value;} }

    private GameEvents(){}

    public event Action<string>? OnMenuButtonPressed;

    public event Action? OnGameSaved;

    public event Action? OnGameLoaded;

    public void MenuButtonPressed(string buttonName)
    {
        OnMenuButtonPressed?.Invoke(buttonName);
    }

    public void GameSaved()
    {
        OnGameSaved?.Invoke();
    }

    public void GameLoaded()
    {
        OnGameLoaded?.Invoke();
    }
}
