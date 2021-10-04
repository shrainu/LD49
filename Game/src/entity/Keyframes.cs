using Raylib_cs;
using System;
using System.Threading.Tasks;


namespace Game {

 public abstract class Keyframe
    {
        public bool Performed(Unit on) { return PerformAction(on); }
        public float time, timer;

        public abstract bool PerformAction(Unit body);
    }
    
public enum Easing // Move from
{
    None,
    Linear
}
    public class Move : Keyframe
    {
        private Vector2 from, to;
        private Easing tween;
        Easing GetTween => tween;
        public Move(float t, Vector2 a, Vector2 b)
        {
            (from, to, timer) = (a, b, t);
            tween = Easing.None;
        }

        public override bool PerformAction(Unit body)
        {
            time += Utils.deltaTime;
            (body.transform.position.x, body.transform.position.y) = GetTween switch
            {
                Easing.None => (Easings.EaseLinearNone(time/timer, from.x, to.x, 1), Easings.EaseLinearNone(time/timer, from.y, to.y, 1))  
            };
            return time >= timer ?  true : false;
        }
    }
}