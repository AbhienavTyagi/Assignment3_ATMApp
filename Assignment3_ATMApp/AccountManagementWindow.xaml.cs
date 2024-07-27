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
    /// Interaction logic for AccountManagementWindow.xaml
    /// </summary>
    public partial class AccountManagementWindow : Window
    {
        private Account account;

        public AccountManagementWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
            UpdateAccountDetails();
        }

        private void UpdateAccountDetails()
        {
            AccountDetailsTextBlock.Text = $"Account Number: {account.AccountNumber}\n" +
                                            $"Account Holder: {account.AccountHolderName}\n" +
                                            $"Balance: {account.Balance:C}";
        }

        private void CheckBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Balance: {account.Balance:C}");
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to deposit:", "Deposit", "0");
            if (double.TryParse(input, out double depositAmount))
            {
                try
                {
                    account.Deposit(depositAmount);
                    MessageBox.Show("Deposit successful!");
                    UpdateAccountDetails();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid deposit amount.");
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to withdraw:", "Withdraw", "0");
            if (double.TryParse(input, out double withdrawAmount))
            {
                try
                {
                    account.Withdraw(withdrawAmount);
                    MessageBox.Show("Withdrawal successful!");
                    UpdateAccountDetails();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid withdrawal amount.");
            }
        }

        private void DisplayTransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            string transactions = string.Join("\n", account.Transactions);
            MessageBox.Show($"Transactions:\n{transactions}");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
