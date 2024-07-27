using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

using System.Collections.Generic;
using System.Linq;

namespace Assignment3_ATMApp
{
    public class Bank
    {
        private List<Account> accounts = new List<Account>();

        public Bank()
        {
            for (int i = 100; i < 110; i++)
            {
                accounts.Add(new Account(i, 100, 3.0, $"Account Holder {i}"));
            }
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account? RetrieveAccount(int accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
    }
}
