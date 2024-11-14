using SodukoSolver.dependencies;
using System.Windows;

namespace SodukoSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Solver s = new Solver();


        int[,] SodGrid = { { } };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = s;

            // Initialize test cells
            s.Cell00 = 1;
            s.Cell10 = 3;
            s.Cell12 = 2;
            s.Cell21 = 3;

            SodGrid = new int[3, 3]
            {
                { s.Cell00, s.Cell01, s.Cell02 },
                { s.Cell10, s.Cell11, s.Cell12 },
                { s.Cell21, s.Cell22, s.Cell22 }
            };
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            s.solve(SodGrid); // find a way to databing all the current cells into one int[,] type.
        }
    }
}
