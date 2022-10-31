using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Windows;
using System.Windows.Controls;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication;

public partial class MainWindow : Window
{
    private readonly IContainerService containerService;

    public MainWindow(IContainerService containerService)
    {
        InitializeComponent();
        this.containerService = containerService;
    }

    private async void getIntermediateBulkContainers_Click(object sender, RoutedEventArgs e)
    {
        var container = await containerService.GetAllAsync();
        List<Container> lst = new List<Container>(container);
        containerGrid.ItemsSource = lst;
    }

    private async void getRefrigeratedContainers_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void getFreightContainers_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void findContainer_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void addContainer_Click(object sender, RoutedEventArgs e)
    {
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer()
        {
            ContractId = 1,
            Name = "Test",
            Price = 1000,
            InternalVolume = 100,
            MaxTemperature = 100, 
            MinTemperature = 10,
            ExternalDimensions = new ExternalDimensions()
            {
                Height = 10,
                Width = 10,
                Length = 10
            }
        };
        await containerService.AddAsync(refrigeratedContainer);
    }

    private async void updateContainer_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void getContracts_Click(object sender, RoutedEventArgs e)
    {
        // GetAll
        //var contracts = await contractService.GetAllAsync();

        // Post
        //var contract = new Contract { Credential = "asdf" };
        //contract = await contractService.AddAsync(contract);

        // Put
        //contract.Credential += "FromPut";
        //await contractService.UpdateAsync(contract);

        // Get
        //contract = await contractService.GetAsync(contract.Id);
        //containers.Text = $"[{contracts.Length} + {contract!.Id}] => {contract.Credential}";

        // Delete
        //await contractService.DeleteAsync(contract.Id);
    }

    private void FreightRadioButton_Checked(object sender, RoutedEventArgs e)
    {
        //isHardTopRadioButton.Visibility = Visibility.Visible;
        //isSoftTopRadioButton.Visibility = Visibility.Visible;
        //isOpenTopRadioButton.Visibility = Visibility.Visible;
        //isOpenSideRadioButton.Visibility = Visibility.Visible;
    }

    private void IntermediateBulkRadioButton_Checked(object sender, RoutedEventArgs e)
    {
        //isHardTopRadioButton.Visibility = Visibility.Hidden;
        //isSoftTopRadioButton.Visibility = Visibility.Hidden;
        //isOpenTopRadioButton.Visibility = Visibility.Hidden;
        //isOpenSideRadioButton.Visibility = Visibility.Hidden;
    }

    private void RefrigeratedRadioButton_Checked(object sender, RoutedEventArgs e)
    {

    }
}
