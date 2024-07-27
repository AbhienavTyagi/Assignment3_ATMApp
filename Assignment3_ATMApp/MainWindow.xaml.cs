using System;
using System.Windows;

namespace Assignment3_ATMApp
{
    public partial class MainWindow : Window
    {
        private Bank bank;

        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount();
        }

        private void CreateAccount()
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow(bank);
            createAccountWindow.ShowDialog();
        }

        private void SelectAccountButton_Click(object sender, RoutedEventArgs e)
        {
            SelectAccount();
        }

        private void SelectAccount()
        {
            SelectAccountWindow selectAccountWindow = new SelectAccountWindow(bank);
            selectAccountWindow.ShowDialog();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

}