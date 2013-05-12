using System;
using System.Linq;

namespace Zirconium
{
    public class Player : IComparable
    {
        public string Name
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public static bool operator <(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.Score < secondPlayer.Score;
        }

        public static bool operator >(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.Score > secondPlayer.Score;
        }

        public int CompareTo(object obj)
        {
            Player secondPerson = obj as Player;

            if (secondPerson != null)
            {
                int result = this.Score.CompareTo(secondPerson.Score);
                return result;
            }
            else
            {
                throw new ArgumentException("You can compare only persons socore.");
            }
        }
    }
}
