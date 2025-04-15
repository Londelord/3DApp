using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Transformations.ViewModel;

namespace Transformations;

public partial class MainWindow : Window
{
    private TruncatedPyramid _pyramid;
    public MainWindow()
    {
        InitializeComponent();
        _pyramid = new TruncatedPyramid(170, 200, 120);
        DataContext = new MainViewModel(DrawPyramid);
    }

    private void DrawPyramid()
    {
        MainCanvas.Children.Clear();
                
        var viewModel = (MainViewModel)DataContext;
        
        _pyramid.Translate(viewModel.X, viewModel.Y, viewModel.Z);
        _pyramid.Rotate(viewModel.RotationX, viewModel.RotationY, viewModel.RotationZ);
        _pyramid.Scale(viewModel.ScaleX, viewModel.ScaleY, viewModel.ScaleZ);
        
        var linesCount = _pyramid.ConnectionsMatrix.GetLength(0);
        var canvasCenterX = MainCanvas.ActualWidth / 2;
        var canvasCenterY = MainCanvas.ActualHeight / 2;
        var transformedMatrix = _pyramid.GetTransformedVertices();
  

        var projectedMatrix = viewModel.SelectedProjection switch
        {
            "XoY" => Projection.ProjectToXoY(transformedMatrix),
            "XoZ" => Projection.ProjectToXoZ(transformedMatrix),
            "YoZ" => Projection.ProjectToYoZ(transformedMatrix),
            _ => Projection.ProjectToXoY(transformedMatrix)
        };

        for (var i = 0; i < linesCount; i++)
        {
            var line = new Line();
            var firstPoint = _pyramid.ConnectionsMatrix[i, 0];
            var secondPoint = _pyramid.ConnectionsMatrix[i, 1];
            
            line.X1 = projectedMatrix[firstPoint, 0] + canvasCenterX;
            line.Y1 = projectedMatrix[firstPoint, 1] + canvasCenterY;
            line.X2 = projectedMatrix[secondPoint, 0] + canvasCenterX;
            line.Y2 = projectedMatrix[secondPoint, 1] + canvasCenterY;

            line.Stroke = Brushes.Black;

            MainCanvas.Children.Add(line);
        }
    }

    private void OnResetButtonClick(object sender, RoutedEventArgs e)
    {
        var viewModel = (MainViewModel)DataContext;
        
        viewModel.X = viewModel.Y = viewModel.Z = 0;
        viewModel.ScaleX = viewModel.ScaleY = viewModel.ScaleZ = 1;
        viewModel.RotationX = viewModel.RotationY = viewModel.RotationZ = 0;
        viewModel.IsReflectedByXOY = viewModel.IsReflectedByXOZ = viewModel.IsReflectedByYOZ = false;
    }
}