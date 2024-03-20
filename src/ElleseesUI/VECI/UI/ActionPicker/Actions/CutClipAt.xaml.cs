using ElleseesUI.Core;
using ElleseesUI.Extensions;
using System.Windows;

namespace ElleseesUI.VECI.UI.ActionPicker.Actions;

/// <summary>
/// Interaction logic for CutClipAt.xaml
/// </summary>
public partial class CutClipAt : Window
{
    /// <summary>
    /// Start timestamp returned by this dialog.
    /// </summary>
    public TimeSpan? Start { get; private set; } = null;

    /// <summary>
    /// End timestamp returned by this dialog.
    /// </summary>
    public TimeSpan? End { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="CutClipAt" />.
    /// </summary>
    public CutClipAt()
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
    /// Event handler for the OK button.
    /// </summary>
    protected void OnOKButtonClick(object sender, RoutedEventArgs e)
    {
        var startParseSuccess = StringExtensions.TryFormatToTimeSpan(StartTextBox.Text, out TimeSpan start);
        var endParseSuccess = StringExtensions.TryFormatToTimeSpan(EndTextBox.Text, out TimeSpan end);

        if (!startParseSuccess)
        {
            MessageBoxCommon.ErrorOk($"The Start field contains an invalid timestamp.");

            return;
        }

        if (!endParseSuccess)
        {
            MessageBoxCommon.ErrorOk($"The End field contains an invalid timestamp");

            return;
        }

        this.Start = start;
        this.End = end;

        Close();
    }
}
