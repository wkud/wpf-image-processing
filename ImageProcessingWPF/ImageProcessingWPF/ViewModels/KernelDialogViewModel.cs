using ImageProcessingWPF.Utility;
using ImageProcessingWPF.Views;
using System.Collections.Generic;
using System.ComponentModel;

namespace ImageProcessingWPF.ViewModels
{
    class KernelDialogViewModel : INotifyPropertyChanged
    {
        public class Cell 
        {
            private int _value;
            public string Value
            {
                get { return _value.ToString(); }
                set { int.TryParse(value, out _value); }
            }
        }
        public class Row
        {
            public List<Cell> Cells { get; set; } = new List<Cell>();
        }

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


        private int _width = 3;
        public string Width
        {
            get { return _width.ToString(); }
            set
            {
                int.TryParse(value, out _width);
                InitializeGrid(); //TODO optimise
            }
        }

        private int _height = 3;
        public string Height
        {
            get { return _height.ToString(); }
            set
            {
                int.TryParse(value, out _height);
                InitializeGrid(); //TODO optimise
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public KernelDialogViewModel(MainWindow parentView)
        {
            KernelDialogWindow dialogWindow = new KernelDialogWindow();
            dialogWindow.DataContext = this;
            dialogWindow.Owner = parentView;
            InitializeGrid();
            dialogWindow.ShowDialog();
        }
        private void InitializeGrid()
        {
            var grid = new List<Row>();
            for (int i = 0; i < _width; i++)
            {
                grid.Add(new Row());

                for (int j = 0; j < _height; j++)
                {
                    var value = new Cell();
                    value.Value = (i * 10 + j).ToString();
                    grid[i].Cells.Add(value);
                }
            }
            Matrix = grid;
        }
    }
}
