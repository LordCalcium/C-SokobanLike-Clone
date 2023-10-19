using playSokoban;
using StartMenu;
using System;
using static System.Console;


namespace StartGame
{
    class Game
    {
        public static void Main(string[] args)
        {
            
            RunMain();
            

            void RunMain()
            {
                string prompt = @"
 $$$$$$\            $$\                 $$\                                 
$$  __$$\           $$ |                $$ |                                
$$ /  \__| $$$$$$\  $$ |  $$\  $$$$$$\  $$$$$$$\   $$$$$$\  $$$$$$$\        
\$$$$$$\  $$  __$$\ $$ | $$  |$$  __$$\ $$  __$$\  \____$$\ $$  __$$\       
 \____$$\ $$ /  $$ |$$$$$$  / $$ /  $$ |$$ |  $$ | $$$$$$$ |$$ |  $$ |      
$$\   $$ |$$ |  $$ |$$  _$$<  $$ |  $$ |$$ |  $$ |$$  __$$ |$$ |  $$ |      
\$$$$$$  |\$$$$$$  |$$ | \$$\ \$$$$$$  |$$$$$$$  |\$$$$$$$ |$$ |  $$ |      
 \______/  \______/ \__|  \__| \______/ \_______/  \_______|\__|  \__|      
                                                                            
                                                                            
     Use ↑ and ↓ to navigate.
    Press ""Enter"" to select.                                                                        
";
                //Console.WriteLine("Use ↑ and ↓ to navigate.\nPress 'Shift + Enter' to select");

                string[] optain = { "Start", "How to Play","About","Exit" };
                Menu mainmenu = new Menu(prompt, optain);
                int selectedIndex = mainmenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        PlayGame();
                        break;
                    case 1:
                        HowToPlay();
                        break;
                    case 2:
                        AboutInfo();
                        break;
                    case 3:
                        ExitGame();
                        break;

                    default:
                        break;

                }
            }

            void PlayGame()
            {
                sokoban.MainSokobanRun();  
            }

            void HowToPlay()
            {
                Clear();
                WriteLine(@"
    __  __                 ______         ____  __               
   / / / /___ _      __   /_  __/___     / __ \/ /___ ___  __    
  / /_/ / __ \ | /| / /    / / / __ \   / /_/ / / __ `/ / / /    
 / __  / /_/ / |/ |/ /    / / / /_/ /  / ____/ / /_/ / /_/ /     
/_/ /_/\____/|__/|__/    /_/  \____/  /_/   /_/\__,_/\__, /      
                                                    /____/       
");
                WriteLine("Push the box('#') into the box storage('X').\n* You can't step into the box storage('X')");
                WriteLine("\n ♦ Press any key to return to main menu ♦\n");
                ReadKey(true);
                RunMain();
            }

            void AboutInfo()
            {
                Clear();
                WriteLine(@"
    ___    __                __     __  __                               _           __ 
   /   |  / /_  ____  __  __/ /_   / /_/ /_  ___     ____  _________    (_)__  _____/ /_
  / /| | / __ \/ __ \/ / / / __/  / __/ __ \/ _ \   / __ \/ ___/ __ \  / / _ \/ ___/ __/
 / ___ |/ /_/ / /_/ / /_/ / /_   / /_/ / / /  __/  / /_/ / /  / /_/ / / /  __/ /__/ /_  
/_/  |_/_.___/\____/\__,_/\__/   \__/_/ /_/\___/  / .___/_/   \____/_/ /\___/\___/\__/  
                                                 /_/              /___/                 
");
                WriteLine("This is a student project.\nThe project is a Sokoban like clone\n");
                WriteLine(@"
 _       ____          __     _         _____       __         __                   ___ 
| |     / / /_  ____ _/ /_   (_)____   / ___/____  / /______  / /_  ____ _____     /__ \
| | /| / / __ \/ __ `/ __/  / / ___/   \__ \/ __ \/ //_/ __ \/ __ \/ __ `/ __ \     / _/
| |/ |/ / / / / /_/ / /_   / (__  )   ___/ / /_/ / ,< / /_/ / /_/ / /_/ / / / /    /_/  
|__/|__/_/ /_/\__,_/\__/  /_/____/   /____/\____/_/|_|\____/_.___/\__,_/_/ /_/    (_)   
                                                                                        
");
                WriteLine("Sokoban is a puzzle video game in which the player pushes boxes around in a warehouse, " +
                    "\ntrying to get them to storage locations." +
                    "\nThe game was designed in 1981 by Hiroyuki Imabayashi, " +
                    "\nand first published in December 1982.");
                WriteLine("\n ♦ Press any key to return to main menu ♦\n");
                ReadKey(true);
                RunMain();
            }

            void ExitGame()
            {
                WriteLine("\nPress any key to exit...");
                ReadKey(true);
                Environment.Exit(0);
            }
        }



    }
}

