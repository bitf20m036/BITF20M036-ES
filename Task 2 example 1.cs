//Organization Hierarchy
using System;
using System.Collections.Generic;
public interface IOrganizationComponent
{
    void Display();
}
public class Employee : IOrganizationComponent
{
    private readonly string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public void Display()
    {
        Console.WriteLine($"Employee: {name}");
    }
}
public class Department : IOrganizationComponent
{
    private readonly string name;
    private readonly List<IOrganizationComponent> subordinates = new List<IOrganizationComponent>();

    public Department(string name)
    {
        this.name = name;
    }

    public void AddSubordinate(IOrganizationComponent subordinate)
    {
        subordinates.Add(subordinate);
    }

    public void Display()
    {
        Console.WriteLine($"Department: {name}");

        foreach (var subordinate in subordinates)
        {
            subordinate.Display();
        }
    }
    public static void Main()
    {
        var organization = new Department("Main Organization");

        var development = new Department("Development");
        development.AddSubordinate(new Employee("John"));
        development.AddSubordinate(new Employee("Alice"));

        var marketing = new Department("Marketing");
        marketing.AddSubordinate(new Employee("Bob"));
        marketing.AddSubordinate(new Employee("Eve"));

        organization.AddSubordinate(development);
        organization.AddSubordinate(marketing);

        organization.Display();
    }
}
