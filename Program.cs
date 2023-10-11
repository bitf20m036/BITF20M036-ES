using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

class Employee
{
    public long ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PrimaryPhoneNumber { get; set; }
    public string SecondaryPhoneNumber { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}

class EmployeeDataAccess
{
    private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SC\\source\\repos\\ConsoleApp2\\ConsoleApp2\\AssignmentFive.mdf;Integrated Security=True";

    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = new List<Employee>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        ID = (long)reader["ID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PrimaryPhoneNumber = reader["PrimaryPhoneNumber"].ToString(),
                        SecondaryPhoneNumber = reader["SecondaryPhoneNumber"].ToString(),
                        CreatedBy = reader["CreatedBy"].ToString(),
                        CreatedOn = (DateTime)reader["CreatedOn"],
                        ModifiedBy = reader["ModifiedBy"].ToString(),
                        ModifiedOn = reader["ModifiedOn"] == DBNull.Value ? null : (DateTime?)reader["ModifiedOn"],
                    });
                }
            }
        }
        return employees;
    }

    public void InsertEmployee(Employee employee)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn) " +
                "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", employee.PrimaryPhoneNumber);
            command.Parameters.AddWithValue("@SecondaryPhoneNumber", employee.SecondaryPhoneNumber);
            command.Parameters.AddWithValue("@CreatedBy", employee.CreatedBy);
            command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
            command.ExecuteNonQuery();
        }
    }

    public void DeleteEmployee(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Employees WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
        }
    }

    public Employee GetEmployeeById(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Employees WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Employee
                    {
                        ID = (long)reader["ID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PrimaryPhoneNumber = reader["PrimaryPhoneNumber"].ToString(),
                        SecondaryPhoneNumber = reader["SecondaryPhoneNumber"].ToString(),
                        CreatedBy = reader["CreatedBy"].ToString(),
                        CreatedOn = (DateTime)reader["CreatedOn"],
                        ModifiedBy = reader["ModifiedBy"].ToString(),
                        ModifiedOn = reader["ModifiedOn"] == DBNull.Value ? null : (DateTime?)reader["ModifiedOn"],
                    };
                }
                return null;
            }
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, " +
                "Email = @Email, PrimaryPhoneNumber = @PrimaryPhoneNumber, " +
                "SecondaryPhoneNumber = @SecondaryPhoneNumber, CreatedBy = @CreatedBy, " +
                "CreatedOn = @CreatedOn, ModifiedBy = @ModifiedBy, ModifiedOn = @ModifiedOn " +
                "WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", employee.ID);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", employee.PrimaryPhoneNumber);
            command.Parameters.AddWithValue("@SecondaryPhoneNumber", employee.SecondaryPhoneNumber);
            command.Parameters.AddWithValue("@CreatedBy", employee.CreatedBy);
            command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
            command.Parameters.AddWithValue("@ModifiedBy", employee.ModifiedBy);
            command.Parameters.AddWithValue("@ModifiedOn", employee.ModifiedOn);
            command.ExecuteNonQuery();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeDataAccess dataAccess = new EmployeeDataAccess();

        while (true)
        {
            Console.WriteLine("1. Show all employees present in table");
            Console.WriteLine("2. Add an employee in table");
            Console.WriteLine("3. Delete an employee from table");
            Console.WriteLine("4. Update an employee in table");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    List<Employee> employees = dataAccess.GetAllEmployees();
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.ID}, FirstName: {employee.FirstName}, LastName: {employee.LastName}, Email: {employee.Email}, PrimaryPhoneNumber: {employee.PrimaryPhoneNumber}, SecondaryPhoneNumber: {employee.SecondaryPhoneNumber}, CreatedBy: {employee.CreatedBy}, CreatedOn: {employee.CreatedOn}, ModifiedBy: {employee.ModifiedBy}, ModifiedOn: {employee.ModifiedOn}");
                    }
                    break;
                case 2:
                    Console.Write("Enter FirstName: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter LastName: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter PrimaryPhoneNumber: ");
                    string primaryPhoneNumber = Console.ReadLine();
                    Console.Write("Enter SecondaryPhoneNumber (optional): ");
                    string secondaryPhoneNumber = Console.ReadLine();
                    Console.Write("Enter CreatedBy: ");
                    string createdBy = Console.ReadLine();
                    DateTime createdOn = DateTime.Now;
                    Employee newEmployee = new Employee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        PrimaryPhoneNumber = primaryPhoneNumber,
                        SecondaryPhoneNumber = string.IsNullOrEmpty(secondaryPhoneNumber) ? null : secondaryPhoneNumber,
                        CreatedBy = createdBy,
                        CreatedOn = createdOn
                    };

                    dataAccess.InsertEmployee(newEmployee);
                    Console.WriteLine("Employee added successfully in table.");
                    break;

                case 3:
                    Console.Write("Enter the ID of the employee to delete: ");
                    long employeeIdToDelete = long.Parse(Console.ReadLine());
                    dataAccess.DeleteEmployee(employeeIdToDelete);
                    Console.WriteLine("Employee deleted successfully from table.");
                    break;

                case 4:
                    Console.Write("Enter the ID of the employee to update: ");
                    long employeeIdToUpdate = long.Parse(Console.ReadLine());

                    Employee existingEmployee = dataAccess.GetEmployeeById(employeeIdToUpdate);

                    if (existingEmployee == null)
                    {
                        Console.WriteLine("Employee not found in table.");
                    }
                    else
                    {
                        Console.Write("Enter updated FirstName: ");
                        existingEmployee.FirstName = Console.ReadLine();
                        Console.Write("Enter updated LastName: ");
                        existingEmployee.LastName = Console.ReadLine();
                        Console.Write("Enter updated Email: ");
                        existingEmployee.Email = Console.ReadLine();
                        Console.Write("Enter updated PrimaryPhoneNumber: ");
                        existingEmployee.PrimaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter updated SecondaryPhoneNumber (optional): ");
                        string updatedSecondaryPhoneNumber = Console.ReadLine();
                        existingEmployee.SecondaryPhoneNumber = string.IsNullOrEmpty(updatedSecondaryPhoneNumber) ? null : updatedSecondaryPhoneNumber;
                       
                        existingEmployee.ModifiedBy = existingEmployee.FirstName;
                        existingEmployee.ModifiedOn = DateTime.Now; 

                        dataAccess.UpdateEmployee(existingEmployee);
                        Console.WriteLine("Employee updated successfully in table.");
                    }
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice!!! Please try again.");
                    break;
            }
        }
    }
}

