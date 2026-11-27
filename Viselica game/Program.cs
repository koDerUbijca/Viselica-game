using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using Viselica_game;

string[] words ={ "Book", "House", "Apple", "River", "Window" };
const int MaxLives = 6;
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
    DisplayWord(letters);

List<char> usedLetters = new List<char>();
while (wrongAttempts< MaxLives && letters.Contains('_'))
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
            if (!CheckLetter(word, symbol))
            {
                Console.WriteLine("\nLetter was not found");
                DisplayWord(letters);
                wrongAttempts++;
                DrawHangman(wrongAttempts);
                int attempts = MaxLives - wrongAttempts;
                Console.WriteLine($"You have {attempts} wrong attempts");
                Console.WriteLine("Used letters " + string.Join(" ", usedLetters));
            }
            else
            {
                Console.WriteLine("\nLetter was found");
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == symbol)
                    {
                        letters[i] = symbol;
                    }
                }
                DisplayWord(letters);
                Console.WriteLine("Used letters " + string.Join(" ", usedLetters));
            }
        }
        
    }
         
    else
    {
        Console.WriteLine("\nIt is not a letter idiot");
    }
}
 DisplayResult(wrongAttempts, letters);



   

void DrawHangman(int wrongAttempts)
{
    
    if ((wrongAttempts < HangmanStrings.HangmanLength()) && wrongAttempts >= 0)
    {
        Console.WriteLine(HangmanStrings.Hangman(wrongAttempts));
    }
    else { Console.WriteLine("ERROR"); }
}
    
 

void DisplayWord(char[] letters)
{
    foreach (char c in letters)
    {
        Console.Write(c + (" "));
    }
}

bool CheckLetter (string word , char symbol)
{
    return word.Contains(symbol);
}
    

void DisplayResult(int wrongAttempts, char[] letters)
{
    if (wrongAttempts >= MaxLives)
    {
        Console.WriteLine("\nТИ ЛОХ\nThe word is " + word);
    }
    else if (!letters.Contains('_'))
    {
        Console.WriteLine("\nПеремога!!!!!!!!!!!!!!!!!!!");
    }
}
    
