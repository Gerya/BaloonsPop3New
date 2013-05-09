using System;
using System.Linq;
using BaloonsPopExceptions;

namespace Zirconium
{
    public class BaloonsPop
    {
        private static bool ReadInput(out bool IsCoordinates, ref Coordinates coordinates, ref Command command)
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            coordinates = new Coordinates();
            command = new Command();

            if (Command.TryParse(consoleInput, ref command))
            {
                IsCoordinates = false;
                return true;
            }
            else if (Coordinates.TryParse(consoleInput, ref coordinates))
            {
                IsCoordinates = true;
                return true;
            }
            else
            {
                IsCoordinates = false;
                return false;
            }
        }

        static void Main()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            
            GameBoard gameBoard = new GameBoard();
            gameBoard.GenerateNewGameBoard();

            Console.WriteLine(gameBoard.ToString());

            TopScore.OpenTopScoreList();
            
            bool isCoordinates;
            Coordinates coordinates = new Coordinates();
            Command command = new Command();

            while (gameBoard.RemainingBaloons > 0)
            {
                if (ReadInput(out isCoordinates, ref coordinates, ref command))
                {
                    if (isCoordinates)
                    {
                        try
                        {
                            gameBoard.ShootBaloons(coordinates);
                        }
                        catch (PopedBallonException exp)
                        {
                            Console.WriteLine(exp.Message);
                        }
                        
                        Console.WriteLine(gameBoard.ToString());
                    }
                    else
                    {
                        switch (command.Value)
                        {
                            case "top":
                                {
                                    TopScore.PrintScoreList();
                                }
                                break;
                            case "restart":
                                {
                                    gameBoard.GenerateNewGameBoard();
                                    Console.WriteLine(gameBoard.ToString());
                                }
                                break;
                            case "exit":
                                {
                                    return;
                                }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input!");
                }
            }

            Player player = new Player();
            player.Score = gameBoard.ShootCounter;

            if (TopScore.IsTopScore(player))
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");
                player.Name = Console.ReadLine();
                TopScore.AddToTopScoreList(player);
            }
            TopScore.SaveTopScoreList();
            TopScore.PrintScoreList();
        }
    }
}
