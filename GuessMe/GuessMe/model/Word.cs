using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe {
    public sealed class Word {

        public string Term { get; set; }
        public DifficultyEnum Difficulty { get; set; }
        public bool IsGuessable { get; set; }
        public bool IsDrawable { get; set; }
        public bool IsPantomimable { get; set; }

        public Word(string Term) {
            this.Term = Term;
        }

        public Word(string Term, DifficultyEnum Difficulty, bool IsGuessable, bool IsDrawable, bool IsPantomimable) {
            this.Term= Term;
            this.Difficulty = Difficulty;
            this.IsGuessable = IsGuessable;
            this.IsDrawable = IsDrawable;
            this.IsPantomimable = IsPantomimable;
        }
        
    }
}
