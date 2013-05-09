using System;
using System.Linq;

namespace Zirconium
{
    internal struct Coordinates
    { // ala balaaaaaa
        private int col;
        private int row;

        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    col = value;
                }
            }
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    row = value;
                }
            }
        }

        public static bool TryParse(string input, ref Coordinates result)
        {
            char[] separators = { ' ', ',' };
            string[] substrings = input.Split(separators);
            
            // Double check -> baloons pop
            //if (substrings.Count<string>() != 2)
            //{
            //    Console.WriteLine("Invalid move or command!");
            //    return false;
            //}

            string coordinateRow = substrings[0].Trim();
            int row;
            if (int.TryParse(coordinateRow, out row))
            {
                if (row >= 0 && row <= 4)
                {
                    result.Row = row;
                }
                else
                {
                    //Console.WriteLine("Wrong row coordinate");
                    return false;
                }
            }
            else
            {
                //Console.WriteLine("Invalid move or command!");
                return false;
            }

            string coordinateCol = substrings[1].Trim();
            int col;
            if (int.TryParse(coordinateCol, out col))
            {
                if (col >= 0 && col <= 9)
                {
                    result.Col = col;
                }
                else
                {
                    Console.WriteLine("Wrong column coordinate");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid move or command!");
                return false;
            }

            return true;
        }
    }
}
