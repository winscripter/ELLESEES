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
using SixLabors.ImageSharp.Processing;
using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for ColorBlindnessValue.xaml
/// </summary>
public partial class ColorBlindnessValue : Window, ICanInitializeThemes
{
    /// <summary>
    /// Color Blindness Mode submitted by the user.
    /// </summary>
    public ColorBlindnessMode? Value { get; private set; } = null;

    /// <inheritdoc />
    public bool AreThemesInitialized
        => true;

    /// <inheritdoc />
    public ITheme UITheme
        => ThemeManager.ThemeManager.Current;

    /// <inheritdoc />
    public void InitializeThemes()
        => ThemeInitializer.Initialize(this);

    /// <inheritdoc />
    public void RequireThemeInitialization()
        => ThemeInitializationException.ThrowIf(!AreThemesInitialized);

    /// <summary>
    /// Initializes a new instance of <see cref="ColorBlindnessValue" />.
    /// </summary>
    public ColorBlindnessValue()
    {
        InitializeComponent();
        InitializeThemes();
    }

    // X close window title button
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void SetValue(ColorBlindnessMode value)
    {
        Value = value;

        Close();
    }

    private void Achromatomaly_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Achromatomaly);
    }

    private void Achromatopsia_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Achromatopsia);
    }

    private void Deuteranomaly_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Deuteranomaly);
    }

    private void Deuteranopia_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Deuteranopia);
    }

    private void Protanomaly_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Protanomaly);
    }

    private void Protanopia_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Protanopia);
    }

    private void Tritanomaly_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Tritanomaly);
    }

    private void Tritanopia_Click(object sender, RoutedEventArgs e)
    {
        SetValue(ColorBlindnessMode.Tritanopia);
    }

    // None button
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
