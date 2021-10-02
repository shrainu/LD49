using Raylib_cs;


namespace Game {

    public class RGBShader {

        // Singleton
        private static RGBShader i = null;
        
        public static RGBShader Instance {
            get {
                if (i == null) {
                    i = new RGBShader();
                }
                return i;
            }
        }

        // Properties
        private Shader shader;
    
        public RGBShader() {

            shader = Raylib.LoadShader("glsl/color_change/vertex_shader.glsl", "glsl/color_change/fragment_shader.glsl");
        }

        public void Bind() { Raylib.BeginShaderMode(shader); }
        public void Unbind() { Raylib.EndShaderMode(); }


        public void SetColorR(Color color) {

            int uniformLoc = Raylib.GetShaderLocation(shader, "u_ColorR");

            SendUniformColorData(uniformLoc, color);
        }
        public void SetColorG(Color color) {

            int uniformLoc = Raylib.GetShaderLocation(shader, "u_ColorG");

            SendUniformColorData(uniformLoc, color);
        }


        private void SendUniformColorData(int uniformLoc, Color color) {

            float[] colorBuffer = new float[4] { color.r / 255.0f, color.g / 255.0f, color.b / 255.0f, color.a / 255.0f };

            Utils.SetShaderValue(shader, uniformLoc, colorBuffer, ShaderUniformDataType.SHADER_UNIFORM_VEC4);
        }
    }
}