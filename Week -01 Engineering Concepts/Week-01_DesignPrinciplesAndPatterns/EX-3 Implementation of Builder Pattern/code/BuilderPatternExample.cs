using System;

// Product class
public class Computer
{
    public string? CPU { get; }
    public string? RAM { get; }
    public string? Storage { get; }
    public string? GraphicsCard { get; }
    public string? OperatingSystem { get; }
    public string? PowerSupply { get; }
    public string? Motherboard { get; }

    private Computer(Builder builder)
    {
        CPU = builder.CPU;
        RAM = builder.RAM;
        Storage = builder.Storage;
        GraphicsCard = builder.GraphicsCard;
        OperatingSystem = builder.OperatingSystem;
        PowerSupply = builder.PowerSupply;
        Motherboard = builder.Motherboard;
    }

    // Nested Builder class
    public class Builder
    {
        public string? CPU { get; private set; }
        public string? RAM { get; private set; }
        public string? Storage { get; private set; }
        public string? GraphicsCard { get; private set; }
        public string? OperatingSystem { get; private set; }
        public string? PowerSupply { get; private set; }
        public string? Motherboard { get; private set; }

        public Builder SetCPU(string cpu) { CPU = cpu; return this; }
        public Builder SetRAM(string ram) { RAM = ram; return this; }
        public Builder SetStorage(string storage) { Storage = storage; return this; }
        public Builder SetGraphicsCard(string gpu) { GraphicsCard = gpu; return this; }
        public Builder SetOperatingSystem(string os) { OperatingSystem = os; return this; }
        public Builder SetPowerSupply(string psu) { PowerSupply = psu; return this; }
        public Builder SetMotherboard(string mb) { Motherboard = mb; return this; }

        public Computer Build()
        {
            return new Computer(this);
        }
    }

    public void DisplayConfig()
    {
        Console.WriteLine("Computer Configuration:");
        Console.WriteLine($"CPU: {CPU}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Storage: {Storage}");
        Console.WriteLine($"Graphics Card: {GraphicsCard}");
        Console.WriteLine($"Operating System: {OperatingSystem}");
        Console.WriteLine($"Power Supply: {PowerSupply}");
        Console.WriteLine($"Motherboard: {Motherboard}");
    }
}

// Test class
public class BuilderTest
{
    public void RunTest()
    {
        Computer gamingPC = new Computer.Builder()
            .SetCPU("Intel Core i9-13900K")
            .SetRAM("64GB DDR5")
            .SetStorage("2TB NVMe SSD")
            .SetGraphicsCard("NVIDIA RTX 4090")
            .SetOperatingSystem("Windows 11 Pro")
            .SetPowerSupply("850W Gold Certified PSU")
            .SetMotherboard("ASUS ROG Z790-E")
            .Build();

        gamingPC.DisplayConfig();

        Console.WriteLine("\n----------------------\n");

        Computer officePC = new Computer.Builder()
            .SetCPU("Intel Core i3-12100")
            .SetRAM("8GB DDR4")
            .SetStorage("512GB SSD")
            .SetOperatingSystem("Windows 10 Home")
            .SetPowerSupply("450W PSU")
            .SetMotherboard("Gigabyte H610M")
            .Build();

        officePC.DisplayConfig();
    }
}

// Main class
class BuilderPattern
{
    public static void Main(string[] args)
    {
        BuilderTest test = new BuilderTest();
        test.RunTest();
    }
}
