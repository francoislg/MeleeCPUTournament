using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeCPUTournament {
    using MeleeAutomator;
    using MeleeAutomator.Characters;
    using MeleeAutomator.Menus.VSMode.Melee;

    public class Player {
        public PlayerID ID { get; private set; }
        public MeleePlayer meleePlayer { get; private set; }
        public string name {
            get {
                return meleePlayer.name;
            }
        }
        public Player(PlayerID ID, Character character, string name) {
            this.ID = ID;
            this.meleePlayer = new MeleePlayer(character, name);
        }
    }
}
