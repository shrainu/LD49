using System.Collections.Generic;
using Raylib_cs;


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

        // Texture
        public Texture2D sprite;
        
        // Perks
        protected List<Perk> perks = new();
        public Perk this[int i]
        {
            get { return perks[i]; }
            set { perks[i] = value; }
        }

        public Entity(Transform transform, EntityTag tag, string name = "Entity") {
            this.name = name;
            this.transform = transform;
            this.Tag = tag;
            active = true;
            render = true;
        }

        public abstract void Events();
        public abstract void Update();
        public abstract void Render();

        public virtual void ActTurn() {}

        public virtual void SetSprite(string imagePath) {

            // Load Image to the RAM
            Image temp = Raylib.LoadImage(imagePath);
            // Create a texture from Image data which is loaded to VRAM
            sprite = Raylib.LoadTextureFromImage(temp);
            // Unload the image from RAM
            Raylib.UnloadImage(temp);
        }
    }
}