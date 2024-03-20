using Ellesees.Base.Logging;
using ElleseesUI.Core;
using ElleseesUI.VECI.UI.Converters;
using ElleseesUI.VECI.UI.DisplayActions;
using ElleseesUI.VECI.UI.ActionPicker.Actions;
using System.Collections.ObjectModel;
using System.Windows;

namespace ElleseesUI.VECI.UI.ActionPicker;

/// <summary>
/// Interaction logic for ActionPickerDialog.xaml
/// </summary>
public partial class ActionPickerDialog : Window
{
    internal VECITaskKind? SelectedKind { get; set; } = null;
    internal string? SelectedArgs { get; set; } = null;
    internal bool DataReturned { get; private set; } = false;

    internal readonly ObservableCollection<IDisplayAction> _actions;
    internal bool RequiresChanges = false;

    internal VECIFile? CurrentProject { get; set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="ActionPickerDialog" />.
    /// </summary>
    public ActionPickerDialog()
    {
        InitializeComponent();
        _actions = new();
        _actions.BindToActions();
        ActionList.ItemsSource = _actions;
    }

    /// <summary>
    /// Event handler for the Close Button.
    /// </summary>
    protected void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Event handler for the Next button.
    /// </summary>
    protected void OnNextButtonClick(object sender, RoutedEventArgs e)
    {
        if (ActionList.SelectedItem is not IDisplayAction action)
        {
            MessageBoxCommon.ErrorOk("Please select an action first");
        }
        else
        {
            try
            {
                var window = StringToActionConverter.GetAction(action.GetType().Name);

                if (window is PushFileToStack pushToFileStack)
                {
                    pushToFileStack.File = this.CurrentProject;
                }

                window.ShowDialog();

                var data = WindowToDataConverter.ToData(window);

                if (data != null)
                {
                    this.SelectedKind = data.Value.taskKind;
                    this.SelectedArgs = data.Value.args;
                    this.DataReturned = true;

                    this.RequiresChanges = true;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);
                throw;
            }
        }
    }
}
