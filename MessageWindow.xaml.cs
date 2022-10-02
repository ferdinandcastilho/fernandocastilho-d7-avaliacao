using System.ComponentModel;
using System.Windows;

namespace LoginScreenApp;

public partial class MessageWindow : Window, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _message;
    public string Message
    {
        get => _message;
        set { _message = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message))); }
    }

    public MessageWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

}