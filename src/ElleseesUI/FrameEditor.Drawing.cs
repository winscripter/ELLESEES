// MIT License
// 
// Copyright (c) 2024 winscripter
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using Ellesees.Base.Context;
using Ellesees.Base.ImageHandling;
using ElleseesUI.Core;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;
using System.Windows;
using Ellesees.Base;
using ElleseesUI.Core.Common.ImageTasks;

namespace ElleseesUI;

public partial class FrameEditor
{
    /// <summary>
    /// Applies Hue effect to an image.
    /// </summary>
    public void ApplyHue(float amount)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Hue(amount));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Hue((int)amount));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies grayscaling effect with BT.709 toning to an image.
    /// </summary>
    public void GrayscaleBt709()
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Grayscale(GrayscaleMode.Bt709));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new GrayscaleBt709());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies grayscaling effect with BT.601 toning to an image.
    /// </summary>
    public void GrayscaleBt601()
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Grayscale(GrayscaleMode.Bt601));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new GrayscaleBt601());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies custom grayscaling to an image.
    /// </summary>
    public void GrayscaleBy(float amount)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Grayscale(amount));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Grayscale(amount));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies saturation effect to an image.
    /// </summary>
    public void ApplySaturation(float amount)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Saturate(amount));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Saturate(amount));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies lightness effect to an image.
    /// </summary>
    public void ApplyLightness(float amount)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Lightness(amount));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Lightness(amount));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies brightness effect to an image.
    /// </summary>
    public void ApplyBrightness(float amount)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Brightness(amount));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Brightness(amount));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies default glowing effect to an image.
    /// </summary>
    public void ApplyGlow()
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Glow());

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Glow());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies custom glowing effect to an image.
    /// </summary>
    public void ApplyGlow(float amount, Rgba32 color)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Glow(color,
                                        amount,
                                        new Rectangle(
                                            0,
                                            0,
                                            LoadedImage!.Width,
                                            LoadedImage!.Height
                                        )
                           ));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new GlowBy(amount, color));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies default box blur effect to an image.
    /// </summary>
    public void ApplyBoxBlur()
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.BoxBlur());

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new BoxBlur());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies custom box blur effect to an image.
    /// </summary>
    public void ApplyBoxBlur(int amount)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.BoxBlur(amount));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new BoxBlurBy(amount));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies default bokeh blur effect to an image.
    /// </summary>
    public void ApplyBokehBlur()
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.BokehBlur());

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new BokehBlur());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies custom bokeh blur effect to an image.
    /// </summary>
    public void ApplyBokehBlur(int radius, int components, float gamma)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.BokehBlur(radius, components, gamma));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new BokehBlurBy(radius, components, gamma));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies Black &amp; White effect to an image.
    /// </summary>
    public void ApplyBlackAndWhite()
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.BlackWhite());

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new BlackAndWhite());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies contrast effect to an image.
    /// </summary>
    public void ApplyContrast(float contrast)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Contrast(contrast));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Contrast(contrast));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies background color effect to an image.
    /// </summary>
    public void ApplyBackColor(Color color)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.BackgroundColor(color));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Background(color));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies color blindness effect to an image.
    /// </summary>
    public void ApplyColorBlindness(ColorBlindnessMode cbm)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.ColorBlindness(cbm));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new ColorBlindness(cbm));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies crop effect to an image.
    /// </summary>
    public void ApplyCrop(int newx, int newy)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Crop(newx, newy));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Crop(newx, newy));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies resize effect to an image.
    /// </summary>
    public void ApplyResize(int newx, int newy)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Resize(newx, newy));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Resize(newx, newy));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies rotation effect to an image.
    /// </summary>
    public void ApplyRotate(float deg)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.Rotate(deg));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Rotate(deg));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies gaussian blur effect to an image.
    /// </summary>
    public void ApplyGaussianBlur(float sigma)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        LoadedImage!.Mutate(x => x.GaussianBlur(sigma));

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new GaussianBlur(sigma));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies scaling (aka zooming) effect to an image.
    /// </summary>
    public void ApplyScale(int x, int y)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var r = LoadedImage!;
        Zoom.ZoomImage(ref r, x, y);

        LoadedImage = r;

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Scale(x, y));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies Text effect to an image.
    /// </summary>
    public void ApplyText(TextContext ctx)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var instance = new ImageObject(LoadedImage!);
        instance.AddText(ctx);
        LoadedImage = instance.Image;

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new Text(ctx));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    /// <summary>
    /// Applies rectangle fill effect to an image.
    /// </summary>
    internal void ApplyRectangleFill(RectangleFillOptions options)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var obj = new ImageObject(LoadedImage!);
        var image = obj.RectangleFill(options.StartX, options.StartY, options.EndX, options.EndY, options.FillColor);
        LoadedImage = image;

        SetWait();

        try
        {
            string ipath = directoryPath + "/" + GetAndIncrementLastImageIndex();
            LoadedImage!.Save(ipath);

            SetImage(Path.GetFullPath(ipath));
            Interactions.Push(new RectangleFill(options.StartX, options.StartY, options.EndX, options.EndY, options.FillColor));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}
