using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to play Rock-Paper-Scissors -game!");

            while (true)
            {

                Console.WriteLine("Choose number:");
                Console.WriteLine("\n 0 = Rock \n 1 = Paper \n 2 = Scissors \n 3 = Exit game");
                try
                {
                    Console.WriteLine("\n");
                    //ohjataan tietokonetta lukemaan pelaajan valinta konsolista ja luodaan se
                    int userchoice = Convert.ToInt32(Console.ReadLine());
                    //tulostetaan konsoliin pelaajan valinta.


                    Console.WriteLine("Enter your name:");
                    string userInput = Console.ReadLine();

                    // Tiedostopolku jonne userinput tallentuu
                    string filePath = @"C:\Users\JuttaVirta_0sfcjaf\source\repos\RPSfile.txt";

                    // Streamwriter kirjottaa syötteen konsolista tekstitiedostoon, mutta nyt se päällekirjoittaa
                    //Peli ei myöskään käänny koska konsolissa on kirjaimia eikä numeroita
                    using (StreamWriter writer = new StreamWriter(filePath)) //kirjoittajaolio
                    {
                        writer.WriteLine(userInput);
                    }

                    Console.WriteLine("Text saved to " + filePath);

             
                    //if loop joka tarkistaa onko syotteessä kolmonen ja jos on puhdistaa konsolin sisällön ja poistuu
                    if (userchoice == 3)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    //luodaan tyhjä lista valinnoille mutta tietokone ei tee vielä listalla mitään
                    var itemsofgame = new List<string>()
                    {      
                    };

                    //Koneella tiedosto jossa sisältönä valinnat. Koska tosielämässä tehdäään KPS-liike ennen lopputulosta
                    //luodaan string tiedostoriville jotta voidaan tallentaa siihen ja try-loop joka lukee tiedoston sisältöä riviriviltä ja lisää sen yllä olevaan listaan
                    //
                    String line;
                    try
                    {
                        //hakee tiedoston
                        StreamReader readingfile = new StreamReader(@"C:\Users\JuttaVirta_0sfcjaf\source\repos\RPSfile.txt");
                        
                        //Lukee tiedoston ensimmäisen rivin
                        line = readingfile.ReadLine();
                        //Lisää sisällön aiempaan tyhjään listaan
                        itemsofgame.Add(line);

                        //Jatkaa tiedoston lukemista kunnes rivi null eli tyhjä
                        while (line != null)
                        {
                            //Lukee toisesta rivistä elkaen ja lisää tyhjään listaan
                            line = readingfile.ReadLine();
                            itemsofgame.Add(line);
                        }
                        //Sulkee tiedoston
                        readingfile.Close();
                        Console.ReadLine();
                    }
                    catch(Exception e)
                    {
                    Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                   // Console.WriteLine("Tekstitiedoston lukeminen ja siitä sisällön lisääminen listaan päättyy");
                    }
                    //Odottaa ja tulostaa tyhjän rivin
                    int waitingtime = 500;
                    Console.WriteLine("\n");


                    for (int i= 0; i<3; i++)
                    {
                        PrintandWait(itemsofgame[i], waitingtime);
                    }

                    //tietokone valitsee numeron 0-2 väliltä
                    Random rnd = new Random();
                    int computerchoice = rnd.Next(0, 3);


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
            } //while päättyy
        } //main päättyy


        static void PrintandWait(string gameitems, int waiting)
        {
            Console.WriteLine(gameitems);
            Thread.Sleep(waiting);
            Console.WriteLine("\n");
        }

    }
}
