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

            RGBShader.Instance.SetColorR(color);
            RGBShader.Instance.SetColorG(new Color(0, 255, 255, 255));

            RGBShader.Instance.Bind();
            Raylib.DrawTextureEx(sprite, transform.position.ToNumerics(), 0, transform.size.x, Color.BLACK);
          //  Raylib.DrawTexture(sprite, (int)transform.position.x, (int)transform.position.y, Color.WHITE);
            RGBShader.Instance.Unbind();
        }
    }
}