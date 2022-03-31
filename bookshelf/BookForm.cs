using System;
using System.Globalization;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace bookshelf
{
    public partial class BookForm : Form
    {

        static SpeechSynthesizer _synth;
        bool _button2Clicked = false;
        ArrayList _list;
        int _page = 1;

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

            label1.Text = _page.ToString();
            label2.Text =(_page + 1).ToString();

            PreviosPageButton.Enabled = false;

            _synth = new SpeechSynthesizer();
            _synth.SetOutputToDefaultAudioDevice();
            _synth.GetInstalledVoices(new CultureInfo("ru-RU")); 
            
        }

        #region -- Methods & Events --

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!textBox1.Text.Equals(String.Empty))
            {
                _synth.SpeakAsync(textBox1.Text);
                if (!textBox2.Text.Equals(String.Empty))
                {
                    _synth.SpeakAsync(textBox2.Text);
                }
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
        private void Synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            
        }

        public void ReadInFile(string path)
        {
            double numberLine = 0;
            string temp = "";
            _list = new ArrayList();
            foreach (string curentLine in File.ReadLines(path))
            {
                temp += curentLine;
                if (numberLine % 15 == 0)
                {
                    _list.Add(temp);
                    temp = "";
                }
                numberLine++;
            }
            textBox1.Text = _list[_page].ToString();
            textBox2.Text = _list[_page + 1].ToString();
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            _page += 2;
            PreviosPageButton.Enabled = true;
                //_page += 2;
            textBox1.Text = _list[_page].ToString();
            textBox2.Text = _list[_page + 1].ToString();
            label1.Text = _page.ToString();
            label2.Text = (_page + 1).ToString();
        }

        private void PreviosPage_Click(object sender, EventArgs e)
        {
            NextPageButton.Enabled = true;
            _page -= 2;
            if (_page >= 0)
            {
                textBox1.Text = _list[_page].ToString();
                textBox2.Text = _list[_page + 1].ToString();
                label1.Text = _page.ToString();
                label2.Text = (_page + 1).ToString();
            }
            if (_page <= 0)
            {
                PreviosPageButton.Enabled = false;
            }
        }

        #endregion
    }
}
