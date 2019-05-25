using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blackjack_Mindfire_02.Participants;

namespace Blackjack_Mindfire_02.UI.GUI
{
    public partial class GUIForm : Form
    {

        IUserInterface gameInterface;

        public GUIForm()
        {
            InitializeComponent();
        }
        public void ResetGUI()
        {
            dealersHandTextBox.Text = "";
            dealersScoreTextBox.Text = "";
            playersComboBox.Items.Clear();
            playersHandTextBox.Text = "";
            playersScoreTextBox.Text = "";
            participantsPointsTextBox.Text = "";
            participantsWinTextBox.Text = "";
        }
        [STAThread]
        public void Start()
        {
            Application.Run(this);
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            ResetGUI();
            int amtPlayers = 0;
            if (Int32.TryParse(amtPlayersTextBox.Text, out amtPlayers))
            {
                amtPlayersTextBox.Enabled = false;
                startGameButton.Enabled = false;
                gameInterface = new IUserInterface();
                gameInterface.InitializeInterface(amtPlayers);

                gameInterface.dealer.InitialDeal(gameInterface.players);
                dealersHandTextBox.Text = gameInterface.dealer.DisplayHand();
                dealersScoreTextBox.Text = gameInterface.dealer.Hand.HighestHand().ToString();

                foreach(Player player in gameInterface.players)
                {
                    playersComboBox.Items.Add(player);
                }
                playersComboBox.SelectedIndex = 0;
            }
        }

        private void playersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player selectedPlayer = gameInterface.players[playersComboBox.SelectedIndex];
            if(selectedPlayer.Hand.Bust != true && selectedPlayer.Hold != true)
            {
                hitButton.Enabled = true;
                holdButton.Enabled = true;
            }
            playersHandTextBox.Text = selectedPlayer.DisplayHand();
            playersScoreTextBox.Text = selectedPlayer.Hand.HighestHand().ToString();
            if (selectedPlayer.Hand.Bust || selectedPlayer.Hold)
            {
                hitButton.Enabled = false;
                holdButton.Enabled = false;
            }
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            Player selectedPlayer = gameInterface.players[playersComboBox.SelectedIndex];
            selectedPlayer.Hit(gameInterface.dealer);
            playersHandTextBox.Text = selectedPlayer.DisplayHand();
            playersScoreTextBox.Text = selectedPlayer.Hand.HighestHand().ToString();
            if(selectedPlayer.Hand.Bust == true)
            {
                hitButton.Enabled = false;
                holdButton.Enabled = false;
            }
            AllBustOrHold();
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            Player selectedPlayer = gameInterface.players[playersComboBox.SelectedIndex];
            selectedPlayer.Hold = true;
            hitButton.Enabled = false;
            holdButton.Enabled = false;
            AllBustOrHold();
        }
        // If everyone is either busted or holding, then resolve the dealers hand, find points awarded and find who won
        public void AllBustOrHold()
        {
            if (gameInterface.players.All(p => p.Hand.Bust == true || p.Hold == true))
            {
                gameInterface.dealer.ResolveDealerRound(gameInterface.players);
                dealersHandTextBox.Text = gameInterface.dealer.DisplayHand();
                dealersScoreTextBox.Text = gameInterface.dealer.Hand.HighestHand().ToString();
                gameInterface.scorer.ResolvePoints();

                participantsPointsTextBox.Text += $"Player {gameInterface.dealer.PlayerName}, got {gameInterface.dealer.Points} points.\n";

                foreach (Player player in gameInterface.players)
                {
                    participantsPointsTextBox.Text += $"Player {player.PlayerName}, got {player.Points} points.\n";
                }
                List<IParticipant> winners = gameInterface.scorer.FindWinners();
                foreach (IParticipant participant in winners)
                {
                    participantsWinTextBox.Text += $"Player {participant.PlayerName}\n";
                }
                amtPlayersTextBox.Enabled = true;
                startGameButton.Enabled = true;
                startGameButton.Text = "Restart Game?";
            }
        }
    }
}
