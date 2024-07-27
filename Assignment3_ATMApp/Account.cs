using System;
using System.Collections.Generic;

namespace Assignment3_ATMApp
{
    public class Account
    {
        public int AccountNumber { get; }
        public double Balance { get; private set; }
        public double InterestRate { get; }
        public string AccountHolderName { get; }
        public List<string> Transactions { get; } = new List<string>();

        public Account(int accountNumber, double initialBalance, double interestRate, string accountHolderName)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
            AccountHolderName = accountHolderName;
            Transactions.Add($"Account created with initial balance: {initialBalance:C}");
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transactions.Add($"Deposited: {amount:C}");
            }
            else
            {
                throw new InvalidOperationException("Deposit amount must be positive.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Transactions.Add($"Withdrew: {amount:C}");
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds or invalid withdrawal amount.");
            }
        }
    }
}
