using Godot;
using System;
using System.IO;
using System.Collections;

[Tool]
public partial class DBTemplateCreator : Node
{
    // private string _dbPath = "user://game_data.db"; // 'user://' is the persistent app folder
    // private string _connectionString;

    // public override void _Ready()
    // {
    //     // Convert Godot path to absolute OS path for SQLite
    //     string absoluteDbPath = ProjectSettings.GlobalizePath(_dbPath);
    //     _connectionString = $"Data Source={absoluteDbPath}";

    //     // Path to your SQL script (placed in res://)
    //     string scriptPath = ProjectSettings.GlobalizePath("res://scripts/init_database.sql");

    //     var executor = new DataBaseFunctions();
        
    //     GD.Print("Starting database initialization...");
    //     bool success = executor.ExecuteSqlScript(_connectionString, scriptPath);

    //     if (success)
    //     {
    //         GD.Print("Database is ready!");
    //         // Now you can run queries like: SELECT * FROM players;
    //     }
    //     else
    //     {
    //         GD.PrintErr("Failed to initialize database.");
    //     }
    // }
}
