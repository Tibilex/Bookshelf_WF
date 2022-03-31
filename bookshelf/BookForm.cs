using System;
using System.Drawing;
using System.Globalization;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;

namespace bookshelf
{
    public partial class BookForm : Form
    {

        private static SpeechSynthesizer _synth;
        private Form1 _form;
        private bool _button2Clicked = false;
        public TextBox TextBox1;
        public TextBox TextBox2;

        public BookForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = Properties.Resources.book;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox1.BorderStyle = BorderStyle.None;
            textBox2.BorderStyle = BorderStyle.None;
            textBox1.WordWrap = true;
            textBox2.WordWrap = true;

            //textBox2.MaxLength = 100;

            _synth = new SpeechSynthesizer();
            _synth.SetOutputToDefaultAudioDevice();
            _synth.GetInstalledVoices(new CultureInfo("ru-RU"));         
        }

        #region -- Methods & Events --
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!textBox1.Text.Equals(String.Empty))
            {
                _synth.SpeakAsync(TextBox1.Text);
            }
            if (_button2Clicked == true)
            {
                _synth.Resume();
                _button2Clicked = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _synth.Pause();  
            _button2Clicked = true;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (!TextBox1.Text.Equals(String.Empty))
            {
                textBox1.Text = TextBox1.Text;
                textBox2.Text = TextBox2.Text;
            }
        }
        //public void ReadInFile()
        //{
        //    textBox1.Text = File.ReadLines(FullPathToProject(@"Books\Boots.txt"), Encoding.UTF8).First();
        //    textBox2.Text = File.ReadLines(FullPathToProject(@"Books\Boots.txt"), Encoding.UTF8).Skip(15).First();
        //}
        //public static string FullPathToProject(string path)
        //{
        //    string workingDirectory = Environment.CurrentDirectory;
        //    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        //    return Path.Combine(projectDirectory, path);
        //}
        #endregion
    }
}
