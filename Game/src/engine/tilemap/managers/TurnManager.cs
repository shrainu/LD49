using System.Collections.Generic;

namespace Game {

    public class TurnManager {

        // Properties
        public List<Entity> entitiesInCombat;
        public bool Combat { get; private set; }

        // References
        private Tilemap tilemap;


        public TurnManager(Tilemap tilemap) {
            entitiesInCombat = new List<Entity>();
            Combat = false;
        }


        public void AddToCombat(Entity e) {
            entitiesInCombat.Add(e);
        }
        public void RemoveFromCombat(Entity e) {
            entitiesInCombat.Remove(e);
        }


        public void EndTurn(){ 

            tilemap.ActTileTurns();
            if (Combat) ActEntityTurns();
        }

        private void ActEntityTurns() {

            // Act entities turns
            for (int i = 0; i < entitiesInCombat.Count; i++) {
                entitiesInCombat[i].ActTurn();
            }
        }
    }
}