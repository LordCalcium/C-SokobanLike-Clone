using System;
using static System.Console;

namespace StartMenu
{
    class Menu
    {
        private int SelectedIndex; //keep track
        private string[] Optain; // Keep track of optains
        private string Prompt; // What gets display before the menu optains display

        public Menu(string prompt, string[] optain)
        {
            Prompt = prompt;
            Optain = optain;
            SelectedIndex = 0;
        }

        public void DisplayOptains() //Whenever clear screen
        {
            WriteLine(Prompt);  
            for (int i = 0; i < Optain.Length; i++) 
            {
                string currentOptain = Optain[i];
                string prefix;

                if (i == SelectedIndex) //Check if SelectedIndex = CurrentIndex
                {
                    prefix = "->";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOptain} >>");
            }
            ResetColor(); //Display color outside of this THEN display default color
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptains();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--; 
                    if( SelectedIndex == -1 )
                    {
                        SelectedIndex = Optain.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Optain.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
