using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSRPG.Data;



namespace DSRPG.Core
{
    public class DataBase
    {
        public DataBase() 
        {

        }

        public void SendData(Statistics stat) 
        {
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

    }
}