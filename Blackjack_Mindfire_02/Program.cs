using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blackjack_Mindfire_02.UI.GUI;
using Blackjack_Mindfire_02.UI.CLI;

namespace Blackjack_Mindfire_02
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //****************************
            //  CLI or GUI.  Your choice.
            //  Comment out whichever one you don't want to see
            //****************************

            //  Graphical User Interface
            GUIForm guiGame = new GUIForm();
            guiGame.Start();

            //  Command Line Interface
            //CLIInterface cliGame = new CLIInterface();
            //cliGame.StartGame();

            Console.WriteLine("Hello, Mindfire!");
        }
    }
}
