using System.Collections.Generic;
using System.Windows;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication;

public partial class EmployeeWindow : Window
{
    private readonly IEmployeeService employeeService;

    public EmployeeWindow(IEmployeeService employeeService)
    {
        InitializeComponent();
        this.employeeService = employeeService;
        getAllEmployees();
    }

    private async void getAllEmployees()
    {
        var employees = await employeeService.GetAllAsync();
        List<Employee> lst = new List<Employee>(employees);
        employeeGrid.ItemsSource = lst;
    }

    private async void getAllEmployees_Click(object sender, RoutedEventArgs e)
    {
        getAllEmployees();
    }

    private async void addEmployees_Click(object sender, RoutedEventArgs e)
    {
        var employee = new Employee { };
        employee = await employeeService.AddAsync(employee);
        getAllEmployees();
    }

    private async void deleteEmployees_Click(object sender, RoutedEventArgs e)
    {
        if(employeeGrid.SelectedIndex != -1)
        {
            Employee employee = (Employee)employeeGrid.SelectedItem;
            await employeeService.DeleteAsync(employee.Id);
            getAllEmployees();
        }
        else
        {
            MessageBox.Show("ERROR. Select employee to delete.");
        }
    }
}
