using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGG
{
    class IO
    {
        public static string Input(string str="")
        {
            Console.Write(str);
            return Console.ReadLine();
        }


        public static void Print(string str = "")
        {
            Console.WriteLine(str);
        }

        public static void Print(float num)
        {
            Console.WriteLine(num);
        }

        public static void Print(int num)
        {
            Console.WriteLine(num);
        }

        public static void Print(double num)
        {
            Console.WriteLine(num);
        }

        public static void Print(char ch)
        {
            Console.WriteLine(ch);
        }

        public static void Print(bool val)
        {
            Console.WriteLine(val);
        }

        public static void Beep(int freq, int duration)
        {
            Console.Beep(freq, duration);
        }
    }

    public class JsonFile
    {
        public string? Player { get; set; }
        public int Point { get; set; }
        public int HighScore { get; set; }
        public int Level { get; set; }
    }

    class Storage : IO
    {
        string _Path;
        public Storage(string path) //Constructor
        {
            //Create a new json file to store score details

            _Path = path;
            if(File.Exists(path)==false)
            {
                var file = File.Create(path);
                file.Close();
                JsonFile json = new() 
                {
                    Player = "Default Player",
                    HighScore = 0
                };
                string jsonString = JsonSerializer.Serialize(json);
                File.WriteAllText(path, jsonString);
            }
        }

        public string Write(JsonFile _json)
            //write json file to desired path
        {
            string json = JsonSerializer.Serialize(_json);
            File.WriteAllText(_Path, json);
            return json;
        }

        public string[] Read(string path)
        {
            //Read json file from path

            var json = File.ReadAllText(path);
            JsonFile? jsonFile = JsonSerializer.Deserialize<JsonFile>(json);

            string Player = jsonFile.Player;
            string Point = Convert.ToString(jsonFile.Point);
            string HighScore = Convert.ToString(jsonFile.HighScore);
            string Level = Convert.ToString(jsonFile.Level);
            return new[] { Player, Point, HighScore, Level };
        }

    }
}
