using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace DBLib
{
    public class DBEquip
    {
        private short id;
        private String name;
        private int points;
        private BitmapImage logo;
        private BitmapImage car;
        private String fullName;
        private String chief;
        private String chassis;
        private String powerUnit;
        private int firstTeamEntry;
        private int worldChampionship;
        private int fastestlap;
        private String desciption;

        public DBEquip(short id, string name, int points, string logo, string car, string fullName, string chief, string chassis, string powerUnit, int firstTeamEntry, int worldChampionship, int fastestlap, string desciption)
        {
            this.id = id;
            this.name = name;
            this.points = points;
            this.logo = new BitmapImage(new Uri(logo));
            this.car = new BitmapImage(new Uri(car));
            this.fullName = fullName;
            this.chief = chief;
            this.chassis = chassis;
            this.powerUnit = powerUnit;
            this.firstTeamEntry = firstTeamEntry;
            this.worldChampionship = worldChampionship;
            this.fastestlap = fastestlap;
            this.desciption = desciption;
        }

        public DBEquip(DBEquip e)
        {
            this.id = e.id;
            this.name = e.name;
            this.points = e.points;
            this.logo = e.logo;
            this.car = e.car;
            this.fullName = e.fullName;
            this.chief = e.chief;
            this.chassis = e.chassis;
            this.powerUnit = e.powerUnit;
            this.firstTeamEntry = e.firstTeamEntry;
            this.worldChampionship = e.worldChampionship;
            this.fastestlap = e.fastestlap;
            this.desciption = e.desciption;
        }




        public static List<DBEquip>getEquips()
        {
            using (var context = new MySQLDBContext())
            {

                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();
                    using (var consulta = connexio.CreateCommand())
                    {
                        consulta.CommandText = @"
                            select * from team
                        ";
                        DbDataReader reader = consulta.ExecuteReader();
                        List<DBEquip> equips = new List<DBEquip>();
                        while (reader.Read())
                        {
                            short id = reader.GetInt16(reader.GetOrdinal("t_id"));
                            string name = reader.GetString(reader.GetOrdinal("t_name"));
                            string description = reader.GetString(reader.GetOrdinal("t_desc"));
                            string fullName = reader.GetString(reader.GetOrdinal("t_fullName"));
                            int points = reader.GetInt32(reader.GetOrdinal("t_points"));
                            string logo = reader.GetString(reader.GetOrdinal("t_urlLogo"));
                            string car = reader.GetString(reader.GetOrdinal("t_urlCarPhoto"));
                            string chief = reader.GetString(reader.GetOrdinal("t_teamChief"));
                            string chassis = reader.GetString(reader.GetOrdinal("t_chassis"));
                            string powerUnit = reader.GetString(reader.GetOrdinal("t_powerUnit"));
                            int firstTimeEntry = reader.GetInt32(reader.GetOrdinal("t_firstTeamEntry"));
                            int worldChampionship = reader.GetInt32(reader.GetOrdinal("t_worldChampionships"));
                            int fastestLap = reader.GetInt32(reader.GetOrdinal("t_fastestLaps"));

                            equips.Add(new DBEquip(id, name, points, logo, car, fullName, chief, chassis, powerUnit, firstTimeEntry, worldChampionship, fastestLap, description));
                        }
                        return equips;
                    }

                }
            }
        }
    }
}
