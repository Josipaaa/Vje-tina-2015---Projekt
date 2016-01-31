using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe {
    public class Team {

        public string TeamName { get; set; }
        public float Points { get; set; }
        public int Identifikator { get; set; }

        public Team(string TeamName, int Identifikator) {
            this.TeamName = TeamName;
            this.Identifikator = Identifikator;
        }
    }
}
