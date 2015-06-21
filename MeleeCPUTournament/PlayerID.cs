using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeCPUTournament {
    public class PlayerID {
        public string ID { get; private set; }
        public PlayerID(string ID) {
            this.ID = ID;
        }

        public override int GetHashCode() {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj) {
            PlayerID id = obj as PlayerID;
            if (id == null) {
                return false;
            } else {
                return id.ID.Equals(this.ID);
            }
        }
    }
}
