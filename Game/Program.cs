using Raylib_cs;
using System;
using System.IO;

namespace Game
{
    static class Program
    {
        public static void Main()
        {
            Game g = new Game();

            g.Init();
            g.Run();

            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
        }
    }
}