using System;
using System.Collections.Generic;
using System.Text;
using Viselica_game;

namespace Viselica_game
{
    class HangmanStrings
    {
        private static string[] hangman = { @"+---+
 |   |
     |
     |
     |
     |
=========", @"+---+
 |   |
 O   |
     |
     |
     |
=========", @"+---+
 |   |
 O   |
 |   |
     |
     |
=========", @"+---+
 |   |
 O   |
/|   |
     |
     |
=========", @"+---+
 |   |
 O   |
/|\  |
     |
     |
=========", @"+---+
 |   |
 O   |
/|\  |
/    |
     |
=========", @"+---+
 |   |
 O   |
/|\  |
/ \  |
     |
=========" };

        public static int HangmanLength()
        {
            return hangman.Length;
        }

        public static string Hangman(int num)
        {
            return hangman[num];
        }
    }
}

