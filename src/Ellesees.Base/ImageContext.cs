namespace Ellesees.Base;

public class ImageContext
{
    private readonly string _imagePath;
    private readonly int _width;
    private readonly int _height;
    
    public ImageContext(string imagePath, int width, int height)
    {
        _imagePath = imagePath;
        _width = width;
        _height = height;
    }

    public string ImagePath
    {
        get
        {
            return _imagePath;
        }
    }

    public int Width
    {
        get
        {
            return _width;
        }
    }

    public int Height
    {
        get
        {
            return _height;
        }
    }

    public int PixelCount
    {
        get
        {
            return _width * _height;
        }
    }
}
