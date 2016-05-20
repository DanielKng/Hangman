using System;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Drawing;
using System.Security.Permissions;

namespace hangman
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        //Load our Classes
        Options loadOptions = new Options();

        private void Start_Click(object sender, EventArgs e)
        {
            Game showGame = new Game();
            //This is the Start-Form. Therefore we cant close it!
            Hide();
            //Show Hangman
            showGame.Show();
        }

        private void options_Click(object sender, EventArgs e)
        {
            //TODO: Put into method
            //First Create the Directory. It will NOT be created if its there already!
            Directory.CreateDirectory(@"C:\Hangman\Audios");
            //Check the Directory for files
            string[] dFiles = Directory.GetFiles(@"C:\Hangman\Audios");
            //Convert the Content into a String
            string fCount = dFiles.Length.ToString();
            //If we have have 4 files, we dont need to Open the Download Window
            if (fCount != "4")
            {
                //Files needed, because we dont have 4 of them! 
                Properties.Settings.Default.files_needed = true;
                //Show the Options
                loadOptions.ShowDialog();
            }
            else
            {
                //We have all files, no further download
                Properties.Settings.Default.files_needed = false;
                //Show Options
                loadOptions.ShowDialog();
            }
        }

        //If clicked on Exit, Shutdown the Application
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
