using Raylib_cs;
using System;
using System.Threading.Tasks;


namespace Game {

    public abstract class Keyframe
    {
        //Requested by the Animator to check whether the keyframe is complete
        public bool Performed(Unit on) { return PerformAction(on); }
        
        //Inner variables
        public float time, timer;

        public abstract bool PerformAction(Unit body);
    }
    
    public enum Easing // Move from
    {
        None,   // ?
        Linear, // ?
        Cubic   // ?
    }

    public class Move : Keyframe // Basic movement
    {
        private Vector2 from, to; 
        private Easing tween;
        Easing GetTween => tween;
        public Move(float t, Vector2 a, Vector2 b) // Constructor
        {
            (from, to, timer) = (a, b, t); 
            tween = Easing.None;
        }

        public override bool PerformAction(Unit body) // Process a frame of animation
        {
            time += Utils.deltaTime; // A single timer tick
            (body.transform.position.x, body.transform.position.y) = GetTween switch
            {
                Easing.None =>
                (Easings.EaseLinearNone(time/timer, from.x, to.x, 1), // X axis lerp
                 Easings.EaseLinearNone(time/timer, from.y, to.y, 1)) // Y axis lerp
            };
            return time >= timer ?  true : false; // If time capped, signal Animator that the keyframe is done
        }
    }
}