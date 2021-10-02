using Raylib_cs;


namespace Game {

    public class EntityTest : Entity {

        // Properties
        Color color;

        public EntityTest(Transform transform, Color color) : base(transform, EntityTag.PLAYER, "Test") {

            this.color = color;
        }

        
        public override void Events() { 

        }
        public override void Update() {

        }
        public override void Render() {

            Raylib.DrawTexture(sprite, (int)transform.position.x, (int)transform.position.y, Color.WHITE);
        }
    }
}