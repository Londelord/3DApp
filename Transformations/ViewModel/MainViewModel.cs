using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;

namespace Transformations.ViewModel;

public class MainViewModel : INotifyPropertyChanged
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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}