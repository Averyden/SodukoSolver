using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.dependencies
{
    public class Solver : INotifyPropertyChanged
    {

        private int _cell00;
        private int _cell01;
        private int _cell02;
        private int _cell10;
        private int _cell11;
        private int _cell12;
        private int _cell20;
        private int _cell21;
        private int _cell22;

        public int Cell00
        {
            get { return _cell00; }
            set { _cell00 = value; OnPropertyChanged(nameof(Cell00)); }
        }

        public int Cell01
        {
            get { return _cell01; }
            set { _cell01 = value; OnPropertyChanged(nameof(Cell01)); }
        }

        public int Cell02
        {
            get { return _cell02; }
            set { _cell02 = value; OnPropertyChanged(nameof(Cell02)); }
        }

        public int Cell10
        {
            get { return _cell10; }
            set { _cell10 = value; OnPropertyChanged(nameof(Cell10)); }
        }

        public int Cell11
        {
            get { return _cell11; }
            set { _cell11 = value; OnPropertyChanged(nameof(Cell11)); }
        }

        public int Cell12
        {
            get { return _cell12; }
            set { _cell12 = value; OnPropertyChanged(nameof(Cell12)); }
        }

        public int Cell20
        {
            get { return _cell20; }
            set { _cell20 = value; OnPropertyChanged(nameof(Cell20)); }
        }

        public int Cell21
        {
            get { return _cell21; }
            set { _cell21 = value; OnPropertyChanged(nameof(Cell21)); }
        }

        public int Cell22
        {
            get { return _cell22; }
            set { _cell22 = value; OnPropertyChanged(nameof(Cell22)); }
        }


        public int[,] solve(int[,] grid)
        {
            int[] xRow = new int[grid.GetLength(0)];
            int[] yRow = new int[grid.GetLength(1)];

            for (int x = 0; x < xRow.Length; x++ )
            {
                for (int y = 0; y< yRow.Length; y++)
                {
                    if (grid[x, y] == 0)
                    {
                        for (int curNum = 1; curNum<9;)
                        {
                            if (grid[x,y] == curNum) 
                            {
                                Debug.WriteLine("invalid num for placement, moving on."); // increment number as its invalid.
                                curNum++;
                            } else
                            {
                                grid[x,y] = curNum;
                                Debug.WriteLine("placed valid num");
                                if (solve(grid) != null)
                                {
                                    return grid; // If the grid is solved, return it
                                }
                            }
                            return null;
                        }
                    }
                }
            }
            return grid;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)

        {

            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;

            if (propertyChanged != null)

            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }

        }

    }
}
