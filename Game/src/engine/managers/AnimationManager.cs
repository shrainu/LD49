using System;
using System.Collections.Generic;


namespace Game
{

    public class AnimationManager // Postjam todo :: make instantiable
    {

        // Properties
        private static List<Animation> queue = new List<Animation>();

        private static AnimationManager _instance;

        // Singleton
        public static AnimationManager Instance() {
            if( _instance==null ) {
                _instance = new AnimationManager();
            }
            return _instance;
        }

        public void AddAnimation(Animation add) => queue.Add(add);
        public void Animate() {

            for (int i = queue.Count-1; i == 0; i--)
            {
               if (queue[i].Done) queue.RemoveAt(i);
               Console.WriteLine(queue.Count.ToString());
            };
        }

    }
}