using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe {
    public class Team {

        private string _teamName;
        private float _points = 0.0f;
        private int _guessed = 0;
        private int _notGuessed = 0;

        public string TeamName { get; set; }
        public float Points { get; set; }
        public int Guessed { get; set; }
        public int NotGuessed { get; set;}

        public Team(string TeamName) {
            _teamName = TeamName;
            this.TeamName = TeamName;
        }
    }
}
