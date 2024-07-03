using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;

namespace CommandSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// This command will ask HAL-9000 to open the pod bay doors
    /// </summary>
    public ICommand OpenThePodBayDoorsDirectCommand { get; }

    private string? _RobotName;

    /// <summary>
    ///  This collection will store what the computer said
    /// </summary>
    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    // Just a helper to add content to ConversationLog
    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }

    /// <summary>
    /// The name of a robot. If the name is null or empty, there is no other robot present.
    /// </summary>
    public string? RobotName
    {
        get => _RobotName;
        set => this.RaiseAndSetIfChanged(ref _RobotName, value);
    }
}
