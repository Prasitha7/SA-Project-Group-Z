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
            supportedChars = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        }

        public List<string> GetSupported()
        {
            return supportedChars;
        }

        public List<int> GetBraille(string text)
        {
            List<int> brailleList = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                // get the character at the current index
                char currentChar = text[i];

                GetDots(currentChar);

                brailleList.Add(currentChar);
            }

            return brailleList;
        }

        public int GetDots(char brailleChar)
        {
            if (brailleChar == 'A'|| brailleChar == '1')
            {
                return 1;
            }
            else if (brailleChar == 'B'|| brailleChar == 'C'|| brailleChar == 'E' || brailleChar == 'I' || brailleChar == 'K' || brailleChar == '2' || brailleChar == '5' || brailleChar == '9')
            {
                return 2;
            }
            else if (brailleChar == 'D'|| brailleChar == 'F' || brailleChar == 'H' || brailleChar == 'J' || brailleChar == 'L' || brailleChar == 'M' || brailleChar == 'O' || brailleChar == 'S' || brailleChar == 'U' || brailleChar == '4' || brailleChar == '6' || brailleChar == '8' || brailleChar == '0' ||)
            {
                return 3;
            }
            else if (brailleChar == 'G'|| brailleChar == 'N' || brailleChar == 'P' || brailleChar == 'R' || brailleChar == 'T' || brailleChar == 'V' || brailleChar == 'W' || brailleChar == 'X' || brailleChar == 'Z' || brailleChar == '7' )
            {
                return 4;
            }
            else if (brailleChar == 'Q'|| brailleChar == 'Y')
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}