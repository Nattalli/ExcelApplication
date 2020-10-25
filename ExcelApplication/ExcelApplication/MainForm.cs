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

namespace ExcelApplication
{
    public partial class MainForm : Form
    {
        
        TheTable table = new TheTable();

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            InitTable(table.RowCount, table.ColCount);
        }

        private void InitTable(int row, int column)
        {
            dataGridView.ColumnHeadersVisible = true;
            dataGridView.RowHeadersVisible = true;
            dataGridView.ColumnCount = column;
            for(int i = 0; i < column; i++)
            {
                string columnName = TheNumberOfCell.ToIndexSystem(i);
                dataGridView.Columns[i].Name = columnName;
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < row; ++i)
            {
                dataGridView.Rows.Add("");
                dataGridView.Rows[i].HeaderCell.Value = (i).ToString();
            }

            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            table.SetTable(column, row);
        }


        private bool IsEnoughParen(string s)
        {
            int pparen = 0;
            int lparen = 0;
            foreach (char x in s)
            {
                if (x == '(') lparen++;
                if (x == ')') pparen++;
            }
            return lparen == pparen;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TableFile|*.txt";
            saveFileDialog.Title = "Save table file";
            saveFileDialog.ShowDialog();

            if(saveFileDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(fs);
                table.Save(sw);
                sw.Close();
                fs.Close();
            }
        }

        private void InitializeDataGridView(int rows, int columns)
        {
            dataGridView.ColumnHeadersVisible = true;
            dataGridView.RowHeadersVisible = true;
            dataGridView.ColumnCount = columns;
            for(int i = 0; i < columns; i++)
            {
                string ColumnName = TheNumberOfCell.ToIndexSystem(i);
                dataGridView.Columns[i].Name = ColumnName;
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for(int i = 0; i < rows; i++)
            {
                dataGridView.Rows.Add("");
                dataGridView.Rows[i].HeaderCell.Value = (i).ToString();
            }
            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            table.SetTable(columns, rows);
        }

        private void Calculating_Click(object sender, EventArgs e)
        {
            int column = dataGridView.SelectedCells[0].ColumnIndex;
            int row = dataGridView.SelectedCells[0].RowIndex;
            string expression = textBox1.Text;
            if(IsEnoughParen(expression))
            {
                if (expression == "") return;
                table.ChangeCellWithAllPointers(row, column, expression, dataGridView);
                dataGridView[column, row].Value = TheTable.border[row][column].value;
            }
            else
            {
                MessageBox.Show("The error in number of parens!");
            }
            
         }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TableFile|*.txt";
            openFileDialog.Title = "Open Table File";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamReader sr = new StreamReader(openFileDialog.FileName);
            table.Clear();
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            int row;
            int column;
            Int32.TryParse(sr.ReadLine(), out row);
            Int32.TryParse(sr.ReadLine(), out column);
            InitializeDataGridView(row, column);
            table.Open(row, column, sr, dataGridView);
            sr.Close();
        }

        private void RowAdding_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new System.Windows.Forms.DataGridViewRow();
            if(dataGridView.Columns.Count == 0)
            {
                MessageBox.Show("There are no columns!");
                return;
            }
            dataGridView.Rows.Add(row);
            dataGridView.Rows[table.RowCount].HeaderCell.Value = (table.RowCount).ToString();
            table.AddRow(dataGridView);
        }

        private void RowDeleting_Click(object sender, EventArgs e)
        {
            int curRow = table.RowCount - 1;
            if (!table.DeleteRow(dataGridView))
                return;
            dataGridView.Rows.RemoveAt(curRow);
        }

        private void ColumnAdding_Click(object sender, EventArgs e)
        {
            string name = TheNumberOfCell.ToIndexSystem(table.ColCount);
            dataGridView.Columns.Add(name, name);
            table.AddColumn(dataGridView);
        }

        private void ColumnDeleting_Click(object sender, EventArgs e)
        {
            int curCol = table.ColCount - 1;
            if (!table.DeleteColumn(dataGridView))
                return;
            dataGridView.Columns.RemoveAt(curCol);
        }

        private void dataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int columns = dataGridView.SelectedCells[0].ColumnIndex;
            int row = dataGridView.SelectedCells[0].RowIndex;
            string expression = TheTable.border[row][columns].expression;
            string value = TheTable.border[row][columns].value;
            textBox1.Text = expression;
            textBox1.Focus();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Available functions: \n 1. + , - , * , / \n 2. Unary +, - \n 3. Mmax, mmin");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            errorMessage += "Are you sure you want to exit?";
            System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(errorMessage, "Exit", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (res == System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public class DataGridViewTextBoxCell
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FileTool_Click(object sender, EventArgs e)
        {

        }

        private void Excel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
