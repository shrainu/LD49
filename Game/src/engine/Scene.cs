using System;

namespace Game {

    public enum SceneID {

        MAIN = 0,
        GAME = 1
    }

    public abstract class Scene {

        // Properties
        public SceneID sceneID { get; private set; }

        public Scene(SceneID sceneID) { this.sceneID = sceneID; }

        public abstract void Events();
        public abstract void Update();
        public abstract void Render();
    }
}