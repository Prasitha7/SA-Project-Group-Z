using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Group_Z__21._1_
{
    public class BrailleService
    {
        private List<string> supportedChars;

        public BrailleService()
        {
            supportedChars = new List<string> { "A", "B", "C", "D", "E" };
        }

        public List<string> GetSupported()
        {
            return supportedChars;
        }

        public int GetDots(char brailleChar)
        {
            if (brailleChar == 'A')
            {
                return 2;
            }
            else if (brailleChar == 'B')
            {
                return 3;
            }
            else if (brailleChar == 'C')
            {
                return 4;
            }
            else if (brailleChar == 'D')
            {
                return 5;
            }
            else if (brailleChar == 'E')
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }
    }
}