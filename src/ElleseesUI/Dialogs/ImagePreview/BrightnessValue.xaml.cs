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
using ElleseesUI.Core;
using ElleseesUI.Exceptions;
using ElleseesUI.ThemeManager;
using System.Globalization;
using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for BrightnessValue.xaml
/// </summary>
public partial class BrightnessValue : Window, ICanInitializeThemes
{
    /// <summary>
    /// Brightness value.
    /// </summary>
    public float? Value { get; set; } = null;

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
    /// Initializes a new instance of <see cref="BrightnessValue" />.
    /// </summary>
    public BrightnessValue()
    {
        InitializeComponent();
        InitializeThemes();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Submit_Click(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(Brightness.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
        {
            MessageBoxCommon.ErrorOk("Please enter a valid number (f.e. 12.34, 12,34, 5, etc)");

            return;
        }

        if (value >= 10000.0F)
        {
            MessageBoxCommon.ErrorOk("Cannot apply brightness with value 10000 or greater");

            return;
        }

        if (value == 1.0F)
        {
            MessageBoxCommon.InfoOk("A brightness value of 1.0 won't make any changes");

            // Because a brightness value of 1.0 doesn't change anything,
            // if we try to set brightness to 1.0, we're really just using
            // extra processing power for quite literally nothing.
            // For the sake of performance and efficiency, just do not return
            // any value.

            Close();
            return;
        }

        if (value < 0.0F)
        {
            value = 0.0F;
        }

        if (value > 100.0F)
        {
            if (MessageBoxCommon.WarnYesNo("Values greater than or equal to 100 may turn an image completely light, making it unexplainable. Are you sure you want to continue?") == MessageBoxResult.No)
            {
                return;
            }
        }

        Value = value;
        Close();
    }
}
