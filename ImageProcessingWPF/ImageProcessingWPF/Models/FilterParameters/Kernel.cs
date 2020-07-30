using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Utility;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessingWPF.Models.FilterParameters
{
    public class Kernel : INotifyPropertyChanged, IFilterParameters
    {
        private List<Row> _matrix;
        public List<Row> Matrix  //TODO explain why this is needed instead of List<List<string>>
        {
            get { return _matrix; }
            set
            {
                _matrix = value;
                PropertyChanged.Notify(this, "Matrix");
            }
        }

        public int Width => Matrix[0].Cells.Count;
        public int Height => Matrix.Count;

        public event PropertyChangedEventHandler PropertyChanged;

        public Kernel()
        {

        }

        public Kernel(int width, int height)
        {
            var matrix = new List<Row>();
            for (int i = 0; i < height; i++)
            {
                matrix.Add(new Row(width));
            }
            Matrix = matrix;
        }
        public void OnWidthUpdated(int oldValue, int newValue)
        {
            if (oldValue == newValue)
                return;

            var matrix = Matrix.ToList();
            var difference = newValue - oldValue;
            if (difference > 0)
            {
                foreach (var row in matrix)
                {
                    row.AddColumns(difference);
                }
            }
            else if (difference < 0)
            {
                foreach (var row in matrix)
                {
                    row.RemoveColumns(-difference);
                }
            }
            Matrix = matrix;
        }
        public void OnHeightChanged(int oldValue, int newValue)
        {
            if (oldValue == newValue)
                return;

            var matrix = Matrix.ToList();
            var difference = newValue - oldValue;
            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {
                    matrix.Add(new Row(Width));
                }
            }
            else if (difference < 0)
            {
                for (int i = 0; i < -difference; i++)
                {
                    matrix.Remove(matrix.LastOrDefault());
                }
            }
            Matrix = matrix;
        }

        public int[,] ToArray()
        {
            var array = new int[Width, Height];
            int y = 0;
            foreach (var row in Matrix)
            {
                int x = 0;
                foreach (var cell in row.Cells)
                {
                    array[x, y] = cell.GetIntValue();
                    x++;
                }
                y++;
            }
            return array;
        }
    }

    public class Cell
    {
        private int _value;
        public string Value
        {
            get { return _value.ToString(); }
            set
            {
                _value = value.Parse(_value);
            }
        }
        public Cell()
        {

        }
        public Cell(int value)
        {
            _value = value;
        }
        public int GetIntValue() => _value;
    }
    public class Row
    {
        public List<Cell> Cells { get; set; } = new List<Cell>();
        public Row()
        {

        }
        public Row(int width)
        {
            AddColumns(width);
        }

        public void AddColumns(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Cells.Add(new Cell(1));
            }
        }
        public void RemoveColumns(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Cells.Remove(Cells.LastOrDefault());
            }
        }
    }
}
