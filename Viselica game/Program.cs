using System.Security.Cryptography;

string[] words ={ "Book", "House", "Apple", "River", "Window" };
Random randomaizer = new Random();
int index = randomaizer.Next(words.Length);
string word = words[index].ToLower();
int wrongAttempts = 0;
DrawHangman(wrongAttempts);
char[] letters= new char[word.Length];
for (int i=0; i< word.Length; i++)
{
    letters[i] = ('_');
}
foreach (char c in letters)
{
    Console.Write( c + (" "));
}

List<char> usedLetters = new List<char>();
while (wrongAttempts<6 && letters.Contains('_'))
{
    Console.WriteLine("\nEnter a letter");
    char symbol = Console.ReadKey().KeyChar;
    symbol = char.ToLower(symbol);
    if (char.IsLetter(symbol))
    {
        if (usedLetters.Contains(symbol))
            {
            Console.WriteLine( "\nThis letter was used before");
        }
        else
        {
            usedLetters.Add(symbol);
            if (word.Contains(symbol))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == symbol)
                    {
                        letters[i] = symbol;
                    }
                }
                Console.WriteLine("\nLetter was found");
                foreach (char c in letters)
                {
                    Console.Write(c + (" "));
                }
               
            }
            else
            {
                Console.WriteLine("\nLetter was not found");
                wrongAttempts++;
                DrawHangman(wrongAttempts);
                int attempts = 6 - wrongAttempts;
                Console.WriteLine($"You have {attempts} wrong attempts");
                foreach (char c in letters)
                {
                    Console.Write(c + (" "));
                }
                
            }
        }
        
    }
         
    else
    {
        Console.WriteLine("\nIt is not a letter idiot");
    }
}
if (wrongAttempts >= 6)
{
    Console.WriteLine("\nТИ ЛОХ\nThe word is "+ word);
}
else
{
    Console.WriteLine("\nПеремога!!!!!!!!!!!!!!!!!!!");
}


    void DrawHangman (int wrongAttempts)
{
    switch (wrongAttempts)
    {
        case 0: Console.WriteLine(@"+---+
 |   |
     |
     |
     |
     |
=========");
            break;
        case 1:
            Console.WriteLine(@"+---+
 |   |
 O   |
     |
     |
     |
=========");
            break;
        case 2:
            Console.WriteLine(@"+---+
 |   |
 O   |
 |   |
     |
     |
=========");
            break;
        case 3:
            Console.WriteLine(@"+---+
 |   |
 O   |
/|   |
     |
     |
=========");
            break;
        case 4:
            Console.WriteLine(@"+---+
 |   |
 O   |
/|\  |
     |
     |
=========");
            break;
        case 5:
            Console.WriteLine(@"+---+
 |   |
 O   |
/|\  |
/    |
     |
=========");
            break;
        case 6:
            Console.WriteLine(@"+---+
 |   |
 O   |
/|\  |
/ \  |
     |
=========");
            break;
    }
}