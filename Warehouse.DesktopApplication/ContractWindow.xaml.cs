using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication;

public partial class ContractWindow : Window
{
    private readonly IContractService contractService;
    private static Random random = new Random();

    public ContractWindow(IContractService contractService)
    {
        InitializeComponent();
        this.contractService = contractService;
        getAllContract();
    }

    private async void getAllContract()
    {
        var contract = await contractService.GetAllAsync();
        List<Contract> lst = new List<Contract>(contract);
        contractGrid.ItemsSource = lst;
    }

    private async void getAllContracts_Click(object sender, RoutedEventArgs e)
    {
        getAllContract();
    }

    private async void addNewContracts_Click(object sender, RoutedEventArgs e)
    {
        //Need to add a selection of containers
        var contract = new Contract { };
        contract.StartDate = Convert.ToDateTime(startDateCreateTextBox.Text);
        contract.ExpiryDate = Convert.ToDateTime(expiryDateCreateTextBox.Text);
        contract.Credential = RandomString(10);
        await contractService.AddAsync(contract);
        getAllContract();
    }

    private async void findContracts_Click(object sender, RoutedEventArgs e)
    {
        var contract = new Contract { };
        contract = await contractService.GetAsync(Convert.ToInt32(contractIdTextBox.Text));
        List<Contract> lst = new List<Contract>();
        lst.Add(contract);
        contractGrid.ItemsSource = lst;
    }

    private async void updateContracts_Click(object sender, RoutedEventArgs e)
    {
        if (contractGrid.SelectedIndex != -1)
        {
            Contract contract = (Contract)contractGrid.SelectedItem;
            contract.ExpiryDate = Convert.ToDateTime(expyryTimeTexBox.Text);
            await contractService.UpdateAsync(contract);
            getAllContract();
        }
        else
        {
            MessageBox.Show("ERROR. Not correct data.");
        }
    }

    private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (contractGrid.SelectedIndex != -1)
        {
            Contract contract = (Contract)contractGrid.SelectedItem;
            expyryTimeTexBox.Text = contract.ExpiryDate.ToString();
        }
    }

    private void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
