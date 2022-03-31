using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using bookshelf.Properties;
using System.Linq;
using System.Collections.Generic;

namespace bookshelf
{
    public partial class Form1 : Form
    {
        #region -- Fields & obj --

        Random randomBook = new Random();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        bool _addCheck = false;
        //private static SpeechSynthesizer synth;
        BookForm bookForm = new BookForm();
        TextBox _text1 = new TextBox(); 
        TextBox _text2 = new TextBox();

        #endregion

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = Resources.shelf;
            FillBooks();


        }

        #region -- Methods & Events --

        private void Form1_Load(object sender, EventArgs e)
        {
            bookPictureBox1.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox2.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox3.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox4.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox5.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox6.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox7.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox8.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox9.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox10.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox11.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox12.Click += new EventHandler(pictureBox1_Click);
            bookPictureBox13.Click += new EventHandler(pictureBox1_Click);
        }

        private void FillBooks()
        {

            Image[] booksCrust = new Image[]
            {
            Image.FromFile(FullPathToProject(@"Resources\BlackBook.jpg")),
            Image.FromFile(FullPathToProject(@"Resources\BlueBook.jpg")),
            Image.FromFile(FullPathToProject(@"Resources\BrownBook.jpg")),
            Image.FromFile(FullPathToProject(@"Resources\DeepBlueBook.jpg")),
            Image.FromFile(FullPathToProject(@"Resources\GreenBook.jpg")),
            Image.FromFile(FullPathToProject(@"Resources\OrangeBook.jpg")),
            Image.FromFile(FullPathToProject(@"Resources\RedBook.jpg")),
            Image.FromFile(FullPathToProject(@"Resources\YelowBook.jpg")),
            };

            for (int i = 1; i < 28; i++)
            {
                (this.Controls["bookPictureBox" + i] as PictureBox).Image = booksCrust[randomBook.Next(0, 7)];
                (this.Controls["bookPictureBox" + i] as PictureBox).SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        public static string FullPathToProject(string path)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            return Path.Combine(projectDirectory, path);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _text1.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8);
                bookForm.TextBox1 = this._text1;
                _addCheck = true;
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Resources.ColorBook;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_addCheck == true)
            {
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox1")
            {
                BookForm bookForm = new BookForm();
                ReadInFile(FullPathToProject(@"Books\Boots.txt"));
                bookForm.TextBox1 = this._text1;
                bookForm.TextBox2 = this._text2;
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox2")
            {
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox3")
            {

            }
            if ((sender as PictureBox).Name == "bookPictureBox4")
            {

            }
            if ((sender as PictureBox).Name == "bookPictureBox5")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox6")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox7")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox8")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox9")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox10")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox11")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox12")
            {
                label1.Text = "XXXXXXX";
            }
            if ((sender as PictureBox).Name == "bookPictureBox13")
            {
                label1.Text = "XXXXXXX";
            }
        }
        public void ReadInFile(string path)
        {
            _text1.Text = File.ReadAllText(path, Encoding.UTF8);
            _text2.Text = File.ReadAllText(path, Encoding.UTF8);
        }
        public async void ReadInFile2(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                List<string> lines = new List<string>();
                while (!sr.EndOfStream)
                {
                   lines.Add(await sr.ReadLineAsync());
                }

            }

        }

        #endregion

    }
}
