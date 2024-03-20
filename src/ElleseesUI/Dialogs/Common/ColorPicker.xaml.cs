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

using ElleseesUI.Abstractions;
using ElleseesUI.Exceptions;
using ElleseesUI.ThemeManager;
using SixLabors.ImageSharp.PixelFormats;
using System.Windows;

namespace ElleseesUI.Dialogs.Common;

/// <summary>
/// Interaction logic for ColorPicker.xaml
/// </summary>
public partial class ColorPicker : Window, ICanInitializeThemes
{
    /// <summary>
    /// RGBA Color returned by the dialog.
    /// </summary>
    public Rgba32? Rgba { get; private set; } = null;

    /// <summary>
    /// Given alpha value by the user.
    /// </summary>
    public float? ActualAlpha { get; private set; } = null;

    /// <inheritdoc />
    public bool AreThemesInitialized
        => true;

    /// <inheritdoc />
    public ITheme UITheme => ThemeManager.ThemeManager.Current;

    /// <inheritdoc />
    public void InitializeThemes()
        => ThemeInitializer.Initialize(this);

    /// <inheritdoc />
    public void RequireThemeInitialization()
        => ThemeInitializationException.ThrowIf(!AreThemesInitialized);

    /// <summary>
    /// Initializes a new instance of <see cref="ColorPicker" />.
    /// </summary>
    public ColorPicker()
    {
        InitializeComponent();
        InitializeThemes();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void UseHexButton_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new ColorPickerHex();
        dlg.ShowDialog();

        if (dlg.Rgb is not null)
        {
            Rgba = new(Convert.ToSingle(dlg.Rgb.R),
                       Convert.ToSingle(dlg.Rgb.G),
                       Convert.ToSingle(dlg.Rgb.B),
                       1F);
            //Vector = new(Convert.ToSingle(dlg.Rgb.R),
            //             Convert.ToSingle(dlg.Rgb.G),
            //             Convert.ToSingle(dlg.Rgb.B),
            //             1F);
            ActualAlpha = 1F;

            Close();
        }
    }

    private void UseRgbButton_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new ColorPickerRgb();
        dlg.ShowDialog();

        if (dlg.DataSuccessfullyReturned)
        {
            Rgba = new(Convert.ToSingle(dlg.RValue ?? 0),
                       Convert.ToSingle(dlg.GValue ?? 0),
                       Convert.ToSingle(dlg.BValue ?? 0),
                       1F);
            //Vector = new(Convert.ToSingle(dlg.RValue ?? 0),
            //             Convert.ToSingle(dlg.GValue ?? 0),
            //             Convert.ToSingle(dlg.BValue ?? 0),
            //             1F);
            ActualAlpha = 1F;

            Close();
        }
    }

    private void UseRgbaButton_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new ColorPickerRgba();
        dlg.ShowDialog();

        if (dlg.DataSuccessfullyReturned)
        {
            Rgba = new(dlg.RValue ?? 0.0F,
                       dlg.GValue ?? 0.0F,
                       dlg.BValue ?? 0.0F,
                       dlg.AValue ?? 1F);
            //Vector = new(Convert.ToSingle(dlg.RValue ?? 0.0F),
            //             Convert.ToSingle(dlg.GValue ?? 0.0F),
            //             Convert.ToSingle(dlg.BValue ?? 0.0F),
            //             Convert.ToSingle(dlg.AValue ?? 1));
            ActualAlpha = dlg.AValue ?? 1F;
            Close();
        }
    }
}
