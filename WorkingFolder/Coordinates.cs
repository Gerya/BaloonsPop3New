using System.Linq;

namespace Zirconium
{
    internal struct Coordinates
    {
        private const int MAX_COLS = 9;
        private const int MAX_ROWS = 4;

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
                if (value >= 0 && value <= MAX_COLS)
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
                if (value >= 0 && value <= MAX_ROWS)
                {
                    row = value;
                }
            }
        }

        public static bool TryParse(string input, ref Coordinates result)
        {
            char[] separators = { ' ', ',' };
            string[] substrings = input.Split(separators);
            
            
           if (substrings.Count<string>() != 2)
            {
                return false;
            }

            string coordinateRow = substrings[0].Trim();
            int row;
            if (int.TryParse(coordinateRow, out row))
            {
                if (row >= 0 && row <= MAX_ROWS)
                {
                    result.Row = row;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            string coordinateCol = substrings[1].Trim();
            int col;
            if (int.TryParse(coordinateCol, out col))
            {
                if (col >= 0 && col <= MAX_COLS)
                {
                    result.Col = col;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}