using ElfmeterProjekt.Lib.Interfaces;
using ElfmeterProjekt.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElfmeterProjekt.Lib.Services
{
    public class SqliteRepository : IRepository
    {
        string _path = string.Empty;

        public SqliteRepository(string path)
        {
            _path = path;
        }

        public bool Add(Team team)
        {
            try
            {
                using (var context = new MyTeamContext(_path))
                {
                    context.Add(team);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

         public List<Team> GetAll() 
         {
            try
            {
                using (var context = new MyTeamContext(_path))
                {
                    

                    var teams = context.Teams.FromSql
                        ($"SELECT * FROM Teams").ToList();

                    return teams;
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Team>();
            }
        }

        public bool Delete(Team team)
        {
            try
            {
                using (var context = new MyTeamContext(_path))
                {
                    context.Remove(team);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public bool Update(Team team)
        {
            try
            {
                using(var context = new MyTeamContext(_path))
                {
                    var teamToUpdate = context.Teams.FirstOrDefault(t => t.Id == team.Id);

                    if (teamToUpdate == null)
                    {
                        return false;
                    }

                    teamToUpdate.TeamName = team.TeamName;
                    teamToUpdate.Liga = team.Liga;

                    context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
