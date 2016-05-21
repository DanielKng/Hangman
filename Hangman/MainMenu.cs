using System;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Drawing;
using System.Security.Permissions;

namespace Hangman
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Game showGame = new Game();
            //This is the Start-Form. Therefore we cant close it!
            Hide();
            //Show Hangman
            showGame.Show();
        }

        public void options_Click(object sender, EventArgs e)
        {
            CheckFiles();
            //Load our Classes
            Options loadOptions = new Options();
            //If we have have 4 files, we dont need to Open the Download Window
            if (Properties.Settings.Default.files_exist != "1")
            {
                //Show the Options
                loadOptions.StartPosition = FormStartPosition.CenterScreen;
                loadOptions.ShowDialog();
            }
            else
            {
                //Show Options
                loadOptions.ShowDialog();
            }
        }

        public void CheckFiles()
        {
            //First Create the Directory. It will NOT be created if its there already!
            Directory.CreateDirectory(@"C:\Hangman\Wordlists");
            //Check the Directory for files
            string[] dFiles = Directory.GetFiles(@"C:\Hangman\Wordlists");
            //Convert the Content into a String
            Properties.Settings.Default.files_exist = dFiles.Length.ToString();
        }

        //If clicked on Exit, Shutdown the Application
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
