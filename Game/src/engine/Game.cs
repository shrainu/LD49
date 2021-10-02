using Raylib_cs;

namespace Game {

    public class Game {

        //Properties


        public Game() {

        }


        public void Init(){

            // Initialize the window
            Raylib.InitWindow(800, 480, "Ludum Dare #49");
        }
        public void Run() {

            while(!Raylib.WindowShouldClose()) {

                Events();
                Update();
                Render();
            }

            // Terminate the raylib when the user closes the game
            Raylib.CloseWindow();
        }


        public void Events() {

        }
        public void Update() {

        }
        public void Render() {

            // Start the render process
            Raylib.BeginDrawing();
            // Game's default Clear call - This will be overritten by the Scenes
            Raylib.ClearBackground(Color.WHITE);

            // TODO: Add Scene Manager's render loop here
            Raylib.DrawText("Its working!", 12, 12, 20, Color.BLACK);
            
            // Finish the render process
            Raylib.EndDrawing();
        }
    }
}