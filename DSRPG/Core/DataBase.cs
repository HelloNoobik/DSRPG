using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace DSRPG.Core
{
    public class DataBase
    {
        private OleDbConnection connection;
        private OleDbCommand command;

        public DataBase() 
        {
            connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Data/HeroRecord.mdb");
        }

        public void SendData(Statistics stats) 
        {
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Record WHERE Name=?";
            command.Parameters.AddWithValue("Name", stats.Name);
            connection.Open();
            object result = command.ExecuteScalar();
            connection.Close();
            if (result != null)
            {
                UpdateData(stats);
            }
            else 
            {
                WriteData(stats);
            }
            
        }

        private void WriteData(Statistics stats)
        {
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Record(Name,Kills,Deaths,Souls_Received,Souls_Spent,Progress,Damage_Given,Damage_Taken,Number_of_boss_deaths) VALUES(?,?,?,?,?,?,?,?,?)";
            command.Parameters.AddWithValue("Name", stats.Name);
            command.Parameters.AddWithValue("Kills", stats.Kills);
            command.Parameters.AddWithValue("Deaths", stats.DeathCount);
            command.Parameters.AddWithValue("Souls_Received", stats.SoulsEarned);
            command.Parameters.AddWithValue("Souls_Spent", stats.SoulsSpent);
            command.Parameters.AddWithValue("Progress", stats.Progress);
            command.Parameters.AddWithValue("Damage_Given", stats.DamageGiven);
            command.Parameters.AddWithValue("Damage_Taken", stats.DamageTaken);
            command.Parameters.AddWithValue("Number_of_boss_deaths", stats.BossKills);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UpdateData(Statistics stats) 
        {
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE Record SET Kills = ?, Deaths = ?, Souls_Received = ?, Souls_Spent = ?, Progress = ?,Damage_Given = ?,Damage_Taken = ?,Number_of_boss_deaths = ? Where Name = ?";
            command.Parameters.AddWithValue("Name", stats.Name);
            command.Parameters.AddWithValue("Kills", stats.Kills);
            command.Parameters.AddWithValue("Deaths", stats.DeathCount);
            command.Parameters.AddWithValue("Souls_Received", stats.SoulsEarned);
            command.Parameters.AddWithValue("Souls_Spent", stats.SoulsSpent);
            command.Parameters.AddWithValue("Progress", stats.Progress);
            command.Parameters.AddWithValue("Damage_Given", stats.DamageGiven);
            command.Parameters.AddWithValue("Damage_Taken", stats.DamageTaken);
            command.Parameters.AddWithValue("Number_of_boss_deaths", stats.BossKills);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}