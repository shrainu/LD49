using Raylib_cs;
using System.Collections.Generic;

namespace Game
{

    public class Animation : List<Keyframe>
    {

        //Constructor
        public Animation(IEnumerable<Keyframe> frames, Unit host) { this.AddRange(frames); body = host; }
        private int frame;          // The current keyframe
        private Unit body;          // The animation target

        public bool Done => Play(); // Simple redirect so you could write "if(animation.Done)"
        private bool Play()
        {
            if (this[frame].Performed(body)){
                                             // When the current keyframe returns True (done)
                frame++;                     // Move on to the next one
                if (frame == Count) return true;
                //When all keyframes done, return True to the AnimationManager to get removed
            }                                
            return false;
        }
    }
}