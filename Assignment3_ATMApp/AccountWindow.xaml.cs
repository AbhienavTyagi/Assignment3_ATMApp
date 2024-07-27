﻿using System;
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
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private Account account;

        public AccountWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
            AccountInfoTextBlock.Text = $"Account Holder: {account.AccountHolderName}\nAccount Number: {account.AccountNumber}";
        }

        private void CheckBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Balance: {account.Balance:C}");
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to deposit:", "Deposit", "0");
            if (double.TryParse(input, out double amount))
            {
                account.Deposit(amount);
                MessageBox.Show("Deposit successful!");
            }
            else
            {
                MessageBox.Show("Invalid amount.");
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to withdraw:", "Withdraw", "0");
            if (double.TryParse(input, out double amount))
            {
                try
                {
                    account.Withdraw(amount);
                    MessageBox.Show("Withdrawal successful!");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.");
            }
        }

        private void DisplayTransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            string transactions = string.Join("\n", account.Transactions);
            MessageBox.Show(transactions == "" ? "No transactions." : transactions);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}