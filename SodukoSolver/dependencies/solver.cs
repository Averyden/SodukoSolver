using System.ComponentModel;

namespace SodukoSolver
{
    public class Solver : INotifyPropertyChanged
    {
        private int[,] grid;

        public Solver(int[,] initialGrid)
        {
            grid = initialGrid;

            UpdateCellProperties();
        }

        private int _cell00;
        public int Cell00
        {
            get { return _cell00; }
            set
            {
                if (_cell00 != value) // Only trigger if the value actually changes
                {
                    _cell00 = value;
                    OnPropertyChanged(nameof(Cell00));
                }
            }
        }

        private int _cell01;
        public int Cell01
        {
            get { return _cell01; }
            set
            {
                if (_cell01 != value)
                {
                    _cell01 = value;
                    OnPropertyChanged(nameof(Cell01));
                }
            }
        }

        private int _cell02;
        public int Cell02
        {
            get { return _cell02; }
            set
            {
                if (_cell02 != value)
                {
                    _cell02 = value;
                    OnPropertyChanged(nameof(Cell02));
                }
            }
        }

        private int _cell10;
        public int Cell10
        {
            get { return _cell10; }
            set
            {
                if (_cell10 != value)
                {
                    _cell10 = value;
                    OnPropertyChanged(nameof(Cell10));
                }
            }
        }

        private int _cell11;
        public int Cell11
        {
            get { return _cell11; }
            set
            {
                if (_cell11 != value)
                {
                    _cell11 = value;
                    OnPropertyChanged(nameof(Cell11));
                }
            }
        }

        private int _cell12;
        public int Cell12
        {
            get { return _cell12; }
            set
            {
                if (_cell12 != value)
                {
                    _cell12 = value;
                    OnPropertyChanged(nameof(Cell12));
                }
            }
        }

        private int _cell20;
        public int Cell20
        {
            get { return _cell20; }
            set
            {
                if (_cell20 != value)
                {
                    _cell20 = value;
                    OnPropertyChanged(nameof(Cell20));
                }
            }
        }

        private int _cell21;
        public int Cell21
        {
            get { return _cell21; }
            set
            {
                if (_cell21 != value)
                {
                    _cell21 = value;
                    OnPropertyChanged(nameof(Cell21));
                }
            }
        }

        private int _cell22;
        public int Cell22
        {
            get { return _cell22; }
            set
            {
                if (_cell22 != value)
                {
                    _cell22 = value;
                    OnPropertyChanged(nameof(Cell22));
                }
            }
        }
        public int[,] Solve()
        {
            if (SolveHelper())
            {
                UpdateCellProperties();
                return grid;
            }
            return null;
        }

        private bool SolveHelper()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        for (int num = 1; num <= 3; num++)
                        {
                            if (IsValidPlacement(row, col, num))
                            {
                                grid[row, col] = num;

                                if (SolveHelper())
                                    return true;

                                grid[row, col] = 0; 
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValidPlacement(int row, int col, int num)
        {
            for (int i = 0; i < 3; i++)
            {
                if (grid[row, i] == num || grid[i, col] == num)
                    return false;
            }
            return true;
        }

        private void UpdateCellProperties()
        {
            Cell00 = grid[0, 0];
            Cell01 = grid[0, 1];
            Cell02 = grid[0, 2];
            Cell10 = grid[1, 0];
            Cell11 = grid[1, 1];
            Cell12 = grid[1, 2];
            Cell20 = grid[2, 0];
            Cell21 = grid[2, 1];
            Cell22 = grid[2, 2];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
