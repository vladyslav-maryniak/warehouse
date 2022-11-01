using System;
using System.Windows;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication
{
    public partial class UpdateContractWindow : Window
    {
        private readonly IContractService contractService;
        private Contract contract;
        public UpdateContractWindow(IContractService contractService, Contract contract)
        {
            InitializeComponent();
            this.contractService = contractService;
            this.contract = contract;
            contractExpiryDateTextBox.Text = contract.ExpiryDate.ToString();
        }

        private async void updateContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract.ExpiryDate = Convert.ToDateTime(contractExpiryDateTextBox.Text);
                await contractService.UpdateAsync(contract);
                this.Close();
            }
            catch { }
        }
    }
}
