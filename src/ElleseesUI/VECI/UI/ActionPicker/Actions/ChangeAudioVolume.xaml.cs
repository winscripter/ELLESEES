using ElleseesUI.Audio;
using ElleseesUI.Core;
using ElleseesUI.Extensions;
using System.Windows;

namespace ElleseesUI.VECI.UI.ActionPicker.Actions;

/// <summary>
/// Interaction logic for ChangeAudioVolume.xaml
/// </summary>
public partial class ChangeAudioVolume : Window
{
    /// <summary>
    /// Output Volume returned by this dialog,
    /// </summary>
    public Volume? ReturnedVolume { get; private set; } = null;

    /// <summary>
    /// Duration where the changed volume starts to take its effect.
    /// </summary>
    public TimeSpan? Start { get; private set; } = null;

    /// <summary>
    /// Duration where the changed volume stops.
    /// </summary>
    public TimeSpan? End { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="ChangeAudioVolume" />.
    /// </summary>
    public ChangeAudioVolume()
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
        bool start_parse_success = StringExtensions.TryFormatToTimeSpan(StartTextBox.Text, out TimeSpan start);
        bool end_parse_success = StringExtensions.TryFormatToTimeSpan(EndTextBox.Text, out TimeSpan end);
        
        if (!start_parse_success)
        {
            MessageBoxCommon.ErrorOk("The Start field contains an invalid timestamp.");

            return;
        }

        if (!end_parse_success)
        {
            MessageBoxCommon.ErrorOk("The End field contains an invalid timestamp.");

            return;
        }

        bool volume_parse_success = Volume.TryParse(VolumeTextBox.Text, out Volume? vol);

        if (!volume_parse_success)
        {
            MessageBoxCommon.ErrorOk("The Volume field is invalid.");

            return;
        }

        if (start <= end)
        {
            MessageBoxCommon.ErrorOk("The Start timestamp can't be less than or equal to the End timestamp.");

            return;
        }

        this.ReturnedVolume = vol!;
        this.Start = start;
        this.End = end;

        Close();
    }
}
