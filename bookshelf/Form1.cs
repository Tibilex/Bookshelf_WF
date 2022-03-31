using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using bookshelf.Properties;
using System.Collections;

namespace bookshelf
{
    public partial class Form1 : Form
    {
        #region -- Fields & obj --

        Random randomBook = new Random();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        bool _addCheck = false;
        ArrayList _list;
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
                bookForm.ReadInFile(openFileDialog1.FileName);
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
                bookForm.ReadInFile(FullPathToProject(@"Books\mertvye-dushi.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox2")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\idiot.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox3")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\geroy-nashego-vremeni.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox4")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\belye-nochi.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox5")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\reyder-si.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox6")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\put-lekarya.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox7")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\geksalogiya.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox8")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\ohotnik-dart.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox9")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\my.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox10")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\graf-monte-kristo.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox11")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\evgeniy-onegin.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox12")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\bratya-karamazovy.txt"));
                bookForm.ShowDialog();
            }
            if ((sender as PictureBox).Name == "bookPictureBox13")
            {
                BookForm bookForm = new BookForm();
                bookForm.ReadInFile(FullPathToProject(@"Books\bibliya.txt"));
                bookForm.ShowDialog();
            }
        }

        #endregion
    }
}
