using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeleeCPUTournament {
    using MeleeAutomator;
    using MeleeAutomator.Characters;
    using MeleeAutomator.Menus.VSMode.Melee;
    using DolphinControllerAutomator;
    using DolphinControllerAutomator.Controllers;
    public partial class MeleeCPUTournament : Form {
        MeleeMenu meleeMenu;
        DolphinAsyncController[] controllers;
        MeleePlayer[] players;
        CharactersManager charactersManager;
        
        public MeleeCPUTournament() {
            InitializeComponent();
            controllers = new DolphinAsyncController[] {
                new DolphinAsyncController(new vJoyController(1)),
                new DolphinAsyncController(new vJoyController(2))
            };
            charactersManager = new CharactersManager();
            players = new MeleePlayer[] {
                new MeleePlayer(charactersManager.getRandomCharacter(), "1"),
                new MeleePlayer(charactersManager.getRandomCharacter(), "2")
            };
            meleeMenu = new MeleeBoot(controllers).bootToCSSCode();
        }

        private async void button1_Click(object sender, EventArgs e) {
            FinishedDuelMatch duel = await meleeMenu
                .setPlayerOnPort(players[0], 1)
                .setPlayerOnPort(players[1], 2)
                .setRandomStage()
                .confirm();
            Console.WriteLine("Winner is " + duel.winner);
        }
    }
}
