namespace UI
{
    internal class Day2
    {
        internal IDictionary<char, Thrown> _opponentThrowSymbols = new Dictionary<char, Thrown>();
        internal IDictionary<char, State> _stateSymbols = new Dictionary<char, State>();
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

            _stateSymbols.Add('X', State.Loss);
            _stateSymbols.Add('Y', State.Draw);
            _stateSymbols.Add('Z', State.Win);
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
            var desiredState = _stateSymbols[row[2]];

            var playerThrow = ThrowForGivenOpponentThrowAndState(opponentThrow, desiredState);
            var scoreForThrow = _thrownScores[playerThrow];
            var scoreForState = _stateScores[desiredState];
            return scoreForThrow + scoreForState;
        }

        private Thrown ThrowForGivenOpponentThrowAndState(Thrown opponentThrow, State state)
        {
            if (state == State.Draw)
            {
                return opponentThrow;
            }

            if (state == State.Win)
            {
                if (opponentThrow == Thrown.Rock)
                {
                    return Thrown.Paper;
                }
                if (opponentThrow == Thrown.Scissors)
                {
                    return Thrown.Rock;
                }
                if (opponentThrow == Thrown.Paper)
                {
                    return Thrown.Scissors;
                }
            }

            if (opponentThrow == Thrown.Rock)
            {
                return Thrown.Scissors;
            }
            if (opponentThrow == Thrown.Scissors)
            {
                return Thrown.Paper;
            }
            
            return Thrown.Rock;
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
