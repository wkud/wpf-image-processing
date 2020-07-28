using ImageProcessingWPF.Utility;
using System.Collections.Generic;
using System.ComponentModel;

namespace ImageProcessingWPF.Models
{
    class DynamicMatrixHandler : INotifyPropertyChanged
    {
        #region Helper classes
        public class Cell
        {
            private int _value;
            public string Value
            {
                get { return _value.ToString(); }
                set
                {
                    var parsed = int.TryParse(value, out _value);
                }
            }
        }
        public class Row
        {
            public List<Cell> Cells { get; set; } = new List<Cell>();
        }
        #endregion

        private List<Row> _matrix;
        public List<Row> Matrix //TODO explain why this is needed instead of List<List<string>>
        {
            get { return _matrix; }
            set
            {
                _matrix = value;
                PropertyChanged.Notify(this, "Matrix");
            }
        }


        private int _width;
        public string Width
        {
            get { return _width.ToString(); }
            set
            {
                var parsed = int.TryParse(value, out _width);
                InitializeGrid(); //TODO optimise
            }
        }

        private int _height;
        public string Height
        {
            get { return _height.ToString(); }
            set
            {
                var parsed = int.TryParse(value, out _height);
                InitializeGrid(); //TODO optimise
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DynamicMatrixHandler(int initialWidth = 3, int initialHeight = 3)
        {
            _width = initialWidth;
            _height = initialHeight;
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            var matrix = new List<Row>();
            for (int i = 0; i < _width; i++)
            {
                matrix.Add(new Row());

                for (int j = 0; j < _height; j++)
                {
                    var cell = new Cell();
                    cell.Value = (i * 10 + j).ToString();
                    matrix[i].Cells.Add(cell);
                }
            }
            Matrix = matrix;
        }
    }
}
