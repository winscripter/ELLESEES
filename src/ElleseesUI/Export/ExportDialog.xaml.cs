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

using Ellesees.Base.Logging;
using ElleseesUI.Core;
using ElleseesUI.Generator;
using ElleseesUI.ProjectInfrastructure;
using System.Diagnostics;
using System.Windows;

namespace ElleseesUI.Export;

/// <summary>
/// Interaction logic for ExportDialog.xaml
/// </summary>
public partial class ExportDialog : Window
{
    internal VideoProject? Project { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ExportDialog" />.
    /// </summary>
    public ExportDialog()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Event handler for the Close button.
    /// </summary>
    protected void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Event handler for the "Let's begin!" button.
    /// </summary>
    protected async void OnBeginClick(object sender, RoutedEventArgs e)
    {
        GenerateERDFiles();

        var process = new Process();
        process.StartInfo.FileName = "Renderer.exe";
        process.StartInfo.Arguments = $"--input \"{Path.Combine(Project!.AbsolutePath, "RenderingData", "RenderingData_1.erd")}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardOutput = true;

        process.Start();
        process.BeginOutputReadLine();

        process.OutputDataReceived += new DataReceivedEventHandler((e, s) =>
        {
            OutputText.Dispatcher.Invoke(() =>
            {
                OutputText.Text += $"{s.Data}\n";
            });
        });

        await process.WaitForExitAsync();
    }

    private void GenerateERDFiles()
    {
        try
        {
            if (Project == null)
            {
                MessageBoxCommon.ErrorOk($"Please load a project first to generate ERDs.");

                return;
            }

            var generator = new ProjectToErdGenerator(Project!);

            foreach (KeyValuePair<string, string> erds in generator.ErdFiles)
            {
                string erdDirPath = Path.Combine(Project!.AbsolutePath, "RenderingData");

                if (!Directory.Exists(erdDirPath))
                {
                    Directory.CreateDirectory(erdDirPath);
                }
                else
                {
                    foreach (string file in Directory.GetFiles(erdDirPath))
                    {
                        File.Delete(file);
                    }
                }

                File.AppendAllText(Path.Combine(erdDirPath, erds.Key), erds.Value);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);
            throw;
        }
    }
}
