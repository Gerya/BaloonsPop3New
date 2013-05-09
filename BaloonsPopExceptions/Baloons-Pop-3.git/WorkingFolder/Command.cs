using System;
using System.Linq;

namespace Zirconium
{
    class Command
    {

        private string command;

        public string Value
        {
            get
            {
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public static bool TryParse(string input, ref Command result)
        {
            bool parseResult = false;

            if (input == "top")
            {
                result.Value = input;
                parseResult = true;
            }

            else if (input == "restart")
            {
                result.Value = input;
                parseResult = true;
            }

            else if (input == "exit")
            {
                result.Value = input;
                parseResult = true;
            }

            return parseResult;
            
        }
    }
}
