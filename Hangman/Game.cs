using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        //Load the Words from a .txt file. If you selected German, download the German, etc
        //Randomize
        private Random r = new Random();

        private Button[] alphabetButtons;

        //The Word-Labels
        private List<Label> labels = new List<Label>();

        private bool ignore;

        //Stage means in which state the Hangman is. Is it more than 10 - Hang.
        private int stage = 0;

        //Load classes
        private MainMenu loadMain = new MainMenu();

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            //Get the Buttons and save them, except the "New Game"-Button
            alphabetButtons = Controls.OfType<Button>().Except(new Button[] { Button1 }).ToArray();
            Array.ForEach(alphabetButtons, b => b.Click += btn_click);
            //Well..Perform a click...
            Button1.PerformClick();
        }

        private void btn_click(object sender, EventArgs e)
        {
            if (ignore)
                return;
            Button b = (Button)sender;
            b.Enabled = false;
            //Set the Labels for every Bracket in the Word, and resize it, if the Word is long
            Array.ForEach(labels.ToArray(), lbl => lbl.Text = lbl.Tag.ToString() == b.Text ? b.Text : lbl.Text);
            for (int x = 1; x <= labels.Count - 1; x++)
            {
                labels[x].Left = labels[x - 1].Right;
            }

            if (labels[labels.Count - 1].Right > this.ClientSize.Width - 14)
            {
                this.SetClientSizeCore(labels[labels.Count - 1].Right + 14, 450);
            }

            stage += !labels.Any(lbl => lbl.Text == b.Text) ? 1 : 0;
            ignore = labels.All(lbl => lbl.Text != " ") || stage == 11;
            //Reload the UI
            Invalidate();
        }

        //Here gets the Hangman hanged, if you will so
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (stage >= 1)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 85, 190, 210, 190);
            }
            if (stage >= 2)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 190, 148, 50);
            }
            if (stage >= 3)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 50, 198, 50);
            }
            if (stage >= 4)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 50, 198, 70);
            }
            if (stage >= 5)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(188, 70, 20, 20));
            }
            if (stage >= 6)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 90, 198, 130);
            }
            if (stage >= 7)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 183, 115);
            }
            if (stage >= 8)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 213, 115);
            }
            if (stage >= 9)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 183, 170);
            }
            if (stage >= 10)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 213, 170);
            }
            if (stage >= 11)
            {
                MessageBox.Show("You failed!");
            }
        }

        //If you click on New Game
        private void Button1_Click(object sender, EventArgs e)
        {
            string[] list = File.ReadAllLines(@"C:/Hangman/Wordlists/german_wordlist.txt");
            //Reset the Size
            // SetClientSizeCore(370, 440);
            //Reset the Wordlist
            string word = list[r.Next(0, list.Length)].ToUpper();
            //Reset the Labels
            Array.ForEach(this.Controls.OfType<Label>().ToArray(), lbl => lbl.Dispose());
            Array.ForEach(alphabetButtons, b => b.Enabled = true);
            labels = new List<Label>();
            int startX = 14;
            foreach (char c in word)
            {
                Label lbl = new Label();
                lbl.Text = " ";
                lbl.Font = new Font(Font.Name, 24, FontStyle.Underline);
                lbl.Location = new Point(startX, 250);
                lbl.Tag = c.ToString();
                //Autosize if the Workd is to long
                lbl.AutoSize = true;
                Controls.Add(lbl);
                labels.Add(lbl);
                startX = lbl.Right;
            }
            ignore = false;
            stage = 0;
            //Redraw the UI
            Invalidate();
        }

        private void back_game_Click(object sender, EventArgs e)
        {
            Close();
            loadMain.Show();
        }
    }
}