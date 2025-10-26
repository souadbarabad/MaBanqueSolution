using BanqueLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BanqueLogic.Tests
{

    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]

        public void Tester_Cas_Ideal_Debit()
        {
            int soldeInitial = 200;
            BankAccount compte = new BankAccount("souad_barabad", soldeInitial);
            double solde_attendu = 100;
            //arrange, act, assert => organiser, agir, verifier !!!

            compte.Debit(100);
            Assert.AreEqual(solde_attendu, compte.Balance);
        }

        [TestMethod]
        public void Tester_Cas_Ideal_Credit()
        {
            int soldeInitial = 200;
            BankAccount compte = new BankAccount("souad_barabad", soldeInitial);
            double solde_attendu = 250;
            //arrange, act, assert => organiser, agir, verifier !!!

            compte.Credit(50);
            Assert.AreEqual(solde_attendu, compte.Balance);
        }


        [TestMethod]
        public void Debit_Solde_Insuffisants_Leve_Exception()
        {
            BankAccount compte = new BankAccount("souad_barabad", 500);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                compte.Debit(5000);
            });

        }

        [TestMethod]
        public void Debit_Montant_Negative_Leve_Exception()
        {
            BankAccount compte = new BankAccount("souad_barabad", 500);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                compte.Debit(-50);
            });
        }

        [TestMethod]
        public void Credit_Montant_Negatif_Leve_Exception()
        {
            // Arrange
            BankAccount compte = new BankAccount("souad_barabad", 500);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                compte.Credit(-50);
            });
        }
    }
}

