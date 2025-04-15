using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Transformations;

public partial class MainWindow : Window
{
    private TruncatedPyramid _pyramid;
    public MainWindow()
    {
        InitializeComponent();

        _pyramid = new TruncatedPyramid(20, 30, 10);
    }
}