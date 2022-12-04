using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Day2
    {
        internal IDictionary<char, Thrown> _opponentThrowSymbols = new Dictionary<char, Thrown>();
        internal IDictionary<char, Thrown> _playerThrowSymbols = new Dictionary<char, Thrown>();
        internal IDictionary<Thrown, int> _thrownScores = new Dictionary<Thrown, int>();
        internal IDictionary<State, int> _stateScores = new Dictionary<State, int>();

        internal Day2()
        {
            _thrownScores.Add(Thrown.Rock, 1);
            _thrownScores.Add(Thrown.Paper, 2);
            _thrownScores.Add(Thrown.Scissors, 3);

            _stateScores.Add(State.Loss, 0);
            _stateScores.Add(State.Draw, 3);
            _stateScores.Add(State.Win, 6);

            _opponentThrowSymbols.Add('A', Thrown.Rock);
            _opponentThrowSymbols.Add('B', Thrown.Paper);
            _opponentThrowSymbols.Add('C', Thrown.Scissors);

            _playerThrowSymbols.Add('X', Thrown.Rock);
            _playerThrowSymbols.Add('Y', Thrown.Paper);
            _playerThrowSymbols.Add('Z', Thrown.Scissors);
        }

        internal int RunDay2_1()
        {
            var input = File.ReadAllLines("C:/Projects/Advent of Code 2022/UI/Day2.txt");
            var score = 0;
            foreach (var row in input)
            {
                score += ParseScoreForRow(row);
            }

            return score;
        }

        private int ParseScoreForRow(string row)
        {
            if (row.Length != 3)
            {
                throw new Exception();
            }

            var opponentThrow = _opponentThrowSymbols[row[0]];
            var playerThrow = _playerThrowSymbols[row[2]];

            var state = StateForThrows(opponentThrow, playerThrow);
            var scoreForThrow = _thrownScores[playerThrow];
            var scoreForState = _stateScores[state];
            return scoreForThrow + scoreForState;
        }

        private State StateForThrows(Thrown opponentThrow, Thrown playerThrow)
        {
            if (opponentThrow == playerThrow)
            {
                return State.Draw;
            }

            if ((opponentThrow == Thrown.Rock && playerThrow == Thrown.Paper)
                || (opponentThrow == Thrown.Paper && playerThrow == Thrown.Scissors)
                || (opponentThrow == Thrown.Scissors && playerThrow == Thrown.Rock))
            {
                return State.Win;
            }

            return State.Loss;
        }
    }

    internal enum Thrown
    {
        Rock = 0,
        Paper = 1,
        Scissors = 2
    }

    internal enum State
    {
        Loss = 0,
        Draw = 1,
        Win = 2
    }
}
