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
                return;
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

            neighborCoordinates.Col = currentCoordinates.Col + 1; neighborCoordinates.Row = currentCoordinates.Row;
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

        private void Swap(Coordinates c, Coordinates c1)
        {
            char tmp = GetBaloonColor(c);
            AddNewBaloonToGameBoard(c, GetBaloonColor(c1));
            AddNewBaloonToGameBoard(c1, tmp);


        }

        private void LandFlyingBaloons()
        {
            Coordinates c = new Coordinates();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    c.Col = i;
                    c.Row = j;
                    if (GetBaloonColor(c) == '.')
                    {
                        for (int k = j; k > 0; k--)
                        {
                            Coordinates tempCoordinates = new Coordinates();
                            Coordinates tempCoordinates1 = new Coordinates();
                            tempCoordinates.Col = i;
                            tempCoordinates.Row = k;
                            tempCoordinates1.Col = i;
                            tempCoordinates1.Row = k - 1;
                            Swap(tempCoordinates, tempCoordinates1);
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
