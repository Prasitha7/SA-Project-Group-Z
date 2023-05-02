using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlindServer
{
    public class BrailleService
    {
        private string[] supportedChars;

        //Supported charactors
        public  BrailleService()
        {
            supportedChars = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z","1","2","3","4","5","6","7","8","9","0"};
        }

        //return supported charactors to Server program
        public string[] GetSupported()
        {
            return supportedChars;
        }


        public int GetBrailleDots(string text)
        {
            List<int> brailleList = new List<int>();


            for (int i = 0; i < text.Length; i++)
            {
                // get the character at the current index
                char currentChar = text[i];

                //run that charactor through CalDots
                int currentDot = CalDots(currentChar);

                brailleList.Add(currentDot);

                //Display returende value
                Console.Write(currentDot+","); 

            }
            int dotCount = brailleList.Sum();

            return dotCount;
        }

        public int CalDots(char brailleChar)
        {
            if (brailleChar == 'A'|| brailleChar == 'a'|| brailleChar == '1')
            {
                return 1;
            }
            else if (brailleChar == 'B'|| brailleChar == 'C'|| brailleChar == 'E' || brailleChar == 'I' || brailleChar == 'K' || brailleChar == 'b' || brailleChar == 'c' || brailleChar == 'e' || brailleChar == 'i' || brailleChar == 'k' || brailleChar == '2' || brailleChar == '5' || brailleChar == '9')
            {
                return 2;
            }
            else if (brailleChar == 'D'|| brailleChar == 'F' || brailleChar == 'H' || brailleChar == 'J' || brailleChar == 'L' || brailleChar == 'M' || brailleChar == 'O' || brailleChar == 'S' || brailleChar == 'U' || brailleChar == 'd' || brailleChar == 'f' || brailleChar == 'h' || brailleChar == 'j' || brailleChar == 'l' || brailleChar == 'm' || brailleChar == 'o' || brailleChar == 's' || brailleChar == 'u' || brailleChar == '4' || brailleChar == '6' || brailleChar == '8' || brailleChar == '0')
            {
                return 3;
            }
            else if (brailleChar == 'G'|| brailleChar == 'N' || brailleChar == 'P' || brailleChar == 'R' || brailleChar == 'T' || brailleChar == 'V' || brailleChar == 'W' || brailleChar == 'X' || brailleChar == 'Z' || brailleChar == 'g' || brailleChar == 'n' || brailleChar == 'p' || brailleChar == 'r' || brailleChar == 't' || brailleChar == 'v' || brailleChar == 'w' || brailleChar == 'x' || brailleChar == 'z' || brailleChar == '7' )
            {
                return 4;
            }
            else if (brailleChar == 'Q'|| brailleChar == 'Y'|| brailleChar == 'q' || brailleChar == 'y')
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
