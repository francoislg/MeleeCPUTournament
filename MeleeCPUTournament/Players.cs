using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeCPUTournament {
    public class Players {
        private Dictionary<PlayerID, Player> playersMapping;
        public List<Player> players {
            get {
                return new List<Player>(playersMapping.Values);
            }
        }
        public Players() {
            playersMapping = new Dictionary<PlayerID, Player>();
        }

        public Players(List<Player> initialPlayers) {
            playersMapping = new Dictionary<PlayerID, Player>();
            initialPlayers.ForEach(player => Add(player));
        }

        public void Add(Player player) {
            playersMapping.Add(player.ID, player);
        }

        public Player Get(PlayerID ID) {
            return playersMapping[ID];
        }
    }
}
