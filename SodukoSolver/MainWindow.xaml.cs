using System.Windows;

namespace SodukoSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Solver solver;

        public MainWindow()
        {
            InitializeComponent();

            // Init the solver with testing values
            int[,] initialGrid = new int[3, 3]
            {
                { 1, 0, 0 }, 
                { 3, 0, 2 },
                { 0, 3, 0 }
            };

            solver = new Solver(initialGrid);

         
            DataContext = solver;
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {

            int[,] solvedGrid = solver.Solve();

            if (solvedGrid != null)
            {
                UpdateLabels(solvedGrid);
                MessageBox.Show("Sudoku solved!");
                
            }
            else
            {
                MessageBox.Show("No solution found.");
            }
        }

        private void UpdateLabels(int[,] grid)
        {
        
            solver.Cell00 = grid[0, 0];
            solver.Cell01 = grid[0, 1];
            solver.Cell02 = grid[0, 2];
            solver.Cell10 = grid[1, 0];
            solver.Cell11 = grid[1, 1];
            solver.Cell12 = grid[1, 2];
            solver.Cell20 = grid[2, 0];
            solver.Cell21 = grid[2, 1];
            solver.Cell22 = grid[2, 2];

            // Notify UI to refresh
          
        }
    }
}
