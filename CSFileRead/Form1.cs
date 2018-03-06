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

namespace CSFileRead
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            this.OpenFileDialog.ShowDialog();
            this.FileOpenButton.Enabled = false;
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.FilePath.Text = this.OpenFileDialog.FileName;
            this.FileOpenButton.Enabled = true;
            this.WriteLog(this.FilePath.Text);
        }

        private void WriteLog(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.GetEncoding("Shift_JIS"));
                String line = "";
                int row = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    this.WriteLine($"{row} :\t{line}");
                    row += 1;
                }
            }
            catch (Exception e)
            {
                this.WriteLine($"[ERROR]{ e.ToString() }");
            }
        }

        private void WriteLine(string text)
        {
            this.LogBox.SelectionStart = this.LogBox.Text.Length;
            this.LogBox.SelectionLength = 0;
            this.LogBox.SelectedText = $"{text}\n";
        }

    }
}
