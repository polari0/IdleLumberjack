using Godot;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;


public partial class DatabaseManager : Node
{
    private string _dbPath;

    public override void _Ready()
    {
        // We use user:// to ensure the database persists in the user's app data folder
        // SQLite needs a real OS path, so we must globalize the path.
        
        _dbPath = ProjectSettings.GlobalizePath("user://WoodGame.db");
        GD.Print($"Database path: {_dbPath}");
        //GD.Print(double.MaxValue.ToString());
        //InitializeDatabase();
    }

    public void InitializeDatabase()
    {
        //Just making sure there is no Database already in existence
        if (FileAccess.FileExists(_dbPath))
        {
            GD.Print("Database exists allready");
            return;
        }

        using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            // Create a simple table if it doesn't exist
            command.CommandText = 
                @"CREATE TABLE IF NOT EXISTS resources (resource_ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                    name TEXT UNIQUE, 
                    wood_count REAL,
                    plank_count REAL,
                    plank_craft_cost INTEGER,
                    wood_sell_price REAL
                )";
            command.ExecuteNonQuery();
            GD.Print("Database initialized and table created.");
        }
    }

/// <summary>
/// Inserts data into database without worry of a SQLinjection.
/// Use with UPDATE, INSERT and DELETE
/// </summary>
/// <param name="SQLiteQuerry">Querry in the for of a string For example "UPDATE ROWS"</param>
/// <param name="parameters">Parameters for the querry</param>
    public void WriteToDatabase(string SQLiteQuerry, Dictionary<string, object> parameters = null)
    {
        using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = SQLiteQuerry;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
            command.ExecuteNonQuery();
        }
    }


    /// <summary>
    /// Gets data from the SQLite Database for the game to use only for SELECT Statements
    /// </summary>
    /// <param name="SQLiteQuerry"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public List<Dictionary<string, Object>> ReadFromDatabase(string SQLiteQuerry, Dictionary<string, object> parameters = null)
    {
        var results = new List<Dictionary<string, Object>>();
        using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = SQLiteQuerry;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var row = new Dictionary<string, Object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }
                    results.Add(row);
                }
            }
        }
        return results;
    }
}

