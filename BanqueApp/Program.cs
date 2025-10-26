using System;
using BanqueLogic; // Importation du "cerveau"

namespace BanqueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bienvenue sur l'Application Console Banque ===");

            try
            {
                // 1. Création du compte (via la bibliothèque logique)
                BankAccount compte = new BankAccount("Meryem_Ezzouhairi", 2000);
                Console.WriteLine($"Compte créé pour {compte.Owner} avec un solde de {compte.Balance} DH.");
                Console.WriteLine("---------------------------------------------");

                bool continuer = true;
                while (continuer)
                {
                    Console.WriteLine("\n_____________Choisissez une option :_____________");
                    Console.WriteLine("1: Créditer");
                    Console.WriteLine("2: Débiter");
                    Console.WriteLine("3: Quitter");
                    Console.Write("Votre choix : ");

                    string choix = Console.ReadLine();
                    int montant = 0;

                    try
                    {
                        switch (choix)
                        {
                            case "1": // CRÉDIT
                                Console.Write("Entrez le montant à créditer : ");
                                montant = Convert.ToInt32(Console.ReadLine()); // Peut lever FormatException
                                compte.Credit(montant); // Peut lever ArgumentOutOfRangeException
                                Console.WriteLine($"Opération réussie. Nouveau solde : {compte.Balance} DH");
                                break;

                            case "2": // DÉBIT
                                Console.Write("Entrez le montant à débiter : ");
                                montant = Convert.ToInt32(Console.ReadLine()); // Peut lever FormatException
                                compte.Debit(montant); // Peut lever InvalidOperationException ou ArgumentOutOfRangeException
                                Console.WriteLine($"Opération réussie. Nouveau solde : {compte.Balance} DH");
                                break;

                            case "3": // QUITTER
                                continuer = false;
                                Console.WriteLine("Merci d'avoir utilisé nos services.");
                                break;

                            default:
                                Console.WriteLine("Choix invalide. Veuillez réessayer.");
                                break;
                        }
                    }
                    // 4. Capturer les erreurs MÉTIER spécifiques
                    catch (InvalidOperationException ex) // Solde insuffisant
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"ERREUR MÉTIER : {ex.Message}");
                        Console.ResetColor();
                    }
                    catch (ArgumentOutOfRangeException ex) // Montant négatif
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"ERREUR MÉTIER : {ex.Message}");
                        Console.ResetColor();
                    }
                    // 5. Capturer les erreurs de SAISIE spécifiques
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ERREUR DE SAISIE : Veuillez entrer un nombre valide.");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex) // Capture les erreurs de création de compte (ex: solde initial négatif)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erreur critique à la création du compte : {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nAppuyez sur Entrée pour fermer...");
            Console.ReadLine();
        }
    }
}

