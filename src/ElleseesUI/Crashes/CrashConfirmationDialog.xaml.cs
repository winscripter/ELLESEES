using System.Diagnostics;
using System.Windows;

namespace ElleseesUI.Crashes;

/// <summary>
/// Interaction logic for CrashConfirmationDialog.xaml
/// </summary>
public partial class CrashConfirmationDialog : Window
{
    /// <summary>
    /// Initializes a new instance of <see cref="CrashConfirmationDialog" />.
    /// </summary>
    public CrashConfirmationDialog()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Event handler for "Yes - Continue Startup" button.
    /// </summary>
    protected void OnContinueStartupClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Event handler for "No - Send a bug report" button.
    /// </summary>
    protected void OnSendBugReportClick(object sender, RoutedEventArgs e)
    {
        var proc = new Process();
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.FileName = "https://github.com/winscripter/ELLESEES/issues";
        proc.Start();

        Close();
    }
}
