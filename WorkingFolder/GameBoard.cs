using System;
using System.Text;
using System.Linq;

namespace Zirconium
{
    internal class GameBoard
    {
        private char[,] gameBoard = new char[25, 8];
        private int shootCounter = 0;
        private int baloonCounter = 50;

        public int ShootCounter
        {
            get
            {
                return shootCounter;
            }
        }

        public int RemainingBaloons
        {
            get
            {
                return baloonCounter;
            }
        }

        public void GenerateNewGameBoard()
        {
            FillBlankGameBoard();

            Random randomGenerator = new Random();
            Coordinates coordinates = new Coordinates();
            for (int col = 0; col < 10; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    coordinates.Col = col;
                    coordinates.Row = row;
                    char ballonColor = (char)(randomGenerator.Next(1, 5) + (int)'0');
                    AddNewBaloonToGameBoard(coordinates, ballonColor);
                }
            }
        }

        private void AddNewBaloonToGameBoard(Coordinates coordinates, char ballonColor)
        {
            int xPosition, yPosition;
            xPosition = 4 + coordinates.Col * 2;
            yPosition = 2 + coordinates.Row;
            gameBoard[xPosition, yPosition] = ballonColor;
        }

        private char GetBaloonColor(Coordinates coordinates)
        {
            int xPosition = 4 + coordinates.Col * 2;
            int yPosition = 2 + coordinates.Row;

            char ballonColor = gameBoard[xPosition, yPosition];
            return ballonColor;
        }

        private void FillBlankGameBoard()
        {
            //adding blank spaces
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 25; col++)
                {
                    gameBoard[col, row] = ' ';
                }
            }

            //Ask Gery !!!
            char boardNotation = '0';

            for (int col = 4; col < 25; col++)
            {
                if ((col % 2 == 0) && boardNotation <= '9')
                {
                    gameBoard[col, 0] = (char)boardNotation++;
                }
                //adding top and bottom border wall
                gameBoard[col - 1, 1] = '-';
                gameBoard[col - 1, 7] = '-';
            }

            boardNotation = '0';

            for (int row = 2; row < 8; row++)
            {
                if (boardNotation <= '4')
                {
                    gameBoard[0, row] = boardNotation++;
                }
                //adding left and right game board wall
                if (row < 7)
                {
                    gameBoard[24, row] = '|';
                    gameBoard[2, row] = '|';
                }
            }
        }

        public void ShootBaloons(Coordinates currentCoordinates)
        {
            char currentBaloon;
            currentBaloon = GetBaloonColor(currentCoordinates);
            Coordinates neighborCoordinates = new Coordinates();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                throw new BaloonsPopExceptions.PopedBallonException("Illegal move: cannot pop missing ballon!");
            }

            AddNewBaloonToGameBoard(currentCoordinates, '.');
            baloonCounter--;

            neighborCoordinates.Col = currentCoordinates.Col - 1;
            neighborCoordinates.Row = currentCoordinates.Row;
            while (currentBaloon == GetBaloonColor(neighborCoordinates))
            {
                AddNewBaloonToGameBoard(neighborCoordinates, '.');
                baloonCounter--;
                neighborCoordinates.Col--;
            }

            neighborCoordinates.Col = currentCoordinates.Col + 1; 
            neighborCoordinates.Row = currentCoordinates.Row;
            while (currentBaloon == GetBaloonColor(neighborCoordinates))
            {
                AddNewBaloonToGameBoard(neighborCoordinates, '.');
                baloonCounter--;
                neighborCoordinates.Col++;
            }

            neighborCoordinates.Col = currentCoordinates.Col;
            neighborCoordinates.Row = currentCoordinates.Row - 1;
            while (currentBaloon == GetBaloonColor(neighborCoordinates))
            {
                AddNewBaloonToGameBoard(neighborCoordinates, '.');
                baloonCounter--;
                neighborCoordinates.Row--;
            }

            neighborCoordinates.Col = currentCoordinates.Col;
            neighborCoordinates.Row = currentCoordinates.Row + 1;
            while (currentBaloon == GetBaloonColor(neighborCoordinates))
            {
                AddNewBaloonToGameBoard(neighborCoordinates, '.');
                baloonCounter--;
                neighborCoordinates.Row++;
            }

            shootCounter++;
            LandFlyingBaloons();
        }

        private void SwapBaloonsPosition(Coordinates currentCoordinates, Coordinates newCoordinates)
        {
            char currentBallon = GetBaloonColor(currentCoordinates);
            AddNewBaloonToGameBoard(currentCoordinates, GetBaloonColor(newCoordinates));
            AddNewBaloonToGameBoard(newCoordinates, currentBallon);
        }

        private void LandFlyingBaloons()
        {
            Coordinates currentCoordinates = new Coordinates();
            for (int col = 0; col < 10; col++)
            {
                for (int row = 0; row <= 4; row++)
                {
                    currentCoordinates.Col = col;
                    currentCoordinates.Row = row;
                    if (GetBaloonColor(currentCoordinates) == '.')
                    {
                        for (int rowIndex = row; rowIndex > 0; rowIndex--)
                        {
                            Coordinates oldCoordinates = new Coordinates();
                            Coordinates newCoordinates = new Coordinates();
                            oldCoordinates.Col = col;
                            oldCoordinates.Row = rowIndex;
                            newCoordinates.Col = col;
                            newCoordinates.Row = rowIndex - 1;
                            SwapBaloonsPosition(oldCoordinates, newCoordinates);
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder gameBoardAsString = new StringBuilder();

            gameBoardAsString.AppendLine();
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 25; row++)
                {
                    gameBoardAsString.Append(gameBoard[row, col]);
                }
                gameBoardAsString.AppendLine();
            }
            gameBoardAsString.AppendLine();

            return gameBoardAsString.ToString();
        }
    }
}
