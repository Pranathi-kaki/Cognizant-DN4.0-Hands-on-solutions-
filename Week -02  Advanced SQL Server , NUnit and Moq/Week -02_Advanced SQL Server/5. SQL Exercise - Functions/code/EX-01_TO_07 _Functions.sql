
USE EmployeeManagementSystem;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Insert Sample Data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01');

SELECT * FROM Departments;
SELECT * FROM Employees;

-- Exercise 1: Scalar Function - Annual Salary

IF OBJECT_ID('fn_CalculateAnnualSalary', 'FN') IS NOT NULL
    DROP FUNCTION fn_CalculateAnnualSalary;
GO

CREATE FUNCTION fn_CalculateAnnualSalary (
    @MonthlySalary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @MonthlySalary * 12;
END;
GO

-- Exercise 2: Table-Valued Function - By Department

IF OBJECT_ID('fn_GetEmployeesByDepartment', 'IF') IS NOT NULL
    DROP FUNCTION fn_GetEmployeesByDepartment;
GO

CREATE FUNCTION fn_GetEmployeesByDepartment (
    @DeptID INT
)
RETURNS TABLE
AS
RETURN (
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DeptID
);
GO

-- Exercise 3: Scalar Function - Bonus

IF OBJECT_ID('fn_CalculateBonus', 'FN') IS NOT NULL
    DROP FUNCTION fn_CalculateBonus;
GO

CREATE FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.10;
END;
GO

-- Exercise 4: Modify Bonus Function to 15%

ALTER FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.15;
END;
GO

-- Exercise 5: Drop Bonus Function

DROP FUNCTION fn_CalculateBonus;
GO

-- Exercise 6: Execute fn_CalculateAnnualSalary for All Employees

SELECT 
    EmployeeID,
    FirstName,
    LastName,
    Salary AS MonthlySalary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;
GO

-- Exercise 7: Execute fn_CalculateAnnualSalary for EmployeeID = 1

SELECT 
    EmployeeID,
    FirstName,
    LastName,
    Salary AS MonthlySalary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees
WHERE EmployeeID = 1;
GO
