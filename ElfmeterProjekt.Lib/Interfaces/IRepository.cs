using ElfmeterProjekt.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfmeterProjekt.Lib.Interfaces
{
    public interface IRepository
    {
        public bool Add(Team team);

        public List<Team> GetAll();

        public bool Delete(Team team);

        public bool Update(Team team);


    }
}
