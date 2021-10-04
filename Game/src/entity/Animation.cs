using Raylib_cs;
using System.Collections.Generic;

namespace Game
{

    public class Animation : List<Keyframe>
    {

        public Animation(IEnumerable<Keyframe> frames, Unit host) { this.AddRange(frames); body = host; }
        private int frame;
        private Unit body;

        public bool Done => Play();
        private bool Play()
        {
            if (this[frame].Performed(body))
            {
                frame++;
                if (frame == Count) return true;
            }
            return false;
        }
    }
}