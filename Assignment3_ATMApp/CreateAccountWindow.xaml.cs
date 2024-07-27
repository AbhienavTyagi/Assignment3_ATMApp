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
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        private Bank bank;

        public CreateAccountWindow(Bank bank)
        {
            InitializeComponent();
            this.bank = bank;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AccountNumberTextBox.Text, out int accountNumber) &&
                double.TryParse(InitialBalanceTextBox.Text, out double initialBalance) &&
                double.TryParse(InterestRateTextBox.Text, out double interestRate) &&
                !string.IsNullOrWhiteSpace(AccountHolderNameTextBox.Text))
            {
                string accountHolderName = AccountHolderNameTextBox.Text;

                Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
                bank.AddAccount(newAccount);

                MessageBox.Show("Account created successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid account details.");
            }
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Account Number" || textBox.Text == "Initial Balance" ||
                textBox.Text == "Interest Rate" || textBox.Text == "Account Holder Name")
            {
                textBox.Text = "";
            }
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                switch (textBox.Name)
                {
                    case "AccountNumberTextBox":
                        textBox.Text = "Account Number";
                        break;
                    case "InitialBalanceTextBox":
                        textBox.Text = "Initial Balance";
                        break;
                    case "InterestRateTextBox":
                        textBox.Text = "Interest Rate";
                        break;
                    case "AccountHolderNameTextBox":
                        textBox.Text = "Account Holder Name";
                        break;
                }
            }
        }
    }
}
