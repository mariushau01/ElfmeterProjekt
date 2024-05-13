using ElfmeterProjekt.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfmeterProjekt.Lib.Services
{
    public class MyTeamContext : DbContext
    {

        public DbSet<Team> Teams { get; set; }

        private string _path = string.Empty;

        public MyTeamContext(string path)
        {
            _path = path;

            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            Debug.WriteLine(_path);

            optionsBuilder.UseSqlite($"Filename={_path}");

            //base.OnConfiguring(optionsBuilder);
        }

    }
}
