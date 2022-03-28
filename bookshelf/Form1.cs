using System;
using System.Drawing;
using System.IO;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using bookshelf.Properties;


namespace bookshelf
{
    public partial class Form1 : Form
    {
        Random randomBook = new Random();
        Random randomBookPosition = new Random();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        static SpeechSynthesizer synth;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = Resources.shelf;
            FillBooks();
        }

        private void FillBooks()
        {
            for (int i = 1; i < 28; i++)
            {
                (this.Controls["bookPictureBox" + i] as PictureBox).Image = books2[randomBook.Next(0, 7)];
                (this.Controls["bookPictureBox" + i] as PictureBox).SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private static string FullPathToProject(string path)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            return Path.Combine(projectDirectory, path);
        }

        Image[] books2 = new Image[]
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

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Resources.ColorBook;
            pictureBox1.Visible = true;
        }

    }
}
