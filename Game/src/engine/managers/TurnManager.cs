using System.Collections.Generic;

namespace Game {

    public class TurnManager {

        // References
        private Tilemap tilemap;
        private EntityManager entityManager;


        public TurnManager(Tilemap tilemap, EntityManager entityManager) {

            // Set references
            this.tilemap = tilemap;
            this.entityManager = entityManager;
        }


        public void EndTurn(){ 

            tilemap.ActTileTurns();
            entityManager.ActEntityTurns();
        }
    }
}