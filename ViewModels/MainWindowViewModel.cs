using System.Collections.ObjectModel;

namespace CommandSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    ///  This collection will store what the computer said
    /// </summary>
    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    // Just a helper to add content to ConversationLog
    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
}
