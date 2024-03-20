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

using ElleseesUI.Core;
using Ellesees.Base.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using ElleseesUI.ThemeManager;
using ElleseesUI.Exceptions;
using ElleseesUI.Abstractions;

namespace ElleseesUI.Dialogs.Common;

/// <summary>
/// Interaction logic for FontProviderChooser.xaml
/// </summary>
public partial class FontProviderChooser : Window, ICanInitializeThemes
{
    /// <summary>
    /// Name of the provider selected.
    /// </summary>
    public string? Provider { get; set; }

    /// <summary>
    /// List of providers displayed in the window.
    /// </summary>
    public ObservableCollection<string> Providers { get; init; }

    /// <inheritdoc />
    public bool AreThemesInitialized => true;

    /// <inheritdoc />
    public ITheme UITheme => ThemeManager.ThemeManager.Current;

    /// <inheritdoc />
    public void InitializeThemes()
        => ThemeInitializer.Initialize(this);

    /// <inheritdoc />
    public void RequireThemeInitialization()
        => ThemeInitializationException.ThrowIf(!AreThemesInitialized);

    /// <summary>
    /// Initializes a new instance of <see cref="FontProviderChooser" />.
    /// </summary>
    public FontProviderChooser()
    {
        Providers = new();

        InitializeComponent();
        InitializeThemes();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Binds UI elements to show font providers.
    /// </summary>
    public void InitializeBinding() => FontProviders.ItemsSource = Providers;

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        if (FontProviders.SelectedItems.Count == 0)
        {
            MessageBoxCommon.ErrorOk("Please select a provider");

            return;
        }
        else
        {
            var provider = FontProviders.SelectedItems[0] as string ?? string.Empty;

            var pfb = new ProviderFontBrowser();
            pfb.InitializeBinding();

            foreach (string font in LocalFontManager.GetFontsFromCompany(provider))
            {
                pfb.Fonts.Add(font);
            }

            pfb.ShowDialog();

            if (pfb.SelectedFont != null)
            {
                Provider = pfb.SelectedFont ?? string.Empty;
            }

            Close();
        }
    }

    private void BrowseFontButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "TTF|*.ttf|TTC|*.ttc|WOFF|*.woff|WOFF2|*.woff2",
            Title = "Please select a font file",
            Multiselect = false
        };

        bool? success = dialog.ShowDialog();

        if (success == true)
        {
            Provider = dialog.FileName;
        }

        Close();
    }
}
