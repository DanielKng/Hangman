using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class Options : Form
    {
        public Options()
        {
            //If we need files, download em
            if (Properties.Settings.Default.files_needed == true)
            {
                CheckForFiles();
            }

            InitializeComponent();
        }
        bool download_no;
        public void CheckForFiles()
        {
            if (Properties.Settings.Default.files_needed)
            {
                if (MessageBox.Show("Attention! In order to use the Audio features, a one time download is needed! Proceed?", "Files missing!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //We clicked yes, change the Variable
                    download_no = false;
                    //Just to be sure, delete all previous files!
                    Array.ForEach(Directory.GetFiles(@"C:/Hangman/Audios/"), File.Delete);
                    //Set the Warning Text
                }
                else if (download_no)
                {
                    //If the Button says "Apply!" the user has not downloaded our Content, but tried to Activate it!
                    apply_options.Text = "Apply!";
                }
            }
        }
    }
}
