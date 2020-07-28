using ImageProcessingWPF.Utility;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessingWPF.ViewModels
{
    class DynamicMatrixViewModel : INotifyPropertyChanged
    {
        private const int minSize = 3;
        private const int maxSize = 20;
        private const int defaultValue = 0;

        #region Helper classes
        public class Cell
        {
            private int _value = defaultValue;
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
                var oldValue = _width;
                _width = value.ParseAndValidate(_width, minSize, maxSize);
                OnWidthUpdated(oldValue, _width);
            }
        }

        private int _height;
        public string Height
        {
            get { return _height.ToString(); }
            set
            {
                var oldValue = _height;
                _height = value.ParseAndValidate(_height, minSize, maxSize);
                OnHeightChanged(oldValue, _height);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DynamicMatrixViewModel(int initialWidth = 3, int initialHeight = 3)
        {
            _width = initialWidth;
            _height = initialHeight;
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            var matrix = new List<Row>();
            for (int i = 0; i < _height; i++)
            {
                matrix.Add(new Row(_width));
            }
            Matrix = matrix;
        }
        private void OnWidthUpdated(int oldValue, int newValue)
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
        private void OnHeightChanged(int oldValue, int newValue)
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
            Matrix = matrix; //TODO can I update this more efficiently (look for force update)
        }
    }
}
