using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe {
    public class Team {

        public string TeamName { get; set; }
        public float Points { get; set; }
        public int Guessed { get; set; }
        public int NotGuessed { get; set;}

        public Team(string TeamName) {
            this.TeamName = TeamName;
        }
    }
}
