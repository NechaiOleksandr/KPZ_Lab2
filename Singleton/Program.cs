public sealed class Authenticator
{
    private static readonly Lazy<Authenticator> _instance =
        new Lazy<Authenticator>(() => new Authenticator());

    private Authenticator()
    {
        Console.WriteLine("Екземпляр Authenticator створено вперше.");
    }

    public static Authenticator Instance => _instance.Value;

    public void Authenticate(string user)
    {
        Console.WriteLine($"Користувач {user} успішно пройшов перевірку.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Тестування Singleton");

        Authenticator auth1 = Authenticator.Instance;
        Authenticator auth2 = Authenticator.Instance;

        if (ReferenceEquals(auth1, auth2))
        {
            Console.WriteLine("Результат: Обидва об'єкти ідентичні (auth1 == auth2).");
        }

        Console.WriteLine("\nТестування в багатопотоковості");
        Parallel.Invoke(
            () => AccessSingleton("Потік 1"),
            () => AccessSingleton("Потік 2"),
            () => AccessSingleton("Потік 3")
        );
    }

    static void AccessSingleton(string threadName)
    {
        var auth = Authenticator.Instance;
        Console.WriteLine($"{threadName} отримав доступ до {auth.GetHashCode()}");
        auth.Authenticate(threadName);
    }
}