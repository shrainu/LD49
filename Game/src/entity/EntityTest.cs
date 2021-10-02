using Raylib_cs;


namespace Game {

    public class EntityTest : Entity {

        // Properties
        Color color;
        Shader shader;
        float purple = 0.2f;
        float increase = 0.05f;

        public EntityTest(Transform transform, Color color) : base(transform, EntityTag.PLAYER, "Test") {

            this.color = color;
            shader = Raylib.LoadShader("glsl/color_change/vertex_shader.glsl", "glsl/color_change/fragment_shader.glsl");
        }

        
        public override void Events() { 

        }
        public override void Update() {

        }
        public override void Render() {

            int uniformLoc = Raylib.GetShaderLocation(shader, "u_Color");

            if (purple >= 1.0f) increase = -0.0005f;
            else if (purple <= 0.0f)  increase = +0.0005f;
            purple += increase;

            float[] color = new float[4] { purple, 0.1f, 1.0f, 1.0f };

            Utils.SetShaderValue(shader, uniformLoc, color, ShaderUniformDataType.SHADER_UNIFORM_VEC4);

            Raylib.BeginShaderMode(shader);
            Raylib.DrawTexture(sprite, (int)transform.position.x, (int)transform.position.y, Color.WHITE);
            Raylib.EndShaderMode();
        }
    }
}