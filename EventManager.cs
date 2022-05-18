using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGG
{

    static class Event
    {
        public static int min, max, chances, bonus=1;
        public static bool gameState = false;
        public static string guidance;

        public static void Easy()
        {
            min = 0;
            max = 10;
            chances = 5;
            guidance = "clear";
        }

        public static void Moderate()
        {
            min = 0;
            max = 100;
            chances = 15;
            guidance = "normal";
        }

        public static void Hard()
        {
            min = 0;
            max = 100;
            chances = 10;
            guidance = "hard";
            bonus = 2;
        }

        public static void Asian()
        {
            min = -1234;
            max = 1234;
            chances = 10;
            guidance = "Asian";
            bonus = 3;
        }

        public static string GClear(int guess, int num)
        {
            int difference = guess - num;

            if (difference < 0) difference *= -1;

            if (difference == 0)
            {
                gameState = true;
                return "Gocha!!";
            }
            return $"{difference} numbers away";
        }

        public static string GNormal(int guess, int num)
        {
            int difference = guess - num;

            if (difference <= 10 & difference > 0) return "High";
            else if (difference >= -10 & difference < 0) return "Low";
            else if (difference > 10) return "Too High";
            else if (difference < -10) return "Too Low";
            gameState = true;
            return "\n\aGocha!";
        }

        public static string GHard(int guess, int num)
        {
            if (num < guess) return "high";
            else if (num > guess) return "Low";
            gameState = true;
            return "\n\aGocha";
        }

        public static string GAsian(int guess, int num)
        {
            return "Asian!, Work in progress";
        }

        public static void StartGame(int guess, int number, int level)
        {
            if (level == 1) IO.Print(GClear(guess, number));
            else if (level == 2) IO.Print(GNormal(guess, number));
            else if (level == 3) IO.Print(GHard(guess, number));
            else if (level == 4) IO.Print(GAsian(guess, number));
            else IO.Print(GNormal(guess, number));
        }

        public static int Points(int availableChance, int level)
        {
            return availableChance * level * bonus;
        }

        public static void WritePoints(int points)
        {
            
        }

    }
}

