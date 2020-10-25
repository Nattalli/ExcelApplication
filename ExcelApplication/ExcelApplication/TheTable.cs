using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelApplication
{
    public class TheTable
    {
        private const int StartCol = 13;
        private const int StartRow = 10;

        public int ColCount, RowCount;

        public static List<List<Cell>> border = new List<List<Cell>>();
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public TheTable()
        {
            ColCount = StartCol;
            RowCount = StartRow;
            for (int i = 0; i < RowCount; ++i)
            {
                List<Cell> NewRow = new List<Cell>();
                for (int j = 0; j < ColCount; ++j)
                {
                    NewRow.Add(new Cell(i, j));
                    dictionary.Add(NewRow.Last().getName(), "");
                }
                border.Add(NewRow);
            }
        }
        //Change the numbers of rows or columns
        public void SetTable(int columns, int rows)
        {
            Clear();
            ColCount = columns;
            RowCount = rows;
            for (int i = 0; i < RowCount; ++i)
            {
                List<Cell> NewRow = new List<Cell>();
                for (int j = 0; j < ColCount; ++j)
                {
                    NewRow.Add(new Cell(i, j));
                    dictionary.Add(NewRow.Last().getName(), "");
                }
                border.Add(NewRow);
            }
        }

        public void Clear()
        {
            foreach(List<Cell> list in border)
            {
                list.Clear();
            }
            border.Clear();
            dictionary.Clear();
            RowCount = 0;
            ColCount = 0;
        }

        public void ChangeCellWithAllPointers(int row, int column, string expression, System.Windows.Forms.DataGridView dataGridView)
        {
            border[row][column].DeletePointersAndReferences();
            border[row][column].expression = expression;
            border[row][column].NewReferences.Clear();

            if(expression != "")
            {
                if(expression[0] != '=')
                {
                    border[row][column].value = expression;
                    dictionary[FullName(row, column)] = expression;
                    foreach(Cell cell in border[row][column].Pointer)
                    {
                        RefreshCellAndPointers(cell, dataGridView);
                    }
                    return;
                }
            }

            string new_expression = ConvertReferences(row, column, expression);

            if(new_expression != "")
            {
                new_expression = new_expression.Remove(0, 1);
            }

            if (!border[row][column].CheckLoop(border[row][column].NewReferences))
            {
                System.Windows.Forms.MessageBox.Show("Error! Please, change your expression.");
                border[row][column].expression = "";
                border[row][column].value = "0";
                dataGridView[column, row].Value = "0";
                return;
            }

            border[row][column].AddPointersAndReferences();
            string value = Calculate(new_expression);
            if(value == "error")
            {
                System.Windows.Forms.MessageBox.Show("Error in the cell - " + FullName(row, column));
                border[row][column].expression = "";
                border[row][column].value = "0";
                dataGridView[column, row].Value = "0";
                return;
            }

            border[row][column].value = value;
            dictionary[FullName(row, column)] = value;
            foreach (Cell cell in border[row][column].Pointer)
            RefreshCellAndPointers(cell, dataGridView);
        }
        private string FullName(int row, int column)
        {
            Cell cell = new Cell(row, column);
            return cell.getName();
        }
        public bool RefreshCellAndPointers(Cell cell, System.Windows.Forms.DataGridView dataGridView)
        {
            cell.NewReferences.Clear();
            string new_expression = ConvertReferences(cell.row, cell.column, cell.expression);
            new_expression = new_expression.Remove(0, 1);
            string Value = Calculate(new_expression);

            if(Value == "error")
            {
                System.Windows.Forms.MessageBox.Show("Error in the cell - " + cell.getName());
                return false;
            }

            border[cell.row][cell.column].value = Value;
            dictionary[FullName(cell.row, cell.column)] = Value;
            dataGridView[cell.column, cell.row].Value = Value;

            foreach(Cell point in cell.Pointer)
            {
                if (!RefreshCellAndPointers(point, dataGridView))
                    return false;
            }
            return true;
        }
        public string ConvertReferences(int row, int column, string expression)
        {
            string cellPattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(cellPattern, RegexOptions.IgnoreCase);
            TheIndex nums;

            foreach(Match match in regex.Matches(expression))
            {
                if(dictionary.ContainsKey(match.Value))
                {
                    nums = TheNumberOfCell.FromIndexSystem(match.Value);
                    border[row][column].NewReferences.Add(border[nums.row][nums.column]);
                }
            }

            MatchEvaluator evaluator = new MatchEvaluator(referencesToValue);
            string new_expression = regex.Replace(expression, evaluator);
            return new_expression;
        }

        public string referencesToValue(Match m)
        {
            if (dictionary.ContainsKey(m.Value))
                if (dictionary[m.Value] == "")
                    return "0";
                else
                    return dictionary[m.Value];
            return m.Value;
        }

       public string Calculate(string expression)
        {
            string result = null;
            try
            {
                result = Convert.ToString(Calculator.Evaluate(expression));
                if(result == "∞")
                {
                    MessageBox.Show("Error! Division by zero!");
                    result = "";
                }
                return result;
            }
            catch
            {
                return "";
            }
        }
    
        public void RefreshReferences()
        {
            foreach(List<Cell> list in border)
            {
                foreach (Cell cell in list)
                {
                    if (cell.References != null)
                        cell.References.Clear();
                    if (cell.NewReferences != null)
                        cell.NewReferences.Clear();
                    if (cell.expression == "")
                        continue;
                    string new_expression = cell.expression;
                    if(cell.expression[0] == '=')
                    {
                        new_expression = ConvertReferences(cell.row, cell.column, cell.expression);
                        cell.References.AddRange(cell.NewReferences);
                    }
                }
            }
        }

        public void AddRow(System.Windows.Forms.DataGridView dataGridView)
        {
            List<Cell> newRow = new List<Cell>();

            for(int i = 0; i < ColCount; i++)
            {
                newRow.Add(new Cell(RowCount, i));
                dictionary.Add(newRow.Last().getName(), "");
            }
            border.Add(newRow);
            RefreshReferences();
            foreach(List<Cell> list in border)
            {
                foreach(Cell cell in list)
                {
                    if (cell.References != null)
                    {
                        foreach (Cell cell_ref in cell.References)
                        {
                            if (cell_ref.row == RowCount )
                            {
                                if (!cell_ref.Pointer.Contains(cell))
                                    cell_ref.Pointer.Add(cell);
                            }
                        }
                    }
                }
            }
            for(int i = 0; i < ColCount; i++)
            {
                ChangeCellWithAllPointers(RowCount  , i, "", dataGridView);
            }

            RowCount++;
        }

        public void AddColumn(System.Windows.Forms.DataGridView dataGridView)
        {
            List<Cell> newCol = new List<Cell>();

            for (int i = 0; i < RowCount; i++)
            {
                string name = FullName(i, ColCount );
                border[i].Add(new Cell(i, ColCount));
                dictionary.Add(name, "");
            }
            
            RefreshReferences();
            foreach (List<Cell> list in border)
            {
                foreach (Cell cell in list)
                {
                    if (cell.References != null)
                    {
                        foreach (Cell cell_ref in cell.References)
                        {
                            if (cell_ref.column == ColCount )
                            {
                                if (!cell_ref.Pointer.Contains(cell))
                                    cell_ref.Pointer.Add(cell);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < RowCount; i++)
            {
                ChangeCellWithAllPointers(i, ColCount, "", dataGridView);
            }
            ColCount++;
        }

        public bool DeleteRow(System.Windows.Forms.DataGridView dataGridView)
        {
            List<Cell> lastRow = new List<Cell>();
            List<string> notEmptyCells = new List<string>();

            if (RowCount == 0)
                return false;

            int curCount = RowCount - 1;

            for(int i = 0; i < ColCount; i++)
            {
                string name = FullName(curCount, i);

                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(name);
                if (border[curCount][i].Pointer.Count != 0)
                    lastRow.AddRange(border[curCount][i].Pointer);
            }

            if (lastRow.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                    errorMessage += ' ';
                }

                if (lastRow.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current row : ";
                    foreach (Cell cell in lastRow)
                    {
                        errorMessage += string.Join(";", cell.getName());
                        errorMessage += " ";
                    }
                }

                errorMessage += "Are you sure you want to delete rhis row?";
                System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(errorMessage, "Warning", System.Windows.Forms.MessageBoxButtons.YesNo);
                
                if (res == System.Windows.Forms.DialogResult.No)
                    return false;
            }

            for(int i = 0; i < ColCount; i++)
            {
                string name = FullName(curCount, i);
                dictionary.Remove(name);
            }

            foreach (Cell cell in lastRow)
                RefreshCellAndPointers(cell, dataGridView);
            border.RemoveAt(curCount);
            RowCount--;
            return true;
        }

        public bool DeleteColumn(System.Windows.Forms.DataGridView dataGridView)
        {
            List<Cell> lastCol = new List<Cell>();
            List<string> notEmptyCells = new List<string>();

            if (ColCount == 0)
                return false;

            int curCount = ColCount - 1;

            for(int i = 0; i < RowCount; i++)
            {
                string name = FullName(i, curCount);
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(name);
                if (border[i][curCount].Pointer.Count != 0)
                    lastCol.AddRange(border[i][curCount].Pointer);
            }

            if (lastCol.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                }

                if (lastCol.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current column: ";
                    foreach (Cell cell in lastCol)
                        errorMessage += string.Join(";", cell.getName());
                }

                errorMessage += "Are you sure you want to delete this column?";
                System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(errorMessage, "Warning", System.Windows.Forms.MessageBoxButtons.YesNo);
                
                if (res == System.Windows.Forms.DialogResult.No)
                    return false;
            }

            for(int i = 0; i < RowCount; i++)
            {
                string name = FullName(i, curCount);
                dictionary.Remove(name);
            }

            foreach (Cell cell in lastCol)
                RefreshCellAndPointers(cell, dataGridView);

            for(int i = 0; i < RowCount; i++)
            {
                border[i].RemoveAt(curCount);
            }

            ColCount--;
            return true;
        }
        public void Open(int r, int c, System.IO.StreamReader sr, System.Windows.Forms.DataGridView dataGridView)
        {
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    string index = sr.ReadLine();
                    string expression = sr.ReadLine();
                    string value = sr.ReadLine();

                    if (expression != "")
                        dictionary[index] = value;
                    else
                        dictionary[index] = "";

                    int refCount = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newRef = new List<Cell>();
                    string refer;

                    for(int k = 0; k < refCount; k++)
                    {
                        refer = sr.ReadLine();
                        if (TheNumberOfCell.FromIndexSystem(refer).row < RowCount && TheNumberOfCell.FromIndexSystem(refer).column < ColCount)
                            newRef.Add(border[TheNumberOfCell.FromIndexSystem(refer).row][TheNumberOfCell.FromIndexSystem(refer).column]);
                    }

                    int pointCount = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newPoint = new List<Cell>();
                    string point;

                    for(int k = 0; k < pointCount; k++)
                    {
                        point = sr.ReadLine();
                        newPoint.Add(border[TheNumberOfCell.FromIndexSystem(point).row][TheNumberOfCell.FromIndexSystem(point).column]);
                    }
                    border[i][j].SetCell(expression, value, newRef, newPoint);

                    int curCol = border[i][j].column;
                    int curRow = border[i][j].row;
                    dataGridView[curCol, curRow].Value = dictionary[index];
                }
            }
        }
        public void Save(System.IO.StreamWriter sw)
        {
            sw.WriteLine(RowCount);
            sw.WriteLine(ColCount);

            foreach(List<Cell> list in border)
            {
                foreach(Cell cell in list)
                {
                    sw.WriteLine(cell.getName());
                    sw.WriteLine(cell.expression);
                    sw.WriteLine(cell.value);

                    if (cell.References == null)
                        sw.WriteLine("0");
                    else
                    {
                        sw.WriteLine(cell.References.Count);
                        foreach (Cell refCell in cell.References)
                            sw.WriteLine(refCell.getName());
                    }
                    if (cell.Pointer == null)
                        sw.WriteLine("0");
                    else
                    {
                        sw.WriteLine(cell.Pointer.Count);
                        foreach (Cell pointCell in cell.Pointer)
                            sw.WriteLine(pointCell.getName());
                    }
                }
            }
        }
    }
}
