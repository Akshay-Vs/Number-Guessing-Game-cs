using System;
using System.Threading;

namespace NGG
{
    class Program : IO
    {

        static int number;
        static int guess;
        public static int i, level = 2;

        static void Main(string[] args)
        {

            Console.Title = "Number Guessing Game";
            Console.ForegroundColor = ConsoleColor.DarkGray;


            Random random = new Random();

            while (true) //Main loop
            {
                try
                {
                    Console.Clear();
                    Print("____Welcome to Number Guessing Game____\n\nEnter Input\n");
                    Print("1: start Game");
                    Print("2: Help");
                    Print("3: Levels");
                    Print("4: HighScore");
                    Print("0: Exit Console");
                    guess = Int32.Parse(Input(">>> "));
                    Console.Clear();

                    if (guess == 1)
                    {
                        switch (level) //Initializing levels
                        {
                            case 1:
                                Event.Easy();
                                break;
                            case 2:
                                Event.Moderate();
                                break;
                            case 3:
                                Event.Hard();
                                break;
                            case 4:
                                Event.Asian();
                                break;
                            default:
                                Event.Easy();
                                break;
                        }

                        number = random.Next(Event.min, Event.max);
                        Print("Level: " + level);
                        Print("Min: " + Event.min);
                        Print("Max: " + Event.max);
                        Print("Num: " + number);

                        for (i = Event.chances; i >= 1; i--) //Game loop
                        {
                            try
                            {
                                guess = Int32.Parse(Input("Enter your guess: "));
                                Event.StartGame(guess, number, level);

                                if (Event.gameState == true)
                                {
                                    Event.gameState = false;
                                    Print($"\nFailed Trials: {Event.chances - i}");
                                    Print($"Bonus Multipliyer: {Event.bonus}");
                                    Print($"You Got {Event.Points(i, level)} Points!");
                                    Event.WritePoints("Player1", Event.Points(i, level), level);
                                    Input(">>>");
                                    break;
                                }

                            }
                            catch (FormatException)
                            {
                                Print("Invalid Input");
                                i++; // incrementing i to Ignore this invalid iteration

                                // Creating a new thread to play sound without lagging console
                                Thread threadSound = new Thread(() => Beep(1000, 500));
                                threadSound.Start();
                            }

                        }

                        if (i == 0)
                        {
                            Print("\nYou Lost!!!\nTry again\a");
                            Input(">>>");
                        }

                    }

                    else if (guess == 2) //Execute Help
                    {
                        Print("The user is supposed to guess a number between 0 and 10 in a maximum of 5 attempts");
                        Print("Console will indicate how close your guess is\n\nIf your guess is lower than the number, The console returns 'Too Low'" +
                            "\nIf your guess is higher than the number, The console will return 'Too High'\nConsole return 'Gocha!;\' when you got the right answer" +
                            "\n\t\t\t\t\tGood Luck, -Akshay Vs");
                        Input(">>> ");
                    }

                    else if (guess == 3) //Event
                    {
                        Print("____Select Your Level____\n");
                        Print("1: Easy\n2: Moderate \n3: Hard\n4: Asian \n");
                        Print($"Current Level: {level}");

                        level = Int32.Parse(Input(">>> "));
                    }

                    else if (guess == 4)
                    {
                        string[] data = Event.ReadPoints();
                        Print($"High Score: {data[2]}\nPlayer: {data[3]}");
                        Input(">>> ");
                    }

                    else if (guess == 0)
                    {
                        Print("Thanks for playing...");
                        Thread.Sleep(830);
                        Environment.Exit(0);
                    }

                    else throw new FormatException("Invalid Input");    // This cause the FormateException catch to execute

                }

                catch (FormatException)
                {
                    Thread threadSound = new Thread(() => Beep(1000, 500));
                    threadSound.Start();
                    Print("Invalid Input");
                    Thread.Sleep(830);
                }

                catch (Exception)
                {
                    Thread threadSound = new Thread(() => Beep(1000, 500));
                    threadSound.Start();
                    Print("Something went wrong");
                    Thread.Sleep(830);
                }
            }
        }
    }
}
