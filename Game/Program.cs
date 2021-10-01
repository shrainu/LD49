using Raylib_cs;

namespace Game
{
    static class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(800, 480, "Ludum Dare #49");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Its working!", 12, 12, 20, Color.BLACK);
                Raylib.DrawRect()

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}