using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelApplication
{
	public class Cell
	{
		public string Name
		{ get; set; }
		public string expression 
		{ get; set; }
		public string value 
		{ get; set; }
		public int column
		{ get; set; }
		public int row 
		{ get; set; }

		public List<Cell> Pointer = new List<Cell>();

		public List<Cell> References = new List<Cell>();

		public List<Cell> NewReferences = new List<Cell>();

		public Cell(int rows, int columns)
		{
			row = rows;
			column = columns;
			Name = TheNumberOfCell.ToIndexSystem(columns) + Convert.ToString(rows);
			value = "0";
			expression = "";
		}

		public void SetCell(string exp, string val, List<Cell> a, List<Cell> b)
        {
			this.value = val;
			this.expression = exp;
			this.References.Clear();
			this.References.AddRange(a);
			this.Pointer.Clear();
			this.Pointer.AddRange(b);
        }

		public string getName()
        {
			return Name;
        }

		public bool CheckLoop(List<Cell> list)
        {
			foreach (Cell cell in list)
            {
				if (cell.Name == Name)
					return false;
            }
			foreach (Cell point in Pointer)
            {
				foreach (Cell cell in list)
                {
					if (cell.Name == point.Name )
                    {
						return false;
                    }
                }
				if (!point.CheckLoop(list)) return false;
            }
			return true;
        }

		public void AddPointersAndReferences()
        {
			foreach (Cell point in NewReferences)
            {
				point.Pointer.Add(this);
            }
			References = NewReferences;
        }

		public void DeletePointersAndReferences()
        {
			if (References != null)
            {
				foreach (Cell point in References)
                {
					point.Pointer.Remove(this);
                }
				References = null;
            }
        }
	}
}
