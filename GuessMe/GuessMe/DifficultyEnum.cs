using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe {
    public sealed class DifficultyEnum {

        private readonly string difficulty;
        private readonly int difficultyValue;

        public static readonly DifficultyEnum EASY = new DifficultyEnum(0, "EASY");
        public static readonly DifficultyEnum MEDIUM = new DifficultyEnum(1, "MEDIUM");
        public static readonly DifficultyEnum HARD = new DifficultyEnum(2, "HARD");

        private DifficultyEnum(int difficultyValue, string difficulty) {

            this.difficulty = difficulty;
            this.difficultyValue = difficultyValue;

        }

        public override string ToString() {

            return difficulty;
        }
    }
}
