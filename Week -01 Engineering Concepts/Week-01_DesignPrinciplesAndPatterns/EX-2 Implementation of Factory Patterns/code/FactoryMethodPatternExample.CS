using System;

// Interfaces
public interface WordDocument
{
    void open();
}

public interface PdfDocument
{
    void read();
}

public interface ExcelDocument
{
    void write();
}

// Concrete Implementations
public class WordFile : WordDocument
{
    public void open()
    {
        Console.WriteLine("Opening the Word document.");
    }
}

public class PdfFile : PdfDocument
{
    public void read()
    {
        Console.WriteLine("Reading the PDF document.");
    }
}

public class ExcelFile : ExcelDocument
{
    public void write()
    {
        Console.WriteLine("Writing into the Excel document.");
    }
}

//  Abstract Factory
public abstract class DocumentFactory
{
    public abstract object CreateDocument();
}

//  Concrete Factories
public class WordFactory : DocumentFactory
{
    public override object CreateDocument()
    {
        return new WordFile();
    }
}

public class PdfFactory : DocumentFactory
{
    public override object CreateDocument()
    {
        return new PdfFile();
    }
}

public class ExcelFactory : DocumentFactory
{
    public override object CreateDocument()
    {
        return new ExcelFile();
    }
}

// Test Class
public class FactoryTest
{
    public void Run()
    {
        DocumentFactory wordFactory = new WordFactory();
        WordDocument word = (WordDocument)wordFactory.CreateDocument();
        word.open();

        DocumentFactory pdfFactory = new PdfFactory();
        PdfDocument pdf = (PdfDocument)pdfFactory.CreateDocument();
        pdf.read();

        DocumentFactory excelFactory = new ExcelFactory();
        ExcelDocument excel = (ExcelDocument)excelFactory.CreateDocument();
        excel.write();
    }
}

//  Main Class
class FactoryPattern
{
    static void Main(string[] args)
    {
        FactoryTest test = new FactoryTest();
        test.Run();
    }
}
