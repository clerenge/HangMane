using System;
using System.Collections;

namespace HangMan
{
    class Program
    {
        //Initializing variables
        private static string secretWord = "Cow";
        private static int secretWordLength = secretWord.Length;
        private static int arrayWidth = 12 + secretWordLength;
        private static int arrayHeight = 5;
        private static string[,] array = new string[arrayWidth,arrayHeight];
        private static char guess = ' ';
        private static int lives = 6;
        private static ArrayList indices = new ArrayList();
        private static int correctLetters = 0;
        private static char playAgain = ' ';

        static void Main(string[] args)
        {
            //Generate the array that is used to print the hangman game
            generateArray();

            //Show the basic rules of the game
            Console.WriteLine("      Welcome to Hangman!");
            Console.WriteLine("*************Rules**************");
            Console.WriteLine("-Secret Words are single words-");
            Console.WriteLine("-Guesses are not case sensitive-");
            Console.WriteLine("      -You have 6 lives-");
            Console.WriteLine("********************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //While the player has not won or lost
            while (lives > 0 && (correctLetters < secretWordLength))
            {
                //Output the number of lives
                Console.WriteLine("Lives: " + lives);
                //Console.WriteLine("CorrectLetters: " + correctLetters);
                //Console.WriteLine("SecretWordLength: " + secretWordLength);
                printArray();
                if(lives > 0 && correctLetters != secretWordLength)
                {
                    Console.Write("Your Guess: ");
                    guess = Console.ReadKey().KeyChar;
                }
                else
                {
                    guess = '0';
                }
                //Console.WriteLine("guess = " + guess);
                Console.WriteLine();
                if (secretWord.Contains(Char.ToUpper(guess)) || secretWord.Contains(Char.ToLower(guess)))
                {
                    //Console.WriteLine("secretWord.Contains(guess)");
                    for (int i = 0; i < secretWordLength; i++)
                    {
                        if (secretWord[i] == Char.ToUpper(guess) || secretWord[i] == Char.ToLower(guess))
                        {
                            
                                indices.Add(i);
                            

                            
                        }
                    }

                    foreach (int index in indices)
                    {
                        if(index == 0)
                        {
                            array[11 + index, 3] = guess.ToString().ToUpper();
                        }
                        else
                        {
                            array[11 + index, 3] = guess.ToString().ToLower();
                        }
                        
                        correctLetters++;
                    }
                    indices.Clear();

                }
                else
                {
                    lives--;

                    switch(lives)
                    {
                        case 5:
                            array[8, 1] = "O";
                        break;
                        case 4:
                            array[8, 2] = "|";
                            break;
                        case 3:
                            array[7, 2] = "/";
                            
                            break;
                        case 2:
                            array[9, 2] = "\\";
                            
                            break;
                        case 1:
                            array[7, 3] = "/";
                            break;

                        case 0:
                            array[9, 3] = "\\";
                            break;

                    }
                }
                clearScreen();
                if(correctLetters == secretWordLength)
                {
                    clearScreen();
                    printArray();
                    Console.WriteLine("You WON with " + lives + " lives to spare!!");
                    Console.Write("Play Again? 'Y' for yes, 'N' for no: ");
                    playAgain = Console.ReadKey().KeyChar;
                    if(playAgain == 'Y' || playAgain == 'y')
                    {
                        correctLetters = 0;
                        lives = 6;
                        generateArray();
                        clearScreen();
                    }
                    else
                    {
                        clearScreen();
                        Console.WriteLine("Thanks For Playing :)");
                    }
                }
                if(lives == 0)
                {
                    clearScreen();
                    printArray();
                    Console.WriteLine("You LOST :( No lives left.");
                    Console.WriteLine("The secret word was: " + secretWord);
                    Console.Write("Play Again? 'Y' for yes, 'N' for no: ");
                    playAgain = Console.ReadKey().KeyChar;
                    if (playAgain == 'Y' || playAgain == 'y')
                    {
                        correctLetters = 0;
                        lives = 6;
                        generateArray();
                        clearScreen();
                    }
                    else
                    {
                        clearScreen();
                        Console.WriteLine("Thanks For Playing :)");
                    }

                }
            }
            
        }

        public static void generateArray()
        {
            GenerateRow0(secretWordLength);
            GenerateRow1(secretWordLength);
            GenerateRow2(secretWordLength);
            GenerateRow3(secretWordLength);
            GenerateRow4(secretWordLength);
        }

        public static void printArray()
        {
            for(int i = 0; i < arrayHeight; i++)
            {
                for(int j = 0; j < arrayWidth; j++)
                {
                    if(i == 3 && j > 10)
                    {
                        Console.Write(array[j, i] + " ");
                    }
                    else
                    {
                        Console.Write(array[j, i]);
                    }
                    
                }
                Console.WriteLine();
                
            }

        }

     

        public static void GenerateRow0(int width)
        {
            array[0, 0] = " ";
            array[1, 0] = " ";
            array[2, 0] = ";";
            array[3, 0] = " ";
            array[4, 0] = "-";
            array[5, 0] = " ";
            array[6, 0] = "-";
            array[7, 0] = " ";
            array[8, 0] = ",";
            array[9, 0] = " ";
            array[10, 0] = " ";
            array[11, 0] = " ";
            for(int i = 0; i < width; i++)
            {
                array[11 + i, 0] = " ";
            }
        }

        public static void GenerateRow1(int width)
        {
            array[0, 1] = " ";
            array[1, 1] = " ";
            array[2, 1] = "|";
            array[3, 1] = " ";
            array[4, 1] = " ";
            array[5, 1] = " ";
            array[6, 1] = " ";
            array[7, 1] = " ";
            array[8, 1] = " ";
            array[9, 1] = " ";
            array[10, 1] = " ";
            array[11, 1] = " ";
            for(int i = 0; i < width; i++)
            {
                array[11 + i, 1] = " ";
            }

        }

        public static void GenerateRow2(int width)
        {
            array[0, 2] = " ";
            array[1, 2] = " ";
            array[2, 2] = "|";
            array[3, 2] = " ";
            array[4, 2] = " ";
            array[5, 2] = " ";
            array[6, 2] = " ";
            array[7, 2] = " ";
            array[8, 2] = " ";
            array[9, 2] = " ";
            array[10, 2] = " ";
            array[11, 2] = " ";
            for (int i = 0; i < width; i++)
            {
                array[11 + i, 2] = " ";
            }
        }

        public static void GenerateRow3(int width)
        {
            array[0, 3] = " ";
            array[1, 3] = " ";
            array[2, 3] = "|";
            array[3, 3] = " ";
            array[4, 3] = " ";
            array[5, 3] = " ";
            array[6, 3] = " ";
            array[7, 3] = " ";
            array[8, 3] = " ";
            array[9, 3] = " ";
            array[10, 3] = " ";
            array[11, 3] = " ";
            for (int i = 0; i < width; i++)
            {
                array[11 + i, 3] = "_";
            }
        }

        public static void GenerateRow4(int width)
        {
            array[0, 4] = "_";
            array[1, 4] = "_";
            array[2, 4] = "|";
            array[3, 4] = "_";
            array[4, 4] = "_";
            array[5, 4] = "_";
            array[6, 4] = "_";
            array[7, 4] = "_";
            array[8, 4] = "_";
            array[9, 4] = "_";
            array[10, 4] = "_";
            array[11, 4] = " ";
            for (int i = 0; i < width; i++)
            {
                array[11 + i, 4] = " ";
            }
        }

        public static void clearScreen()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
