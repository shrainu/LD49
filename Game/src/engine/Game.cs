using Raylib_cs;

namespace Game {

    public class Game {

        //Properties
        public static readonly string gameTitle  = "Ludum Dare #49";
        public static readonly int displayWidth  = 1200;
        public static readonly int displayHeight = 720;

        // Scene Manager
        SceneManager sceneManager;

        // Constructor / Destructor
        public Game() {}
        ~Game() {}


        public void Init(){

            // Initialize the window
            Raylib.InitWindow(displayWidth, displayHeight, gameTitle);
            
            // Initialize Scene Manager
            sceneManager = new SceneManager();

            // Create and a new Scene
            sceneManager.AddScene(new SceneMainMenu());
            sceneManager.AddScene(new SceneDungeon());

            // Set current scene to be the Game scene
            sceneManager.ChangeScene(SceneID.GAME);
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

            // Call the event loop of the Current Scene
            sceneManager.Events();
        }
        public void Update() {

            // Update the Current Scene
            sceneManager.Update();
        }
        public void Render() {

            // Start the render process
            Raylib.BeginDrawing();
            // Game's default Clear call - This will be overritten by the Scenes
            Raylib.ClearBackground(Color.WHITE);

            // Render the Current Scene
            sceneManager.Render();

            // Draw the Fps
            Raylib.DrawFPS(0, 0);
            // Finish the render process
            Raylib.EndDrawing();
        }
    }
}