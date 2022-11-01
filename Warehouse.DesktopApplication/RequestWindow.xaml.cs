using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication;

public partial class RequestWindow : Window
{
    private readonly IRequestService requestService;

    public RequestWindow(IRequestService requestService)
    {
        InitializeComponent();
        this.requestService = requestService;
        getAllRequest();
    }

    private async void getAllRequest()
    {
        var request = await requestService.GetAllAsync();
        List<Request> lst = new List<Request>(request);
        requestGrid.ItemsSource = lst;
    }

    private async void getAllRequests_Click(object sender, RoutedEventArgs e)
    {
        getAllRequest();
    }

    private async void findRequest_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(requestIdTextBox.Text))
            {
                var request = new Request { };
                request = await requestService.GetAsync(Convert.ToInt32(requestIdTextBox.Text));
                List<Request> lst = new List<Request>();
                lst.Add(request);
                requestGrid.ItemsSource = lst;
            }
        }
        catch
        {
            MessageBox.Show("Incorect data");
        }
    }

    private async void addRequest_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var request = new Request { };
            request.TargetDate = Convert.ToDateTime(expyryTimeTexBox.Text);
            request.EmployeeId = Convert.ToInt32(employeeIdTexBox.Text);
            request.ContractId = Convert.ToInt32(contractIdTexBox.Text);

            await requestService.AddAsync(request);
            getAllRequest();
        }
        catch
        {
            MessageBox.Show("ERROR. Incorrect data");
        }
    }

    private async void updateRequest_Click(object sender, RoutedEventArgs e)
    {
        if (requestGrid.SelectedIndex != -1)
        {
            Request request = (Request)requestGrid.SelectedItem;
            request.TargetDate = Convert.ToDateTime(expyryTimeTexBox.Text);
            request.EmployeeId = Convert.ToInt32(employeeIdTexBox.Text);
            request.ContractId = Convert.ToInt32(contractIdTexBox.Text);

            await requestService.UpdateAsync(request);
            getAllRequest();
        }
        else
        {
            MessageBox.Show("ERROR. Not correct data.");
        }
    }

    private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (requestGrid.SelectedIndex != -1)
        {
            Request request = (Request)requestGrid.SelectedItem;

            expyryTimeTexBox.Text = request.TargetDate.ToString();
            employeeIdTexBox.Text = request.EmployeeId.ToString();
            contractIdTexBox.Text = request.ContractId.ToString();
        }
    }

    private void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}
