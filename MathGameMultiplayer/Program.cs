using MathGameEngine;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MathGameMultiplayer
{
    class Program
    {
        public static int PlayersNumber = 2;
        public static List<Player> PlayersData = new List<Player>();
        public static int QuestionsNumber = 0;
        public static GameEngine gameEngine;
        public static int TurnIndex;
        public static int PlayerIndex;
        public static int MaxTurns;
        const int CORRECT_POINTS = 10;

        static void Main(string[] args)
        {
            SetPlayersNumber();
            SetPlayersNames();
            SetNumberOfQuestions();
            InitializeGameEngine();
            StartGameEngine();
        }

        static void SetPlayersNumber()
        {
            Console.WriteLine("How many players would you like?");

            var playersNumberData = Console.ReadLine();
            int playersNumber = 0;

            if (int.TryParse(playersNumberData, out playersNumber))
            {
                PlayersNumber = playersNumber;
            }
        }

        static void SetPlayersNames()
        {
            for (int i = 0; i < PlayersNumber; i++)
            {
                Console.WriteLine(string.Format("What is the name of player {0}", i));

                Player player = new Player();
                player.Name = Console.ReadLine();

                PlayersData.Add(player);
            }
        }

        static void SetNumberOfQuestions()
        {
            Console.WriteLine("How many questions would you like?");

            var questionsNumberData = Console.ReadLine();
            int questionsNumber = 0;

            if (int.TryParse(questionsNumberData, out questionsNumber))
            {
                QuestionsNumber = questionsNumber;
            }
        }

        static void InitializeGameEngine()
        {
            gameEngine = new GameEngine(PlayersData, QuestionsNumber);
            TurnIndex = 0;
            PlayerIndex = 0;
            MaxTurns = QuestionsNumber;
        }

        static void StartGameEngine()
        {
            while (TurnIndex <= MaxTurns)
            {
                var playerTurnData = DetermineQuestionData();
                Console.WriteLine(playerTurnData.ToString());

                int playerTypedResult = 0;
                var playerAnswer = Console.ReadLine();

                int.TryParse(playerAnswer, out playerTypedResult);
                SavePlayerAnswer(playerTypedResult);

                string computerMessage = "Correct!";

                if (!playerTypedResult.Equals(playerTurnData.Operation.ExpectedResult))
                {
                    computerMessage = "Sorry, that wasn't quite right! I was expecting : " + playerTurnData.Operation.ExpectedResult;
                }

                Console.WriteLine(computerMessage);

                if (PlayerIndex < PlayersData.Count - 1)
                {
                    PlayerIndex++;
                }
                else
                {
                    if (TurnIndex < QuestionsNumber - 1)
                    {

                        TurnIndex++;
                        PlayerIndex = 0;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            PrepareScores();
            DisplayScores();

            Console.WriteLine("Game Over! Press any key to finish.");
            Console.ReadKey();
        }

        static PlayerTurnDataModel DetermineQuestionData()
        {
            var result = new PlayerTurnDataModel
            {
                PlayerName = PlayersData[PlayerIndex].Name,
                Operation = new MathOperation
                {
                    MathOp = PlayersData[PlayerIndex].MathOps[TurnIndex].MathOp,
                    FirstNumber = PlayersData[PlayerIndex].MathOps[TurnIndex].FirstNumber,
                    SecondNumber = PlayersData[PlayerIndex].MathOps[TurnIndex].SecondNumber,
                    ExpectedResult = PlayersData[PlayerIndex].MathOps[TurnIndex].ExpectedResult
                }
            };

            return result;
        }

        static void SavePlayerAnswer(int answer)
        {
            PlayersData[PlayerIndex].MathOps[TurnIndex].PlayerResult = answer;
        }

        static void PrepareScores()
        {
            foreach (var player in PlayersData)
            {
                foreach (var op in player.MathOps)
                {
                    if (op.ExpectedResult.Equals(op.PlayerResult))
                    {
                        player.Score += CORRECT_POINTS;
                    }
                }
            }
        }

        static void DisplayScores()
        {
            var players = PlayersData.OrderByDescending(p => p.Score).ToList();

            for (int index = 0; index < players.Count; index++)
            {
                if (index == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                string display = (index + 1) + "." + players[index].Name + " " + players[index].Score;
                Console.WriteLine(display);
            }
        }
    }
}