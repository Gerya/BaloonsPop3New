using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zirconium
{
    class Person: IComparable
    {
        string name;
        int score;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public static bool operator <(Person x, Person y)
        {
            return x.Score < y.Score;
        }

        public static bool operator >(Person x, Person y)
        {
            return x.Score > y.Score;
        }

        public int CompareTo(object obj)
        {
            Person secondPerson = obj as Person;

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
