using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfmeterProjekt.Lib.Models
{
    public class Team
    {
        public string Id { get ; set; }

        public string TeamName { get; set; }

        public string Liga { get; set; }


        public Team(string id, string teamName, string liga)
        {
            this.Id = id;
            this.TeamName = teamName;
            this.Liga = liga;
        }

        public Team(string teamName, string liga)
        {
            this.Id = Guid.NewGuid().ToString();
            this.TeamName = teamName;
            this.Liga = liga;
        }
    }
}
