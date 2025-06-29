CREATE DATABASE EmployeeManagementSystem;
GO
use EmployeeManagementSystem;
GO


CREATE TABLE Departments ( 
    DepartmentID INT PRIMARY KEY, 
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees ( 
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY, 
    FirstName VARCHAR(50), 
    LastName VARCHAR(50), 
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
    Salary DECIMAL(10,2), 
    JoinDate DATE
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing');

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES 
('John', 'Doe', 1, 5000.00, '2020-01-15'), 
('Jane', 'Smith', 2, 6000.00, '2019-03-22'), 
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
('Emily', 'Davis', 4, 5500.00, '2021-11-05');

-- Stored Procedure to Get Employees by Department
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DepartmentID;
END;
GO

-- Stored Procedure to Insert Employee
CREATE PROCEDURE sp_InsertEmployee 
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @DepartmentID INT, 
    @Salary DECIMAL(10,2), 
    @JoinDate DATE 
AS 
BEGIN 
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate); 
END;
GO

-- Call to Get Employees from IT Department
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;

-- Call to Insert New Employee
EXEC sp_InsertEmployee 
    @FirstName = 'Alice',
    @LastName = 'Brown',
    @DepartmentID = 1,
    @Salary = 5200.00,
    @JoinDate = '2022-08-01';
