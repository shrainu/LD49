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
        public Texture2D spriteBack, spriteFront;
        
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

        public virtual void SetSprite(string imagePathBack, string imagePathFront) {

            // Load Image to the RAM
            Image tempBack = Raylib.LoadImage(imagePathBack);
            Image tempFront = Raylib.LoadImage(imagePathFront);
            // Create a texture from Image data which is loaded to VRAM
            spriteBack = Raylib.LoadTextureFromImage(tempBack);
            spriteFront = Raylib.LoadTextureFromImage(tempFront);
            // Unload the image from RAM
            Raylib.UnloadImage(tempBack);
            Raylib.UnloadImage(tempFront);
        }
    }
}