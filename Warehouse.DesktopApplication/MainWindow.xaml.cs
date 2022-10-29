using System.Windows;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication;

public partial class MainWindow : Window
{
    private readonly IContractService contractService;

    public MainWindow(IContractService contractService)
    {
        InitializeComponent();
        this.contractService = contractService;
    }

    private async void getContracts_Click(object sender, RoutedEventArgs e)
    {
        // GetAll
        var contracts = await contractService.GetAllAsync();

        // Post
        var contract = new Contract { Credential = "asdf" };
        contract = await contractService.AddAsync(contract);

        // Put
        contract.Credential += "FromPut";
        await contractService.UpdateAsync(contract);

        // Get
        contract = await contractService.GetAsync(contract.Id);
        containers.Text = $"[{contracts.Length} + {contract!.Id}] => {contract.Credential}";

        // Delete
        await contractService.DeleteAsync(contract.Id);
    }
}
