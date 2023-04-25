using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Group_Z__21._1_
{
    public class Braille
    {
        private char character;
        private int dots;

        public Braille(char brailleChar, int numDots)
        {
            character = brailleChar;
            dots = numDots;
        }

        public char GetCharacter()
        {
            return character;
        }

        public int GetDots()
        {
            return dots;
        }
    }
}