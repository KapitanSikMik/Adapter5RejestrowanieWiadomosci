
/// <summary>
/// Stary interfejs
/// </summary>
public class OldRegisterMessage
{
    private List<string> MessageList = new List<string>();

    public virtual void RegisterMessage(string message)
    {
        MessageList.Add(message);
    }

    public virtual void PrintMessages()
    {
        foreach (var item in MessageList)
        {
            Console.WriteLine(item);
        }
    }
}

/// <summary>
/// Nowy interfejs
/// </summary>
public interface INewMessageRegister
{
    void AddMessage(string message);
    void DisplayMessages();
}

/// <summary>
/// Adapter do dostosowania nowego interfejsu do starego
/// </summary>
public class NewToOldMessageAdapter : OldRegisterMessage
{
    private readonly INewMessageRegister _newMessageRegister;

    public NewToOldMessageAdapter(INewMessageRegister newMessageRegister)
    {
        _newMessageRegister = newMessageRegister;
    }

    public NewMessageRegister NewMessageRegister
    {
        get => default;
        set
        {
        }
    }

    public override void RegisterMessage(string message)
    {
        _newMessageRegister.AddMessage(message);
    }

    public override void PrintMessages()
    {
        _newMessageRegister.DisplayMessages();
    }
}

/// <summary>
/// Nowa implementacja interfejsu
/// </summary>
public class NewMessageRegister : INewMessageRegister
{
    private List<string> MessageList = new List<string>();

    public void AddMessage(string message)
    {
        MessageList.Add(message);
    }

    public void DisplayMessages()
    {
        foreach (var item in MessageList)
        {
            Console.WriteLine(item);
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var newMessageRegister = new NewMessageRegister();
        var adapter = new NewToOldMessageAdapter(newMessageRegister);

        adapter.RegisterMessage(Console.ReadLine());
        adapter.RegisterMessage(Console.ReadLine());
        adapter.RegisterMessage(Console.ReadLine());

        Console.WriteLine("Lista wiadomości z nowej biblioteki:");
        adapter.PrintMessages();
    }
}
