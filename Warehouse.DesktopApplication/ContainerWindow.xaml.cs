using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication;

public partial class ContainerWindow : Window
{
    private readonly IContainerService containerService;

    public ContainerWindow(IContainerService containerService)
    {
        InitializeComponent();
        this.containerService = containerService;
        //getAllContainer();
    }
    private async void getAllContainer()
    {
        var container = await containerService.GetAllAsync();
        List<Container> lst = new List<Container>(container);
        containerGrid.ItemsSource = lst;
    }
    private async void getContainers_Click(object sender, RoutedEventArgs e)
    {
        getAllContainer();
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
        if (containerGrid.SelectedIndex != -1)
        {
            Container container = (Container)containerGrid.SelectedItem;
            await containerService.DeleteAsync(container.Id);
            getAllContainer();
        }
        else
        {
            MessageBox.Show("ERROR");
        }
    }

    private async void addContainer_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var length = Convert.ToDouble(lengthCreateTextBox.Text);
            var width = Convert.ToDouble(widthCreateTextBox.Text);
            var height = Convert.ToDouble(heightCreateTextBox.Text);
            var name = Convert.ToString(nameCreateIdTextBox.Text);
            var price = Convert.ToDecimal(priceCreateTextBox.Text);
            var internalVolume = Convert.ToDecimal(internalVolumeCreateTextBox.Text);

            if (ListComboBox.SelectedIndex == 0)
            {
                IntermediateBulkContainer intermediateBulkContainer = new IntermediateBulkContainer()
                {
                    Name = name,
                    Price = price,
                    InternalVolume = internalVolume,

                    IsFlexible = isFlexibleRadioButton.IsChecked.Value,
                    IsRigid = isRigidRadioButton.IsChecked.Value,
                    IsVentilated = isVentilatedRadioButton.IsChecked.Value,

                    ExternalDimensions = new ExternalDimensions()
                    {
                        Length = length,
                        Width = width,
                        Height = height
                    }
                    
                };
                await containerService.AddAsync(intermediateBulkContainer);
            }

            if (ListComboBox.SelectedIndex == 1)
            {
                RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer()
                {
                    Name = name,
                    Price = price,
                    InternalVolume = internalVolume,

                    MaxTemperature = Convert.ToInt32(maxTemperatureTextBox.Text),
                    MinTemperature = Convert.ToInt32(minTemperatureTextBox.Text),

                    ExternalDimensions = new ExternalDimensions()
                    {
                        Length = length,
                        Width = width,
                        Height = height
                    }
                };
                await containerService.AddAsync(refrigeratedContainer);
            }

            if (ListComboBox.SelectedIndex == 2)
            {
                FreightContainer freightContainer = new FreightContainer()
                {
                    Name = name,
                    Price = price,
                    InternalVolume = internalVolume,

                    IsHardTop = isHardTopRadioButton.IsChecked.Value,
                    IsSoftTop = isSoftTopRadioButton.IsChecked.Value,
                    IsOpenSide = isOpenSideRadioButton.IsChecked.Value,
                    IsOpenTop = isOpenSideRadioButton.IsChecked.Value,

                    ExternalDimensions = new ExternalDimensions()
                    {
                        Length = length,
                        Width = width,
                        Height = height
                    }
                };
                await containerService.AddAsync(freightContainer);
            }
        }
        catch
        {
            MessageBox.Show("No corect data");
        }
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
    private void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}
