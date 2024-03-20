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
using ElleseesUI.VECI.Engagement;
using ElleseesUI.VECI.UI.ActionPicker;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ElleseesUI.VECI.UI;

/// <summary>
/// Interaction logic for VECIEditor.xaml
/// </summary>
public partial class VECIEditor : Window
{
    private VECIFile? _veci;
    private readonly EngagementStack _engagementStack;

    /// <summary>
    /// Initializes a new instance of <see cref="VECIEditor" />.
    /// </summary>
    public VECIEditor()
    {
        _engagementStack = new();

        InitializeComponent();

        _engagementStack.Do(new StateSnapshot
        {
            ExplanationText = this.Explanation.Text,
            VECISnapshot = this._veci
        });
    }

    internal void LoadVECI(VECIFile file)
    {
        _veci = file;

        Explanation.Text = VECICommandDescriptionBuilder.Build(_veci.Project!.Value.Tasks);
    }

    /// <summary>
    /// Event handler for the close button.
    /// </summary>
    protected void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        if (_veci is not null)
        {
            if (_veci.IsUnsaved)
            {
                MessageBoxResult result = MessageBoxCommon.WarnYesNoCancel("You have unsaved changes. Would you like to save them?");

                if (result == MessageBoxResult.Yes)
                {
                    _veci.Save();
                }
                else if (result == MessageBoxResult.No)
                {
                    Close();
                }
                else
                {
                    return;
                }
            }
        }

        Close();
    }

    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    /// <summary>
    /// Event handler for Add Action button.
    /// </summary>
    protected void OnAddActionButtonClick(object sender, RoutedEventArgs e)
    {
        ActionPickerDialog dialog = new()
        {
            CurrentProject = this._veci
        };

        dialog.ShowDialog();

        if (dialog.RequiresChanges)
        {
            AddPair(new VECIPair
            {
                Type = (ushort)dialog.SelectedKind!,
                Arguments = dialog.SelectedArgs!
            });

            Explanation.Text += VECICommandDescriptionBuilder.Build(new VECIPair[]
            {
                new()
                {
                    Type = (ushort)dialog.SelectedKind!,
                    Arguments = dialog.SelectedArgs!
                }
            });

            _engagementStack.Do(new StateSnapshot
            {
                ExplanationText = this.Explanation.Text,
                VECISnapshot = this._veci
            });
        }
    }

    private void AddPair(VECIPair pair)
    {
        if (_veci != null)
        {
            if (_veci.Project != null)
            {
                var pairs = new List<VECIPair>(_veci.Project.Value.Tasks)
                {
                    pair
                };

                _veci.SetTasks(pairs.ToArray());
            }
        }
    }

    private void OnGetFocus(object sender, EventArgs e)
    {
        TitleBar.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;
        MenuView.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;
    }

    private void OnLoseFocus(object sender, EventArgs e)
    {
        TitleBar.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#575757")!;
        MenuView.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#575757")!;
    }

    /// <summary>
    /// Event handler for the Undo button.
    /// </summary>
    protected void OnUndoClick(object sender, RoutedEventArgs e)
    {
        if (!_engagementStack.IsSuitableForUndo)
        {
            return;
        }

        var undoItem = _engagementStack.Undo();

        this.Explanation.Text = undoItem.ExplanationText;
        this._veci = undoItem.VECISnapshot;
    }

    /// <summary>
    /// Event handler for the Redo button.
    /// </summary>
    protected void OnRedoClick(object sender, RoutedEventArgs e)
    {
        if (!_engagementStack.IsSuitableForRedo)
        {
            return;
        }

        var redoItem = _engagementStack.Redo();

        this.Explanation.Text = redoItem.ExplanationText;
        this._veci = redoItem.VECISnapshot;
    }

    /// <summary>
    /// Event handler for "Add Video" under "Project".
    /// </summary>
    protected void OnAddVideoClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new()
        {
            Title = "Please select video files",
            Filter = "MP4|*.mp4|WMV|*.wmv|AVI|*.avi",
            Multiselect = true
        };

        if (dialog.ShowDialog() == true)
        {
            foreach (string file in dialog.FileNames)
            {
                File.Copy(file, Path.Combine(_veci!._projectDir!, _veci!.Project!.Value.DataDirectory, Path.GetFileName(file)));
            }
        }
    }

    /// <summary>
    /// Event handler for "Add Image" under "Project".
    /// </summary>
    protected void OnAddImageClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new()
        {
            Title = "Please select image files",
            Filter = "PNG|*.png|JPG|*.jpg|JPEG|*.jpeg|QOI|*.qoi|TIFF|*.tiff|TGA|*.tga|BMP|*.bmp",
            Multiselect = true
        };

        if (dialog.ShowDialog() == true)
        {
            foreach (string file in dialog.FileNames)
            {
                File.Copy(file, Path.Combine(_veci!._projectDir!, _veci!.Project!.Value.DataDirectory, Path.GetFileName(file)));
            }
        }
    }

    /// <summary>
    /// Event handler for "Add Audio" under "Project".
    /// </summary>
    protected void OnAddAudioClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new()
        {
            Title = "Please select audio files",
            Filter = "MP3|*.mp3|OGG|*.ogg|AAC|*.aac",
            Multiselect = true
        };

        if (dialog.ShowDialog() == true)
        {
            foreach (string file in dialog.FileNames)
            {
                File.Copy(file, Path.Combine(_veci!._projectDir!, _veci!.Project!.Value.DataDirectory, Path.GetFileName(file)));
            }
        }
    }

    /// <summary>
    /// Event handler for the "Export" button under "Project".
    /// </summary>
    protected void OnBeginExportClick(object sender, RoutedEventArgs e)
    {
        if (MessageBoxCommon.WarnYesNo("Are you sure you want to begin the export process?") == MessageBoxResult.No)
        {
            return;
        }

        var proc = new Process();
        proc.StartInfo.FileName = "./VECIRendererService/VECIRenderer.exe";
        proc.StartInfo.Arguments = $"\"{_veci!._projectDir!}\"";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = true;

        proc.Start();
        proc.WaitForExit();

        MessageBoxCommon.InfoOk($"Export completed. Hooray!\n\nOutput files can be found in \"{Path.Combine(_veci!._projectDir!, _veci!.Project!.Value.DataDirectory)}\".");
    }
}
