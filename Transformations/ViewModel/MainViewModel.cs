using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Transformations.ViewModel;

public sealed class MainViewModel : INotifyPropertyChanged
{
    private double _x;
    private double _y;
    private double _z;
    private double _scaleX = 1.0;
    private double _scaleY = 1.0;
    private double _scaleZ = 1.0;
    private double _rotationX;
    private double _rotationY;
    private double _rotationZ;
    private bool _isReflectedByXOY;
    private bool _isReflectedByXOZ;
    private bool _isReflectedByYOZ;
    private string _selectedProjection;
    
    public ObservableCollection<string> Projections { get; }
    public double X
    {
        get => _x;
        set
        {
            _x = value;
            OnPropertyChanged(nameof(X));
        }
    }

    public double Y
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged(nameof(Y));
        }
    }

    public double Z
    {
        get => _z;
        set
        {
            _z = value;
            OnPropertyChanged(nameof(Z));
        }
    }

    public double ScaleX
    {
        get => _scaleX;
        set
        {
            _scaleX = value;
            OnPropertyChanged(nameof(ScaleX));
        }
    }

    public double ScaleY
    {
        get => _scaleY;
        set
        {
            _scaleY = value;
            OnPropertyChanged(nameof(ScaleY));
        }
    }

    public double ScaleZ
    {
        get => _scaleZ;
        set
        {
            _scaleZ = value;
            OnPropertyChanged(nameof(ScaleZ));
        }
    }

    public double RotationX
    {
        get => _rotationX;
        set
        {
            _rotationX = value;
            OnPropertyChanged(nameof(RotationX));
        }
    }

    public double RotationY
    {
        get => _rotationY;
        set
        {
            _rotationY = value;
            OnPropertyChanged(nameof(RotationY));
        }
    }

    public double RotationZ
    {
        get => _rotationZ;
        set
        {
            _rotationZ = value;
            OnPropertyChanged(nameof(RotationZ));
        }
    }

    public bool IsReflectedByXOY
    {
        get => _isReflectedByXOY;
        set
        {
            _isReflectedByXOY = value;
            OnPropertyChanged(nameof(IsReflectedByXOY));
        }
    }

    public bool IsReflectedByXOZ
    {
        get => _isReflectedByXOZ;
        set
        {
            _isReflectedByXOZ = value;
            OnPropertyChanged(nameof(IsReflectedByXOZ));
        }
    }

    public bool IsReflectedByYOZ
    {
        get => _isReflectedByYOZ;
        set
        {
            _isReflectedByYOZ = value;
            OnPropertyChanged(nameof(IsReflectedByYOZ));
        }
    }

    public string SelectedProjection
    {
        get => _selectedProjection;
        set
        {
            _selectedProjection = value;
            OnPropertyChanged(nameof(SelectedProjection));
            Console.WriteLine(_selectedProjection);
        }
    }

    public MainViewModel(Action invalidate)
    {
        Projections = ["Axonometric", "Oblique", "CentralSinglePoint", "XoY", "YoZ", "XoZ"];
        _selectedProjection = Projections[0];

        PropertyChanged += (sender, args) => { invalidate(); };
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}