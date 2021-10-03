using Raylib_cs;
using System.Collections.Generic;


namespace Game {

    public abstract class Keyframe
    {
        public bool Performed(Entity on) { PerformAction(on); return true;}

        public abstract void PerformAction(Entity body);
    }

    public class Animation : List<Keyframe> {

        public Animation(IEnumerable<Keyframe> frames) => this.AddRange(frames);
//Entirely synced as it's intended for the combat
        public bool Play(ref Entity body)
        {
            foreach(Keyframe key in this)
            {
            if(key.Performed(body)) continue;
            }
            return true;
        }
    }
}