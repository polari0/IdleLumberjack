    using System;
    using System.Collections.Generic;
    using System.Linq;
    
// public class PlayerRepository
// {
//     private readonly DatabaseManager _db;

//     public PlayerRepository()
//     {
//         // We use the existing DatabaseManager instance
//         _db = DatabaseManager.Instance;
//     }

//     public void Save(Player player)
//     {
//         string sql = "INSERT INTO players (name, score) VALUES (@name, @score) " +
//                         "ON CONFLICT(name) DO UPDATE SET score = @score;";
        
//         var parameters = new Dictionary<string, object>
//         {
//             { "@name", player.Name },
//             { "@score", player.Score }
//         };

//         _db.InsertData(sql, parameters);
//     }

//     public Player GetByName(string name)
//     {
//         string sql = "SELECT name, score FROM players WHERE name = @name;";
//         var parameters = new Dictionary<string, object> { { "@name", name } };

//         var results = _db.GetData(sql, parameters);

//         if (results.Count > 0)
//         {
//             var row = results[0];
//             return new Player(row["name"].ToString(), Convert.ToInt32(row["score"]));
//         }

//         return null; // Return null if player not found
//     }

//     public List<Player> GetAllPlayers()
//     {
//         string sql = "SELECT name, score FROM players ORDER BY score DESC;";
//         var results = _db.GetData(sql, new Dictionary<string, object>());

//         // Use LINQ to transform the list of Dictionaries into a list of Player objects
//         return results.Select(row => new Player(
//             row["name"].ToString(), 
//             Convert.ToInt32(row["score"])
//         )).ToList();
//     }

//     public void Delete(string name)
//     {
//         string sql = "DELETE FROM players WHERE name = @name;";
//         _db.InsertData(sql, new Dictionary<string, object> { { "@name", name } });
//     }
// }
