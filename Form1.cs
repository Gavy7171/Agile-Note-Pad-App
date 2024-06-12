using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Note_Pad_App
{
    public partial class Form1 : Form
    {
        private string currentFilePath;

        public Form1()
        {
            InitializeComponent();

            
            this.KeyPreview = true;

            
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void openCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Open Note"
            };

            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                currentFilePath = openFileDialog.FileName;
                richTextBox1.Text = File.ReadAllText(currentFilePath);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveAs();
            }
            else
            {
                File.WriteAllText(currentFilePath, richTextBox1.Text);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
           
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Save Note"
            };

            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                currentFilePath = saveFileDialog.FileName;
                File.WriteAllText(currentFilePath, richTextBox1.Text);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 12), Brushes.Black, e.MarginBounds);
        }

        private void Exit()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Open Note"
            };

            var result = MessageBox.Show("Do you want to save before exiting?", "Confirm", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    richTextBox1.Text = File.ReadAllText(currentFilePath);
                }
            }
            else if (result == DialogResult.No)
            {
                Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Exit();
            
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenNewNote();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode == Keys.N)
            {
                
                OpenNewNote();
            }

            if (e.Control && e.KeyCode == Keys.O)
            {
                
                openCtrlOToolStripMenuItem_Click(sender, e);
            }

            
            if (e.Control && e.KeyCode == Keys.S)
            {
                
                saveToolStripMenuItem_Click(sender, e);
            }

            
            if (e.Control && e.KeyCode == Keys.P)
            {
                
                printToolStripMenuItem_Click(sender, e);
            }
        }

        private void OpenNewNote()
        {
            
            Form1 newForm = new Form1();
            newForm.Show();
        }
    }
}
