using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

using LoginScreenApp.DataContext.Repositories;

namespace LoginScreenApp;

public partial class MainWindow : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IUserRepository _userRepository;

    private string _userName;
    public string UserName
    {
        get => _userName;
        set { _userName = value; PropertyChanged?.Invoke(this, new(nameof(UserName))); }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set { _password = value; PropertyChanged?.Invoke(this, new(nameof(Password))); }
    }

    public MainWindow()
    {
        DataContext = this;
        _userRepository = App.GetService<IUserRepository>();
        InitializeComponent();
    }

    private void AuthenticateUser(object sender, RoutedEventArgs e)
    {
        bool validUser = _userRepository.AuthenticateUser(UserName, Password);

        string message = validUser ? "Usuário Autenticado!" : "Credenciais Inválidas";

        UserName = string.Empty;
        Password = string.Empty;

        var responseWindow = App.GetService<MessageWindow>();
        responseWindow.Message = message;

        responseWindow.ShowDialog();

    }
}
