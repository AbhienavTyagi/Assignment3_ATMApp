using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment3_ATMApp
{
    /// <summary>
    /// Interaction logic for SelectAccountWindow.xaml
    /// </summary>
    public partial class SelectAccountWindow : Window
    {
        private Bank bank;

        public SelectAccountWindow(Bank bank)
        {
            InitializeComponent();
            this.bank = bank;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AccountNumberTextBox.Text, out int accountNumber))
            {
                Account? account = bank.RetrieveAccount(accountNumber);
                if (account != null)
                {
                    AccountManagementWindow accountManagementWindow = new AccountManagementWindow(account);
                    accountManagementWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Account not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid account number.");
            }
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Account Number")
            {
                textBox.Text = "";
            }
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Account Number";
            }
        }
    }

}
