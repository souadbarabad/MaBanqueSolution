using System;
using BanqueLogic;


namespace BanqueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'un compte bancaire
            BankAccount account = new BankAccount("Meryem", 1000);

            Console.WriteLine("=== Bank Account Application ===");
            Console.WriteLine($"Propriétaire : {account.Owner}");
            Console.WriteLine($"Solde initial : {account.Balance} DH");

            // Effectuer un crédit
            Console.Write("\nEntrez un montant à créditer : ");
            int creditAmount = Convert.ToInt32(Console.ReadLine());
            account.Credit(creditAmount);
            Console.WriteLine($"Nouveau solde après crédit : {account.Balance} DH");

            // Effectuer un débit
            Console.Write("\nEntrez un montant à débiter : ");
            int debitAmount = Convert.ToInt32(Console.ReadLine());

            try
            {
                account.Debit(debitAmount);
                Console.WriteLine($"Nouveau solde après débit : {account.Balance} DH");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }

            Console.WriteLine("\n=== Fin du programme ===");
        }
    }
}

