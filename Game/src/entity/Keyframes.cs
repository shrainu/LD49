using Raylib_cs;


namespace Game {

public enum Easing // Move from
{
    None,
    Linear
}
    public class Move : Keyframe
    {
        private Vector2 _from, _to;
        private Easing _tween;
        Easing GetTween => _tween;

        public Move(float time, Vector2 from, Vector2 to)
        {

        }

        public override void PerformAction(Entity body)
        {
            body.transform.position = GetTween switch
            {
               // Easing.None => Easings.EaseLinearNone()
            }
        }
    }
}