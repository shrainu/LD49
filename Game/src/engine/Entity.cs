
namespace Game {

    public enum EntityTag {

        PLAYER,
        ENEMY,
    }

    public abstract class Entity {

        // Properties
        public EntityTag Tag { private set; get; }
        public string name;
        public Transform transform;
        public bool active, render;

        public Entity(Transform transform, EntityTag tag, string name = "Entity") {
            this.name = name;
            this.transform = transform;
            this.Tag = tag;
        }

        public abstract void Events();
        public abstract void Update();
        public abstract void Render();
    }
}