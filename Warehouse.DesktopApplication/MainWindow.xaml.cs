using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication;

public partial class MainWindow : Window
{
    private readonly IRequestService requestService;
    private readonly IContractService contractService;
    private readonly IEmployeeService employeeService;
    private readonly IContainerService containerService;
    private List<Employee> employeesList;

    public MainWindow(IRequestService requestService, IContractService contractService, IEmployeeService employeeService, IContainerService containerService)
    {
        InitializeComponent();
        this.requestService = requestService;
        this.contractService = contractService;
        this.containerService = containerService;
        this.employeeService = employeeService;
    }

    private async void getRequest()
    {
        if (!string.IsNullOrWhiteSpace(requestIdTextBox.Text))
        {
            try
            {
                var request = new Request { };
                request = await requestService.GetAsync(Convert.ToInt32(requestIdTextBox.Text));
                List<Request> lst = new List<Request>();
                lst.Add(request);
                requestGrid.ItemsSource = lst;
            }
            catch { }
        }
    }

    private async void getContract()
    {
        if (!string.IsNullOrWhiteSpace(contractIdTextBox.Text))
        {
            try
            {
                var contract = new Contract { };
                contract = await contractService.GetAsync(Convert.ToInt32(contractIdTextBox.Text));
                List<Contract> lst = new List<Contract>();
                lst.Add(contract);
                contractGrid.ItemsSource = lst;
            }
            catch { }
        }
    }

    private void RequestIdTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        getRequest();
    }

    private void contractIdTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        getContract();
    }

    private void requestRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (contractGrid.SelectedIndex != -1)
        {
            Request request = (Request)requestGrid.SelectedItem;
            UpdateRequestWindow updateRequestWindow = new UpdateRequestWindow(requestService, request);
            updateRequestWindow.Show();
        }
    }

    private void contractRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (contractGrid.SelectedIndex != -1)
        {
            Contract contract = (Contract)contractGrid.SelectedItem;
            UpdateContractWindow updateContractWindow = new UpdateContractWindow(contractService, contract);
            updateContractWindow.Show();
        }
    }

    private void openEmployeeWindow_Click(object sender, RoutedEventArgs e)
    {
        EmployeeWindow employeeWindow = new EmployeeWindow(employeeService);
        employeeWindow.Show();
    }

    private void openContractWindow_Click(object sender, RoutedEventArgs e)
    {
        ContractWindow contractWindow = new ContractWindow(contractService);
        contractWindow.Show();
    }

    private void openContainerWindow_Click(object sender, RoutedEventArgs e)
    {
        ContainerWindow containerWindow = new ContainerWindow(containerService);
        containerWindow.Show();
    }

    private void openRequestWindow_Click(object sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow(requestService);
        requestWindow.Show();
    }
    private void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}
