using Ellesees.Base.Context;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Base;

public class ImageObject
{
    private readonly int _height;
    private readonly int _width;

    private Image<Rgba32> _image;
    private ObjectMode mode;

    public ImageObject(Image<Rgba32> image)
    {
        _height = image.Height;
        _width = image.Width;
        _image = image;

        mode = ObjectMode.Unknown;
    }

    public void AddText(TextContext context)
    {
        AddText(context, context.Position.X, context.Position.Y);
    }

    public void AddText(TextContext ctx, float x, float y)
    {
        ctx.Position = new PointF(x, y);

        if (ctx.Shadow is null)
        {
            TextContext.DrawText(_image, ctx.Text, ctx.Foreground, ctx.Font, ctx.Position);
        }
        else
        {
            TextContext.DrawTextWithShadow(_image, ctx.Text, ctx.Foreground, ctx.Font, ctx.Shadow.ShadowColor, ctx.Shadow.Strength, ctx.Position, new(3, 3));
        }

        //ctx.DrawOn(_image, ctx.Shadow is null
        //                   ? null
        //                   : new TextShadowOptions(ctx.Shadow, ctx.Position, new Point(3, 3)));

        mode = ObjectMode.Text;
    }

    public void Fill(Color color)
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _image[x, y] = color;
            }
        }

        mode = ObjectMode.Fill;
    }

    public void Fill(Rgba32 color)
    {
        Fill(Color.FromRgba(color.R, color.G, color.B, color.A));
    }

    public Image<Rgba32> RectangleFill(int x1, int y1, int x2, int y2, Rgba32 color)
    {
        var rectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
        var brush = new SolidBrush(color);

        _image.Mutate(ctx => ctx.Fill(brush, rectangle));

        mode = ObjectMode.RectangleFill;

        return _image;
    }

    public void Stroke(Stroke stroke)
    {
        RectangleFill(0, 0, Height, stroke.Size, stroke.Color);
        RectangleFill(0, Height, Width, stroke.Size, stroke.Color);
        RectangleFill(Width, Height, Width - stroke.Size, 0, stroke.Color);
        RectangleFill(Width, Height, 0, stroke.Size, stroke.Color);

        mode = ObjectMode.RectangleStroke;
    }

    private void Mutate(Action<IImageProcessingContext> cxt)
    {
        _image.Mutate(cxt);
    }

    public void SetImage(Image<Rgba32> image)
    {
        _image = image;

        mode = ObjectMode.Image;
    }

    public void Grayscale()
    {
        Mutate(x => x.Grayscale());
    }

    public void ApplyHue(float hue)
    {
        Mutate(x => x.Hue(hue));
    }

    public void Saturate(float saturation)
    {
        Mutate(x => x.Saturate(saturation));
    }

    public void Lightness(float lightness)
    {
        Mutate(x => x.Lightness(lightness));
    }

    public void Brightness(float brightness)
    {
        Mutate(x => x.Brightness(brightness));
    }

    public void Glow(float radius)
    {
        Mutate(x => x.Glow(radius));
    }

    public void BoxBlur()
    {
        Mutate(x => x.BoxBlur());
    }

    public void BokehBlur()
    {
        Mutate(x => x.BokehBlur());
    }

    public void BlackAndWhite()
    {
        Mutate(x => x.BlackWhite());
    }

    public void Contrast(float contrast)
    {
        Mutate(x => x.Contrast(contrast));
    }

    public void BackgroundColor(Color color)
    {
        Mutate(x => x.BackgroundColor(color));
    }

    public void ApplyColorBlindness(ColorBlindnessMode mode)
    {
        Mutate(x => x.ColorBlindness(mode));
    }

    public void Crop(Rectangle cropRect)
    {
        Mutate(x => x.Crop(cropRect));
    }

    public void Resize(int width, int height)
    {
        Mutate(x => x.Resize(width, height));
    }

    public void Resize(Size size)
    {
        Resize(size.Width, size.Height);
    }

    public void Resize(SizeF size)
    {
        Resize((int)size.Height, (int)size.Width);
    }

    public void Resize(Point point)
    {
        Resize(point.X, point.Y);
    }

    public void Resize(PointF pf)
    {
        Resize((int)pf.X, (int)pf.Y);
    }

    public void ReplaceWhiteWithTransparency()
    {
        // HACK: May not work

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (_image[x, y].A < 50)
                {
                    _image[x, y] = new Rgba32(255.0F, 255.0F, 255.0F, 0F);
                }
            }
        }
    }

    public void Rotate(float angle)
    {
        Mutate(x => x.Rotate(angle switch
        {
            90.0F => RotateMode.Rotate90,
            180.0F => RotateMode.Rotate180,
            270.0F => RotateMode.Rotate270,
            360.0F or _ => RotateMode.None
        }));
    }

    public void GaussianBlur(float sigma)
    {
        // If Gaussian Blur was a separate mode,
        // it would turn out to be a black object.
        // Completely invisible.
        // In this case, Gaussian Blur is not a separate
        // mode and can be used to blur an existing image.

        Mutate(x => x.GaussianBlur(sigma));
    }

    public int Height
    {
        get
        {
            return _height;
        }
    }

    public int Width
    {
        get
        {
            return _width;
        }
    }

    public void Save(string path)
    {
        _image.Save(path);
    }

    public Image<Rgba32> Image
    {
        get
        {
            return _image;
        }
    }

    public ObjectMode Mode
    {
        get
        {
            return mode;
        }
    }
}
