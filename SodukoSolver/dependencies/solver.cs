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

        public int Cell00 { get; set; }
        public int Cell01 { get; set; }
        public int Cell02 { get; set; }
        public int Cell10 { get; set; }
        public int Cell11 { get; set; }
        public int Cell12 { get; set; }
        public int Cell20 { get; set; }
        public int Cell21 { get; set; }
        public int Cell22 { get; set; }


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
