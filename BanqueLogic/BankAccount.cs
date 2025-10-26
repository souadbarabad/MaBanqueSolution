using System;

namespace BanqueLogic
{
    public class BankAccount
    {
        public string Owner { get; }
        public int Balance { get; private set; }

        public BankAccount(string owner, int balance)
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("Il faut ajouter un nom du client ", nameof(owner));
            }
            if (balance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(balance), "le solde doit etre positive");
            }
            Owner = owner;
            Balance = balance;
        }

        public void Credit(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit etre positive !");
            }
            Balance += amount;
        }


        public void Debit(int amount_debit)
        {
            if (amount_debit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount_debit), "Le montant doit etre positive !");
            }

            if (Balance < amount_debit)
            {
                throw new InvalidOperationException("Le solde insuffisant veuillez enter un montant valide");
            }
            Balance -= amount_debit;
        }
    }
}

