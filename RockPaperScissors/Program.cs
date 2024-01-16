using System;
using System.Threading;
using System.Collections.Generic;


namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            //KIVI, PAPERI ja SAKSET-konsolipeli
            Console.WriteLine("welcome to play rock-paper-scissors -game!");

            while (true)
            {

                Console.WriteLine("Choose number:");
                Console.WriteLine("\n 0 = Rock \n 1 = Paper \n 2 = Scissors \n 3 = Exit game");
                try
                {
                    Console.WriteLine("\n");
                    int userchoice = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine(userchoice);
             
                    if (userchoice == 3)
                    {
                        //huolehdi että jos painaa 3 vaihtoehdon niin ei tarjoa vaihtoehdot listaa
                        
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    int waitingtime = 500;
                    Console.WriteLine("\n");
                    //array/lista jossa on string parametrit
                    var itemsofgame = new List<string>()
                    {
                        "Rock..",
                        "..Paper..",
                        "..Scissors!"
                    };


                    for (int i= 0; i<3; i++)
                    {
                        PrintandWait(itemsofgame[i], waitingtime);
                    }

                    Random rnd = new Random();
                    int computerchoice = rnd.Next(0, 3); //valitsee numeron 0-2 väliltä
                    


                    if (userchoice == 0 && computerchoice == 1)
                    {
                        Console.WriteLine("Computer is the winner! Paper Beats Rock!");
                    }
                    else if (userchoice == 0 && computerchoice == 2)
                    {
                        Console.WriteLine("You win! Rock Beats Scissors!");
                    }
                    else if (userchoice == 1 && computerchoice == 0)
                    {
                        Console.WriteLine("You win. Paper Beats Rock!");
                    }
                    else if (userchoice == 1 && computerchoice == 2)
                    {
                        Console.WriteLine("Computer is the winner! Scissors Beats Paper!");
                    }
                    else if (userchoice == 2 && computerchoice == 0)
                    {
                        Console.WriteLine("Computer is the winner! Rock Beats Scissors!");
                    }
                    else if (userchoice == 2 && computerchoice == 1)
                    {
                        Console.WriteLine("Computer is the winner! Paper Beats Rock!");
                    }
                    else
                    {
                        Console.WriteLine("Oh you had same choice it's even. Try again.");
                    }
                    Console.WriteLine("\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("\nERROR! Use only numbers.\n");

                }
            }
        }

        static void PrintandWait(string gameitems, int waiting)
        {
            Console.WriteLine(gameitems);
            Thread.Sleep(waiting);
            Console.WriteLine("\n");
        }

    }
}
