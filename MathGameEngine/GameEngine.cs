using MathLib;
using Models;
using System.Collections.Generic;

namespace MathGameEngine
{
    public sealed class GameEngine
    {
        int _playerTurnIndex;
        List<Player> _players;
        int _questionsNumber;
        int scoreCorrectPoints = 10;

        public GameEngine(List<Player> players, int questionsNumber)
        {
            this._players = players;
            this._questionsNumber = questionsNumber;
            this._playerTurnIndex = 0;
            this.GenerateOps();
        }


        public void GenerateOps()
        {
            var mathEngine = new MathEngine(100);

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
