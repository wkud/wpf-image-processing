using ImageProcessingWPF.Utility;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessingWPF.Models
{
    public class Kernel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        public Kernel()
        {

        }

        private int _width;
        public Kernel(int width, int height)
        {
            _width = width;
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
            _width = newValue;
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
                    matrix.Add(new Row(_width));
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
    }

    public class Cell
    {
        private int _value = 0;
        public string Value
        {
            get { return _value.ToString(); }
            set
            {
                _value = value.ParseAndValidate(_value, -999, 999);
            }
        }
    }
    public class Row
    {
        public List<Cell> Cells { get; set; } = new List<Cell>();
        public Row()
        {

        }
        public Row(int width)
        {
            for (int x = 0; x < width; x++)
            {
                Cells.Add(new Cell());
            }
        }

        public void AddColumns(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Cells.Add(new Cell());
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
