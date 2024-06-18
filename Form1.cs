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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
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
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {


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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != string.Empty)
            {
                richTextBox1.Copy();
            }
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != string.Empty)
            {
                richTextBox1.Cut();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
    
    
    


