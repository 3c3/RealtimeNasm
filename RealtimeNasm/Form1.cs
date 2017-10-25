using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RealtimeNasm
{
    public partial class Form1 : Form
    {
        bool asmChanged = false;
        bool shouldHighlightOnChange = true;
        NasmOutput output;

        public Form1()
        {
            InitializeComponent();
            if (!Nasm.LoadPath())
            {
                MessageBox.Show("No file loaded");
            }
            else asmTimer.Start();

            ColorScheme.LoadKeywords();

            asmBox.SelectionStart = asmBox.TextLength;

            arrayRb.CheckedChanged += DisplayTypeChanged;
            hexRb.CheckedChanged += DisplayTypeChanged;
            decimalRb.CheckedChanged += DisplayTypeChanged;
        }

        private void DisplayTypeChanged(object sender, EventArgs e)
        {
            DisplayBytes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "asm_*");
            foreach (string file in files) File.Delete(file);
        }

        private void asmBox_TextChanged(object sender, EventArgs e)
        {
            asmChanged = true;
            if (shouldHighlightOnChange) ColorScheme.Highlight(asmBox);
        }

        private void asmTimer_Tick(object sender, EventArgs e)
        {
            if (asmChanged)
            {
                output = Nasm.Assemble(asmBox.Text);

                DisplayBytes();
                outBox.Text = output.stdOut;
                asmChanged = false;
            }
        }

        void DisplayBytes()
        {
            if (output == null) return;

            if (arrayRb.Checked) bytesBox.Text = output.ToStringAsArray();
            else if (hexRb.Checked) bytesBox.Text = output.ToStringAsHex();
            else bytesBox.Text = output.ToStringAsDecimal();
        }

        public void OpenFile(string filePath)
        {
            asmBox.Text = File.ReadAllText(filePath);
            shouldHighlightOnChange = false;
            ColorScheme.HighlightAll(asmBox);
            shouldHighlightOnChange = true;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".asm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenFile(ofd.FileName);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".asm";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, asmBox.Text);
            }
        }
    }
}
