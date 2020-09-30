using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSRPG.Classes.Hero;
using DSRPG.Data;
using Settings = DSRPG.Core.Settings;
using Itemdb = DSRPG.Data.Item;
using Item = DSRPG.Classes.Item;
using System.Windows;

namespace DSRPG.Core
{
    public class DataBase
    {
        public DataBase() 
        {

        }

        public void SendData(Statistics stat) 
        {
            SaveGame();
            using (DSRPGEntities db = new DSRPGEntities()) 
            {
                IQueryable<Records> query = db.Records.Where(c => c.Name == stat.Name);
                
                if (query.Count() > 0)
                {
                    UpdateData(stat);
                }
                else 
                {
                    WriteData(stat);
                }
            }
        }

        private void UpdateData(Statistics stat) 
        {
            Records record;

            using (DSRPGEntities db = new DSRPGEntities())
            {
                record = db.Records.Where(c => c.Name == stat.Name).First();

                if (record.Kills < stat.Kills) record.Kills = stat.Kills;
                if (record.Deaths < stat.DeathCount) record.Deaths = stat.DeathCount;
                if (record.SoulsSpent < stat.SoulsSpent) record.SoulsSpent = stat.SoulsSpent;
                if (record.SoulsRecieved < stat.SoulsEarned) record.SoulsRecieved = stat.SoulsEarned;
                if (record.DamageGiven < stat.DamageGiven) record.DamageGiven = stat.DamageGiven;
                if (record.DamageTaken < stat.DamageTaken) record.DamageTaken = stat.DamageTaken;
                if (record.Progress < stat.Progress) record.Progress = stat.Progress;
                if (record.BossKills < stat.BossKills) record.BossKills = stat.BossKills;

                db.SaveChanges();
            }
        }

        private void WriteData(Statistics stat) 
        {
            Records record = new Records();

            record.Name = stat.Name;
            record.Kills = stat.Kills;
            record.Deaths = stat.DeathCount;
            record.SoulsSpent = stat.SoulsSpent;
            record.SoulsRecieved = stat.SoulsEarned;
            record.DamageGiven = stat.DamageGiven;
            record.DamageTaken = stat.DamageTaken;
            record.Progress = stat.Progress;
            record.BossKills = stat.BossKills;

            using (DSRPGEntities db = new DSRPGEntities())
            {
                db.Records.Add(record);
                db.SaveChanges();
            }
        }

        private void SaveGame() 
        {
            using (DSRPGEntities db = new DSRPGEntities())
            {
                IQueryable<Players> query = db.Players.Where(c => c.Name == Settings.Hero.Name);

                if (query.Count() > 0)
                {
                    if (Settings.Hero.Strength > query.First().Strength) query.First().Strength = Settings.Hero.Strength;
                    if (Settings.Hero.Stamina > query.First().Stamina) query.First().Stamina = Settings.Hero.Stamina;
                    if (Settings.Hero.Agility > query.First().Agility) query.First().Agility = Settings.Hero.Agility;
                    if (Settings.Hero.Intellect > query.First().Intellect) query.First().Intellect = Settings.Hero.Intellect;
                    if (Settings.Hero.Souls > query.First().Souls) query.First().Souls = Settings.Hero.Souls;
                    if (Settings.PositionInCompaign > query.First().Position) query.First().Position = Settings.PositionInCompaign;
                    if (Settings.Hero.EstusCount > query.First().EstusCount) query.First().EstusCount = Settings.Hero.EstusCount;
                    if (Settings.TradeCost > query.First().TraderCost) query.First().TraderCost = Settings.TradeCost;


                    foreach (Item item in Settings.Hero.Inv.GetItems())
                    {
                        int itemId = db.Items.Where(c => c.Name == item.Name).First().Id;
                        if (db.ItemsList.Where(c => c.PlayerId == query.FirstOrDefault().Id & c.ItemId == itemId).Count() > 0) 
                        {
                            ItemsList dbItem = db.ItemsList.Where(c => c.PlayerId == query.FirstOrDefault().Id & c.ItemId == itemId).FirstOrDefault();
                            if (item.Count != dbItem.Count) dbItem.Count = item.Count;
                        }
                        else 
                        {
                            ItemsList l = new ItemsList();
                            l.PlayerId = query.First().Id;
                            l.ItemId = db.Items.Where(c => c.Name == item.Name).FirstOrDefault().Id;
                            l.Count = item.Count;
                            db.ItemsList.Add(l);
                        }
                    }
                }
                else
                {
                    Players player = new Players();

                    player.Name = Settings.Hero.Name;
                    player.ClassId = db.Classes.Where(c => c.Class == Settings.Hero.Class).First().Id;
                    player.Strength = Settings.Hero.Strength;
                    player.Stamina = Settings.Hero.Stamina;
                    player.Agility = Settings.Hero.Agility;
                    player.Intellect = Settings.Hero.Intellect;
                    player.Souls = Settings.Hero.Souls;
                    player.Position = Settings.PositionInCompaign;
                    player.EstusCount = Settings.Hero.EstusCount;
                    player.TraderCost = Settings.TradeCost;

                    db.Players.Add(player);
                    db.SaveChanges();

                    int id = db.Players.Where(c => c.Name == player.Name).First().Id;

                    foreach (Item item in Settings.Hero.Inv.GetItems()) 
                    {
                        ItemsList l = new ItemsList();
                        l.PlayerId = id;
                        l.ItemId = db.Items.Where(c => c.Name == item.Name).First().Id;
                        l.Count = item.Count;

                        db.ItemsList.Add(l);
                    }
                }

                db.SaveChanges();
            }
        }

    }
}