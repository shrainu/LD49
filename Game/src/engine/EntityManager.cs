using System;
using System.Collections.Generic;


namespace Game {

    public class EntityManager {

        // Properties
        private List<Entity> entities;

        public EntityManager() {
            entities = new List<Entity>();
        }


        public void Events() {
            for (int i = 0; i < entities.Count; i++) {
                entities[i].Events();
        }
            }
        public void Update() {
            for (int i = 0; i < entities.Count; i++) {
                entities[i].Update();
            }
        }
        public void Render() {
            for (int i = 0; i < entities.Count; i++) {
                entities[i].Render();
            }
        }


        public void AddEntity(Entity entity) {

            entities.Add(entity);
        }
        public void RemoveEntity(Entity entity) {

            entities.Remove(entity);
        }
    }
}