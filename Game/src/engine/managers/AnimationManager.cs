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
        public static AnimationManager Instance() {     // MINDFUCK CODE DO NOT READ
            if( _instance==null ) {                     // MINDFUCK CODE DO NOT READ
                _instance = new AnimationManager();     // MINDFUCK CODE DO NOT READ
            }                                           // MINDFUCK CODE DO NOT READ
            return _instance;                           // MINDFUCK CODE DO NOT READ
        }                                               // MINDFUCK CODE DO NOT READ
                                                        // MINDFUCK CODE DO NOT READ
            public void AddAnimation(Animation add) => queue.Add(add);// DO NOT READ
        public void Animate() {                         // MINDFUCK CODE DO NOT READ
                                                        // MINDFUCK CODE DO NOT READ
            for (int i = queue.Count-1; i == 0; i--)    // MINDFUCK CODE DO NOT READ
            {                                           // MINDFUCK CODE DO NOT READ
               if (queue[i].Done) queue.RemoveAt(i);    // MINDFUCK CODE DO NOT READ
               Console.WriteLine(queue.Count.ToString());// INDFUCK CODE DO NOT READ
            };
        }

    }
}