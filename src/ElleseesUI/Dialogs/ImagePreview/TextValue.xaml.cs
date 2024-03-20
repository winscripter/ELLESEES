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

using Ellesees.Base;
using Ellesees.Base.Logging;
using ElleseesUI.Core;
using ElleseesUI.Extensions;
using SixLabors.ImageSharp.PixelFormats;
using System.Windows;
using System.Windows.Controls;
using TextStyle = SixLabors.Fonts.FontStyle;

namespace ElleseesUI.Dialogs.ImagePreview
{
    /// <summary>
    /// Interaction logic for TextValue.xaml
    /// </summary>
    public partial class TextValue : Window
    {
        /// <summary>
        /// Path to the font.
        /// </summary>
        public string FontPath { get; set; } = "./fonts/Google/Space Grotesk/SpaceGrotesk-Medium.ttf";

        /// <summary>
        /// Foreground of the text.
        /// </summary>
        public Rgba32 TextForeground { get; set; } = new(0F, 0F, 0F, 1F);

        /// <summary>
        /// Shadow of the text.
        /// </summary>
        public Shadow TextShadow { get; set; } = new(new Rgba32(0F, 0F, 0F, 1F), 4);

        /// <summary>
        /// Should the text shadow be allowed?
        /// </summary>
        public bool AllowTextShadow { get; set; } = false;

        /// <summary>
        /// Style of the font.
        /// </summary>
        public TextStyle TextFontStyle { get; set; } = TextStyle.Regular;

        /// <summary>
        /// Size of the text.
        /// </summary>
        public int TextSize { get; set; } = 20;

        /// <summary>
        /// X Coordinate where this text is displayed.
        /// </summary>
        public int X { get; set; } = 64;

        /// <summary>
        /// Y Coordinate where this text is displayed.
        /// </summary>
        public int Y { get; set; } = 64;

        /// <summary>
        /// Display text.
        /// </summary>
        public string Text { get; set; } = "The quick brown fox jumps over the lazy dog.";

        /// <summary>
        /// Signifies where data was successfully submitted by the user.
        /// </summary>
        public bool DataReturned { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of <see cref="TextValue" />.
        /// </summary>
        public TextValue()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var color = ColorPickerCaller.Call();

            if (color is not null)
            {
                RgbaColor.Text = $"rgba({color.Value.R}, {color.Value.G}, {color.Value.B}, {color.Value.GetAlpha()})";
                TextForeground = new(Convert.ToSingle(color.Value.R),
                                     Convert.ToSingle(color.Value.G),
                                     Convert.ToSingle(color.Value.B),
                                     color.Value.GetAlpha());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var font = FontChooser.GetFont();

                if (font is not null)
                {
                    FontName.Text = FontPath = font;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Error);

                MessageBoxCommon.ErrorOk("An error has occurred while trying to select a font. We're very sorry for the inconvenience. :(\n\nDetails can be found in the log file Ellesees.log.");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var dlg = new TextShadowOptions();
            dlg.ShowDialog();

            if (dlg.Color != null)
            {
                var r32 = dlg.Color ?? new(0F, 0F, 0F, 1F);
                r32.A = Convert.ToByte(dlg.ActualAlpha * 255);

                ShadowColorText.Text = $"rgba({r32.R}, {r32.G}, {r32.B}, {dlg.ActualAlpha})";

                SigmaText.Text = dlg.Sigma.ToString();
                TextShadow = new(r32, dlg.Sigma ?? 4);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (FontStyleBox.SelectedItem == null)
            {
                MessageBoxCommon.ErrorOk("Please select a font style");

                return;
            }

            try
            {
                var fontPath = FontName.Text;
                var allowTextShadow = AllowTextShadowCheckbox.IsChecked ?? false;
                var fontSize = FontSizeText.Text;

                var content = ((ComboBoxItem)FontStyleBox.SelectedItem).Content.ToString();
                var fontStyle = content switch
                {
                    "Regular" => TextStyle.Regular,
                    "Bold" => TextStyle.Bold,
                    "Italic" => TextStyle.Italic,
                    "Italic and Bold" => TextStyle.BoldItalic,
                    _ => throw new InvalidOperationException($"Invalid font style choice, got \"{content}\"")
                };
                var startx = StartX.Text;
                var starty = StartY.Text;
                var text = InputText.Text;

                var xs = int.TryParse(startx, out int x);
                var ys = int.TryParse(starty, out int y);
                var fss = int.TryParse(fontSize, out int fs);

                if (!xs)
                {
                    MessageBoxCommon.ErrorOk("The Start X field is invalid: Value must be valid integer (e.g. 1, 2, 5, etc)");

                    return;
                }

                if (!ys)
                {
                    MessageBoxCommon.ErrorOk("The Start Y field is invalid: Value must be valid integer (e.g. 1, 2, 5, etc)");

                    return;
                }

                if (!fss)
                {
                    MessageBoxCommon.ErrorOk("The Font size field is invalid: Value must be valid integer (e.g. 1, 2, 5, etc)");

                    return;
                }

                if (x < 0 || y < 0)
                {
                    if (MessageBoxCommon.WarnYesNo("Are you sure you want to use negative values for either X or Y values? The text may be out of bounds, and thus invisible.") == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                FontPath = fontPath;
                AllowTextShadow = allowTextShadow;
                TextSize = fs;
                TextFontStyle = fontStyle;
                X = x;
                Y = y;
                Text = text;

                DataReturned = true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Error);

                MessageBoxCommon.ErrorOk("Could not apply text. We're sorry. :(\n\nDetails can be found in the log file Ellesees.log.");
            }

            Close();
            return;
        }
    }
}
