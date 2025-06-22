using System;

public class Employee
{
    public int EmployeeId;
    public string Name;
    public string Position;
    public double Salary;

    public Employee(int id, string name, string position, double salary)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: ₹{Salary}");
    }
}

public class EmployeeManagement
{
    private Employee[] employees;
    private int count;

    public EmployeeManagement(int size)
    {
        employees = new Employee[size];
        count = 0;
    }

    public void AddEmployee(Employee emp)
    {
        if (count < employees.Length)
        {
            employees[count++] = emp;
            Console.WriteLine(" Employee added successfully.");
        }
        else
        {
            Console.WriteLine(" Array full! Cannot add more employees.");
        }
    }

    public void DisplayEmployees()
    {
        Console.WriteLine("\nEmployee List:");
        for (int i = 0; i < count; i++)
        {
            employees[i].Display();
        }
    }

    public void SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                Console.WriteLine("\n Employee Found:");
                employees[i].Display();
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }

    public void DeleteEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                // Shift remaining elements left
                for (int j = i; j < count - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }
                employees[--count] = null;
                Console.WriteLine("Employee deleted.");
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }
}

public class Program
{
    public static void Main()
    {
        EmployeeManagement system = new EmployeeManagement(5);

        system.AddEmployee(new Employee(101, "Alice", "Manager", 75000));
        system.AddEmployee(new Employee(102, "Bob", "Developer", 60000));
        system.AddEmployee(new Employee(103, "Charlie", "HR", 50000));

        system.DisplayEmployees();

        system.SearchEmployee(102);

        system.DeleteEmployee(102);

        system.DisplayEmployees();
    }
}
