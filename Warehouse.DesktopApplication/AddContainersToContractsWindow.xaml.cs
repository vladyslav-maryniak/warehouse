using System.Collections.Generic;
using System.Windows;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication
{

    public partial class AddContainersToContractsWindow : Window
    {
        private readonly IContainerService containerService;
        private Contract contract;
        public AddContainersToContractsWindow(IContainerService containerService, Contract contract)
        {
            InitializeComponent();
            this.contract = contract;
            this.containerService = containerService;
            getAllContainer();
        }

        private async void getAllContainer()
        {
            try
            {
                var container = await containerService.GetAllAsync();
                List<Container> lst = new List<Container>(container);
                containerGrid.ItemsSource = lst;
            }
            catch { }
        }
        private async void getContainers_Click(object sender, RoutedEventArgs e)
        {
            getAllContainer();
        }

        private async void addContainerToContract(object sender, RoutedEventArgs e)
        {
                if (containerGrid.SelectedIndex != -1)
                {
                    Container container = (Container)containerGrid.SelectedItem;
                    if (container.ContractId == null)
                    {
                        container.ContractId = contract.Id;
                        await containerService.UpdateAsync(container);
                        getAllContainer();
                    }
                }
        }

        private async void deleteContainerToContract(object sender, RoutedEventArgs e)
        {
            if (containerGrid.SelectedIndex != -1)
            {
                Container container = (Container)containerGrid.SelectedItem;
                if (container.ContractId != null)
                {
                    container.ContractId = null;
                    await containerService.UpdateAsync(container);
                    getAllContainer();
                }
            }
        }
    }
}
