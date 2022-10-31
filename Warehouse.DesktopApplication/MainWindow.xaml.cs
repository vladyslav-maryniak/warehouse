using System;
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
        if (!string.IsNullOrWhiteSpace(contractIdTextBox.Text))
        {
            var container = new Container { };
            container = await containerService.GetAsync(Convert.ToInt32(contractIdTextBox.Text));
            List<Container> lst = new List<Container>();
            lst.Add(container);
            containerGrid.ItemsSource = lst;
        }
    }

    private async void deleteContainer_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void addContainer_Click(object sender, RoutedEventArgs e)
    {
         if (ListComboBox.SelectedIndex == 0)
         {

         }

        if (ListComboBox.SelectedIndex == 1)
        {

        }

        if (ListComboBox.SelectedIndex == 2)
        {

        }

        ExternalDimensions externalDimensions = new ExternalDimensions()
        {
            Length = Convert.ToDouble(lengthCreateTextBox.Text),
            Width = Convert.ToDouble(lengthCreateTextBox.Text),
            Height = Convert.ToDouble(lengthCreateTextBox.Text)
        };

        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer()
        {
            Name = Convert.ToString(nameCreateIdTextBox.Text),
            Price = Convert.ToDecimal(priceCreateTextBox.Text),
            ExternalDimensions = externalDimensions,
            InternalVolume = Convert.ToDecimal(internalVolumeCreateTextBox)
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


    private void ListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListComboBox.SelectedIndex == 0)
        {
            isHardTopRadioButton.Visibility = Visibility.Hidden;
            isSoftTopRadioButton.Visibility = Visibility.Hidden;
            isOpenSideRadioButton.Visibility = Visibility.Hidden;
            isOpenTopRadioButton.Visibility = Visibility.Hidden;

            MinTemTextBlock.Visibility = Visibility.Hidden;
            minTemperatureTextBox.Visibility = Visibility.Hidden;
            maxTemTextBlock.Visibility = Visibility.Hidden;
            maxTemperatureTextBox.Visibility = Visibility.Hidden;

            isFlexibleRadioButton.Visibility = Visibility.Visible;
            isRigidRadioButton.Visibility = Visibility.Visible;
            isVentilatedRadioButton.Visibility = Visibility.Visible;
        }
        else if(ListComboBox.SelectedIndex == 1)
        {
            isHardTopRadioButton.Visibility = Visibility.Hidden;
            isSoftTopRadioButton.Visibility = Visibility.Hidden;
            isOpenSideRadioButton.Visibility = Visibility.Hidden;
            isOpenTopRadioButton.Visibility = Visibility.Hidden;

            MinTemTextBlock.Visibility = Visibility.Visible;
            minTemperatureTextBox.Visibility = Visibility.Visible;
            maxTemTextBlock.Visibility = Visibility.Visible;
            maxTemperatureTextBox.Visibility = Visibility.Visible;

            isFlexibleRadioButton.Visibility = Visibility.Hidden;
            isRigidRadioButton.Visibility = Visibility.Hidden;
            isVentilatedRadioButton.Visibility = Visibility.Hidden;
        }
         else if(ListComboBox.SelectedIndex == 2)
        {
            isHardTopRadioButton.Visibility = Visibility.Visible;
            isSoftTopRadioButton.Visibility = Visibility.Visible;
            isOpenSideRadioButton.Visibility = Visibility.Visible;
            isOpenTopRadioButton.Visibility = Visibility.Visible;

            MinTemTextBlock.Visibility = Visibility.Hidden;
            minTemperatureTextBox.Visibility = Visibility.Hidden;
            maxTemTextBlock.Visibility = Visibility.Hidden;
            maxTemperatureTextBox.Visibility = Visibility.Hidden;

            isFlexibleRadioButton.Visibility = Visibility.Hidden;
            isRigidRadioButton.Visibility = Visibility.Hidden;
            isVentilatedRadioButton.Visibility = Visibility.Hidden;
        }
        else
        {
            isHardTopRadioButton.Visibility = Visibility.Hidden;
            isSoftTopRadioButton.Visibility = Visibility.Hidden;
            isOpenSideRadioButton.Visibility = Visibility.Hidden;
            isOpenTopRadioButton.Visibility = Visibility.Hidden;

            MinTemTextBlock.Visibility = Visibility.Hidden;
            minTemperatureTextBox.Visibility = Visibility.Hidden;
            maxTemTextBlock.Visibility = Visibility.Hidden;
            maxTemperatureTextBox.Visibility = Visibility.Hidden;

            isFlexibleRadioButton.Visibility = Visibility.Hidden;
            isRigidRadioButton.Visibility = Visibility.Hidden;
            isVentilatedRadioButton.Visibility = Visibility.Hidden;
        }
    }
}
