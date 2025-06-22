using System;

public interface PaymentProcessor
{
    void processPayment(string amount);
}

public class PayPalGateway
{
    public void MakeTransaction(string amount)
    {
        Console.WriteLine($"'PayPal' Transaction completed for {amount}");
    }
}

public class JuspayGateway
{
    public void ExecutePayment(string amount)
    {
        Console.WriteLine($"'Juspay' Payment of {amount} executed via Juspay.");
    }
}


public class PayPalAdapter : PaymentProcessor
{
    private PayPalGateway _paypal = new PayPalGateway();

    public void processPayment(string amount)
    {
        _paypal.MakeTransaction(amount);  
    }
}

public class JuspayAdapter : PaymentProcessor
{
    private JuspayGateway _juspay = new JuspayGateway();

    public void processPayment(string amount)
    {
        _juspay.ExecutePayment(amount);  
    }
}

public class AdapterTest
{
    public void RunTest()
    {
        PaymentProcessor paypal = new PayPalAdapter();
        PaymentProcessor juspay = new JuspayAdapter();

        paypal.processPayment("₹1000");
        juspay.processPayment("₹2000");
    }
}

public class AdapterPattern
{
    public static void Main(string[] args)
    {
        AdapterTest test = new AdapterTest();
        test.RunTest();
    }
}
