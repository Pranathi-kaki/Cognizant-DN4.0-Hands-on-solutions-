using System;

public interface Notifier
{
    void send(string message);
}

public class EmailNotifier : Notifier
{
    public void send(string message)
    {
        Console.WriteLine($"'Email' Notification sent: {message}");
    }
}

public abstract class NotifierDecorator : Notifier
{
    protected Notifier original_msg;

    public NotifierDecorator(Notifier notifier)
    {
        original_msg = notifier;
    }

    public virtual void send(string message)
    {
        original_msg.send(message); // Forwarding call to base notifier
    }
}

public class SMSNotifierDecorator : NotifierDecorator
{
    public SMSNotifierDecorator(Notifier notifier) : base(notifier) { }

    public override void send(string message)
    {
        base.send(message);
        Console.WriteLine($"'SMS' Notification sent: {message}");
    }
}

public class SlackNotifierDecorator : NotifierDecorator
{
    public SlackNotifierDecorator(Notifier notifier) : base(notifier) { }

    public override void send(string message)
    {
        base.send(message);
        Console.WriteLine($"'Slack' Notification sent: {message}");
    }
}

public class DecoratorTest
{
    public void RunTest()
    {
        // Base notifier
        Notifier notifier = new EmailNotifier();

        // Add SMS notification
        notifier = new SMSNotifierDecorator(notifier);

        // Add Slack notification
        notifier = new SlackNotifierDecorator(notifier);

        // Send message via all channels
        notifier.send("System Maintenance at 10 PM tonight.");
    }
}


public class DecoratorPattern
{
    public static void Main(string[] args)
    {
        DecoratorTest test = new DecoratorTest();
        test.RunTest();
    }
}
