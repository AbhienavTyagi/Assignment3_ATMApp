using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Assignment3_ATMApp
{
    public class AtmApplication
    {
        private Bank bank;

        public AtmApplication()
        {
            bank = new Bank();
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("ATM Main Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Select Account");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        SelectAccount();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.Clear();
            Console.Write("Enter Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.Write("Enter Initial Balance: ");
                if (double.TryParse(Console.ReadLine(), out double initialBalance))
                {
                    Console.Write("Enter Interest Rate: ");
                    if (double.TryParse(Console.ReadLine(), out double interestRate))
                    {
                        Console.Write("Enter Account Holder's Name: ");
                        string accountHolderName = Console.ReadLine() ?? "Unknown";

                        Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
                        bank.AddAccount(newAccount);
                        Console.WriteLine("Account created successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid interest rate.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid initial balance.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        private void SelectAccount()
        {
            Console.Clear();
            Console.Write("Enter Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Account? account = bank.RetrieveAccount(accountNumber);

                if (account != null)
                {
                    bool managingAccount = true;
                    while (managingAccount)
                    {
                        Console.Clear();
                        Console.WriteLine($"Account Menu for {account.AccountHolderName}:");
                        Console.WriteLine("1. Check Balance");
                        Console.WriteLine("2. Deposit");
                        Console.WriteLine("3. Withdraw");
                        Console.WriteLine("4. Display Transactions");
                        Console.WriteLine("5. Exit Account");
                        Console.Write("Enter your choice: ");
                        string choice = Console.ReadLine() ?? string.Empty;

                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine($"Balance: {account.Balance:C}");
                                break;
                            case "2":
                                Console.Write("Enter amount to deposit: ");
                                if (double.TryParse(Console.ReadLine(), out double depositAmount))
                                {
                                    try
                                    {
                                        account.Deposit(depositAmount);
                                        Console.WriteLine("Deposit successful!");
                                    }
                                    catch (InvalidOperationException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid deposit amount.");
                                }
                                break;
                            case "3":
                                Console.Write("Enter amount to withdraw: ");
                                if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                                {
                                    try
                                    {
                                        account.Withdraw(withdrawAmount);
                                        Console.WriteLine("Withdrawal successful!");
                                    }
                                    catch (InvalidOperationException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid withdrawal amount.");
                                }
                                break;
                            case "4":
                                Console.WriteLine("Transactions:");
                                foreach (var transaction in account.Transactions)
                                {
                                    Console.WriteLine(transaction);
                                }
                                break;
                            case "5":
                                managingAccount = false;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Press any key to try again...");
                                break;
                        }

                        if (managingAccount)
                        {
                            Console.WriteLine("Press any key to return to the account menu...");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }

}

