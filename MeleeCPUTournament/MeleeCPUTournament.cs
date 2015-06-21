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
    using MeleeAutomator.Menus.VSMode.Melee;
    using MeleeAutomator.Characters;
    using DolphinControllerAutomator;
    using DolphinControllerAutomator.Controllers;
    using ChallongeCSharpDriver;
    using ChallongeCSharpDriver.Caller;
    using ChallongeCSharpDriver.Main;
    using System.IO;

    public partial class MeleeCPUTournament : Form {
        private MeleeMenu meleeMenu;
        private DolphinAsyncController[] controllers;
        private CharactersManager charactersManager;
        private Players players;
        private ChallongeHTTPClientAPICaller caller;
        
        public MeleeCPUTournament() {
            string configPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/challongeCSharpDriver.config";
            var data = readIni(configPath);
            ChallongeConfig config = new ChallongeConfig(data["api_key"]);
            caller = new ChallongeHTTPClientAPICaller(config);

            controllers = new DolphinAsyncController[] {
                new DolphinAsyncController(new vJoyController(1)),
                new DolphinAsyncController(new vJoyController(2))
            };
            
            charactersManager = new CharactersManager();
            players = new Players(new List<Player>() {
                new Player(new PlayerID("Mario"), charactersManager.getCharacter("Mario"), "Mario"),
                new Player(new PlayerID("Luigi"), charactersManager.getCharacter("Luigi"), "Luigi")
            });
            meleeMenu = new MeleeBoot(controllers).bootToCSSCode();

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            int tournamentUID = 1;
            PendingTournament pendingTournament = await new TournamentCreator(caller).create("Tournament" + tournamentUID, TournamentType.Double_Elimination, "SSBMCPUTOURNAMENT" + tournamentUID);
            foreach(Player player in players.players){
                await pendingTournament.AddParticipant(player.name);
            };
            StartedTournament tournament = await pendingTournament.StartTournament();
            await nextMatch(tournament);
        }

        private async Task<ClosedMatch> nextMatch(StartedTournament tournament) {
            OpenMatch currentMatch = await tournament.getNextMatch();
            string player1Name = (await currentMatch.player1).name;
            string player2Name = (await currentMatch.player2).name;

            FinishedDuelMatch duel = await meleeMenu
                .setPlayerOnPort(players.Get(new PlayerID(player1Name)).meleePlayer, 1)
                .setPlayerOnPort(players.Get(new PlayerID(player2Name)).meleePlayer, 2)
                .setRandomStage()
                .confirm();

            if (duel.winner.name == player1Name) {
                currentMatch.addScore(new Score(1, 0));
            } else {
                currentMatch.addScore(new Score(0, 1));
            }
            return await currentMatch.close();
        }

        private Dictionary<string, string> readIni(string file) {
            Dictionary<string, string> ini = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines(file))
                ini.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            return ini;
        }

        private async void MeleeCPUTournament_Load(object sender, EventArgs e) {
            try {
                List<StartedTournament> tournaments = await new Tournaments(caller).getStartedTournaments();
                startedTournamentsListBox.DataSource = tournaments;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        private async void startedTournamentsListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            StartedTournament tournament = startedTournamentsListBox.SelectedItem as StartedTournament;
            await nextMatch(tournament);
        }
    }
}
