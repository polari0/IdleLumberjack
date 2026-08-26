using Godot;
using System;
using System.Collections.Generic;

public partial class CheatMenu : Control
{
    [Export]
    public Godot.Collections.Dictionary<String, Button> cheatButtons = new Godot.Collections.Dictionary<String, Button>();


    private DatabaseManager databaseManager;
    private Resources resources;


    public override void _Ready()
    {
        databaseManager = GetNode<DatabaseManager>("/root/DatabaseManager");
        resources = GetNode<Resources>("/root/Resources");
        //cheatButtons["CreateDB"].Pressed += On_CreateDB;
    }

    public void On_CreateDB()
    {
        databaseManager.InitializeDatabase();
        resources.AddWoodsToDataBase();
    }


    public void On_InfiniteWood_Pressed()
    {
        var woodTypes = new List<Dictionary<string, object>>();
        woodTypes = databaseManager.ReadFromDatabase("SELECT name FROM resources");
        foreach (Dictionary<string, object> wood in woodTypes)
        {
            if (wood.ContainsKey("name")){
                resources.AddResource((string)wood["name"], double.MaxValue, Resources.resourceTypes.Wood);
            }
        }
        GD.Print("Added infinite resources you are welcome");
        resources.writeResouceDataToDB();
    }
}
