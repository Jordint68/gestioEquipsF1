using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Windows.UI.Xaml.Media.Imaging;

namespace DBLib
{
    public class DBPilot
    {
        private int id;
        private String name;
        private BitmapImage portrait;
        private int idEquip;

        public DBPilot(int id, String name, String portrait, int idEquip)
        {
            this.Id = id;
            this.Name = name;
            this.Portrait = new BitmapImage(new System.Uri(portrait));
            this.IdEquip = idEquip;
        }

        public DBPilot(DBPilot p)
        {
            this.id = p.id;
            this.name = p.name;
            this.portrait = p.portrait;
            this.idEquip = p.idEquip;
        }



        #region propietats
        public int Id { get => Id1; set => Id1 = value; }
        public String Name { get => Name1; set => Name1 = value; }
        public BitmapImage Portrait { get => Portrait1; set => Portrait1 = value; }
        public int Id1 { get => id; set => id = value; }
        public string Name1 { get => name; set => name = value; }
        public BitmapImage Portrait1 { get => portrait; set => portrait = value; }
        public int IdEquip { get => idEquip; set => idEquip = value; }

        #endregion

        // Mètode per a recuperar els pilots:
        public static List<DBPilot> GetPilots()
        {
            using(var context = new MySQLDBContext())
            {

                using (var connexio = context.Database.GetDbConnection() )
                {
                    connexio.Open();
                    using (var consulta = connexio.CreateCommand())
                    {
                        consulta.CommandText = @"
                            select * from pilot
                        ";
                        DbDataReader reader = consulta.ExecuteReader();
                        List<DBPilot> pilots = new List<DBPilot>();
                        while(reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("p_num"));
                            string name = reader.GetString(reader.GetOrdinal("p_name"));
                            string portrait = reader.GetString(reader.GetOrdinal("p_photo"));
                            int idEquip = reader.GetInt32(reader.GetOrdinal("p_team"));

                            pilots.Add(new DBPilot(id, name, portrait, idEquip));
                        }
                        return pilots;
                    }

                }
            }
        }


    }
}
