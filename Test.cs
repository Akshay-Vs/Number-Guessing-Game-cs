using System;
using System.IO;
namespace NGG
{
    class Test
    {


        public static void Mains(string[] args) //Test
        {
            string path = $"{Environment.CurrentDirectory}\\file.json";
            IO.Print(path);

            Storage emulator = new Storage(path);

            var data = new JsonFile
            {
                Player = "player1",
                Point = 100,
                HighScore = 150,
                Level = 3
            };

            emulator.Write(data);
            string[] newdata = emulator.Read(path);
            Console.WriteLine(newdata[1]);

            Storage str = new(Environment.CurrentDirectory + "\\f.json");
            JsonFile file = new()
            {
                Point = 10
            };
            str.Write(file);
            

        }
    }
}
