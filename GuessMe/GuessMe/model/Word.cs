using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe {
    public sealed class Word {

        private string _term;
        private DifficultyEnum _difficulty = DifficultyEnum.MEDIUM;
        private bool _isGuessable = true;
        private bool _isDrawable = true;
        private bool _isPantomimable = true; //??????

        public string Term { get; set; }
        public DifficultyEnum Difficulty { get; set; }
        public bool IsGuessable { get; set; }
        public bool IsDrawable { get; set; }
        public bool IsPantomimable { get; set; }

        public Word(string Term) {
            _term = Term;
        }

        public Word(string Term, DifficultyEnum Difficulty, bool IsGuessable, bool IsDrawable, bool IsPantomimable) {
            _term = Term;
            _difficulty = Difficulty;
            _isGuessable = IsGuessable;
            _isDrawable = IsDrawable;
            _isPantomimable = IsPantomimable;
        }
        
    }
}
