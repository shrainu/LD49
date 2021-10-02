using Raylib_cs;

namespace Game
{
    static class Program
    {
        public static void Main()
        {
            Game g = new Game();

            g.Init();
            g.Run();
        }
    }
}