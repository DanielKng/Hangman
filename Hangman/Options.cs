using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Options : Form
    {
        //Declaration of the Download Content and the Path's
        private string remoteGermanList = "https://www.dropbox.com/s/540txkvc94zl3p5/german_words.txt?dl=1";

        private string germanWordlistPath = @"C:/Hangman/Wordlists/german_wordlist.txt";

        public Options()
        {
            //If we need files, download em
            if (Properties.Settings.Default.files_exist != "1")
            {
                FilesMessageBox();
            }
            else if (Properties.Settings.Default.files_exist == "1")
            {
                //We have all files, hide the Content
            }
            InitializeComponent();
        }

        public async Task DownloadFiles()
        {
            //Download all
            WebClient webClient = new WebClient();
            // download_info.Text = "File 1/4 loading...\r\n\r\n" + remoteGermanList;
            await webClient.DownloadFileTaskAsync(new Uri(remoteGermanList), germanWordlistPath);
            // if here, you know the first download is finished
        }

        public void FilesMessageBox()
        {
            if (Properties.Settings.Default.files_exist != "1")
            {
                if (MessageBox.Show("Attention! In order to use the Audio features, a one time download is needed! Proceed?", "Files missing!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Just to be sure, delete all previous files!
                    Array.ForEach(Directory.GetFiles(@"C:/Hangman/Wordlists/"), File.Delete);
                    DownloadFiles();
                }
            }
        }
    }
}