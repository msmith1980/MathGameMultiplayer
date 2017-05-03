using MathLib;
using Models;
using System.Collections.Generic;

namespace MathGameEngine
{
    public sealed class GameEngine
    {
        List<Player> _players;
        int _questionsNumber;
        int _upperLimit;

        public GameEngine(List<Player> players, int questionsNumber, int upperLimit)
        {
            _players = players;
            _questionsNumber = questionsNumber;
            _upperLimit = upperLimit;
            this.GenerateOps();
        }


        public void GenerateOps()
        {
            var mathEngine = new MathEngine(_upperLimit);

            foreach (var player in _players)
            {
                for (int indexOp = 0; indexOp < _questionsNumber; indexOp++)
                {
                    var newOp = new PlayerMathOperation(mathEngine.GenerateCompleteOperation());
                    player.MathOps.Add(newOp);
                }
            }
        }
    }
}
