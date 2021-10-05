using System.Collections.Generic;


namespace Game {

    public class SceneManager {

        // Properties
        private List<Scene> scenes;
        public int CurrentScene { get; private set; }

        /*
        * -----------------------------------------------------------------------##
        * New scenes have to be added in acording to their sceneId
        * because scene manager only updates the CurrentScene and its an integer,
        * so if you don't add the lists acording to their sceneID you migth update
        * and render a wrong scene.
        * 
        * The reason I did this in this way is because I don't wanted to waste 
        * performance and loop through all the scenes every frame.
        -----------------------------------------------------------------------##
        */


        public SceneManager() {
            scenes = new List<Scene>(5);
            CurrentScene = (int)SceneID.MAIN;
        }


        public void Events() {

            scenes[CurrentScene].Events();
        }
        public void Update() {

            scenes[CurrentScene].Update();
        }
        public void Render() {

            scenes[CurrentScene].Render();
        }


        public void ChangeScene(Scene scene) {

            CurrentScene = (int)scene.sceneID;
        }
        public void ChangeScene(SceneID sceneId) {

            CurrentScene = (int)sceneId;
        }
        public void AddScene(Scene scene) {

            bool exists = false;

            for (int i = 0; i < scenes.Count; i++)
                if (scene == scenes[i]) exists = true;
            
            if (exists) return;
            scenes.Add(scene);
        }
    }
}