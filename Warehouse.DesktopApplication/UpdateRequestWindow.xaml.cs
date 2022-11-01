using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Warehouse.DesktopApplication.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication
{
    public partial class UpdateRequestWindow : Window
    {
        private readonly IRequestService requestService;
        private Request request;

        public UpdateRequestWindow(IRequestService requestService, Request request)
        {
            InitializeComponent();
            this.requestService = requestService;
            this.request = request;
            requestTargetDateTextBox.Text = Convert.ToString(request.TargetDate);
            employeeIdTextBox.Text = Convert.ToString(request.EmployeeId);
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                request.TargetDate = Convert.ToDateTime(requestTargetDateTextBox.Text);
                request.EmployeeId = Convert.ToInt32(employeeIdTextBox.Text);
                await requestService.UpdateAsync(request);
                this.Close();
            }
            catch { }
        }
        private void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
