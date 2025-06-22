using System;

public class Logger
{
    private static Logger? Instance;

    private Logger()
    {
        Console.WriteLine("This is the Constructor for Logger");
    }

    public static Logger getinstance()
    {
        if (Instance == null)
        {
            Instance = new Logger();
        }
        return Instance;
    }

    public void WriteAudit(string action, string user)
    {
        Console.WriteLine($"Audit: User '{user}' performed action '{action}' at {DateTime.Now}");
    }
}

public class testSingleton
{
    public void Runtest()
    {
        Logger l1 = Logger.getinstance();
        l1.WriteAudit("Login", "Ashish");

        Logger l2 = Logger.getinstance();
        l2.WriteAudit("Profile creation", "Pooja");

        if (object.ReferenceEquals(l1, l2))
        {
            Console.WriteLine("✅ Test Passed: Singleton pattern is followed.");
        }
        else
        {
            Console.WriteLine("❌ Test Failed: Different instances.");
        }
    }
}

public class SingletonPattern
{
    public static void Main(string[] args)
    {
        testSingleton test = new testSingleton();
        test.Runtest();
    }
}
